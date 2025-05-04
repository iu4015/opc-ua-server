using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Threading.Tasks;

namespace OpcUaServer.Services
{
    public class RealTimeNodeService
    {
        private readonly string _endpointUrl;
        private ApplicationConfiguration _configuration;
        private Session _session;

        // Конструктор для ініціалізації URL кінцевої точки
        public RealTimeNodeService(string endpointUrl)
        {
            _endpointUrl = endpointUrl;
        }

        // Асинхронне підключення до OPC UA сервера
        public async Task ConnectAsync()
        {
            _configuration = new ApplicationConfiguration
            {
                ApplicationName = "RealTimeNodeService",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    ApplicationCertificate = new CertificateIdentifier(),
                    AutoAcceptUntrustedCertificates = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 15000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 },
                DisableHiResClock = true
            };

            await _configuration.Validate(ApplicationType.Client);

            var endpoint = CoreClientUtils.SelectEndpoint(_endpointUrl, useSecurity: false);
            var endpointConfiguration = EndpointConfiguration.Create(_configuration);
            var endpointDescription = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

            _session = await Session.Create(
                _configuration,
                endpointDescription,
                false,
                "RealTimeNodeService",
                60000,
                null,
                null);
        }

        // Підписка на вузол для отримання даних у реальному часі
        public void SubscribeToNode(string nodeId, Action<DataValue> callback)
        {
            if (_session == null)
            {
                throw new InvalidOperationException("Сесія не встановлена. Спочатку викличте ConnectAsync.");
            }

            var subscription = new Subscription(_session.DefaultSubscription)
            {
                PublishingInterval = 100,
                KeepAliveCount = 10,
                LifetimeCount = 20,
                MaxNotificationsPerPublish = 10,
                Priority = 0
            };

            _session.AddSubscription(subscription);
            subscription.Create();

            var monitoredItem = new MonitoredItem(subscription.DefaultItem)
            {
                StartNodeId = nodeId,
                AttributeId = Attributes.Value,
                SamplingInterval = 100,
                QueueSize = 10,
                DiscardOldest = true
            };

            // Обробка змін значення вузла
            monitoredItem.Notification += (monitoredItem, args) =>
            {
                foreach (var value in args.NotificationValue as MonitoredItemNotification[])
                {
                    callback(value.Value);
                }
            };

            subscription.AddItem(monitoredItem);
            subscription.ApplyChanges();
        }

        // Асинхронне відключення від OPC UA сервера
        public async Task DisconnectAsync()
        {
            if (_session != null)
            {
                await _session.CloseAsync();
                _session.Dispose();
                _session = null;
            }
        }
    }
}
