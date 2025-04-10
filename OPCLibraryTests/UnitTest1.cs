using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System;
using Moq;
using Xunit;

namespace OPCLibraryTests
{
    public class ConfigurationServiceTests : IDisposable
    {
        private readonly string _tempDirectory = @"" ;
        private ConfigurationService? _service;
        private bool _eventRaised;

        public ConfigurationServiceTests()
        {
            File.WriteAllText(Path.Combine(_tempDirectory, "baseNodeConfig.json"), "[]");
            _eventRaised = false;
            _service = new ConfigurationService(_tempDirectory);
            _service.ConfigurationServiceChanged += (sender, e) =>
            {
                _eventRaised = true;
            };
        }

        [Fact]
        public async Task ShouldRaiseEvent_OnFileChanged()
        {
            // Arrange
            string configPath = Path.Combine(_tempDirectory, "baseNodeConfig.json");
            // Act
            File.AppendAllText(configPath, " ");
            await Task.Delay(300);
            // Assert
            Assert.True(_eventRaised, "Подія не була викликана після зміни файлу.");
        }

        [Fact]
        public async Task ShouldRaiseEvent_OnFileCreated()
        {
            // Arrange
            string newFilePath = Path.Combine(_tempDirectory, "newConfig.json");
            // Act
            File.WriteAllText(newFilePath, "{}");
            await Task.Delay(300);
            // Assert
            Assert.True(_eventRaised, "Подія не була викликана після створення файлу.");
        }

        [Fact]
        public async Task ShouldRaiseEvent_OnFileDeleted()
        {
            // Arrange
            string configPath = Path.Combine(_tempDirectory, "newConfig.json");
            // Act
            File.Delete(configPath);
            await Task.Delay(900);
            // Assert
            Assert.True(_eventRaised, "Подія не була викликана після видалення файлу.");
        }

        public void Dispose()
        {
            _service?.Dispose();
        }
    }
}
