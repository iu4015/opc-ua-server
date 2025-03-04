using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OPCua
{
    class BaseAlarm
    {
        public NodeId? EventId { get; set; }//ідентифікатор тривоги
        public NodeId? EventType { get; set; }//тип події (аналогова, чи дискретна)
        public NodeId? SourceNode { get; set; }//вузол, що ініціював тривогу
        public NodeId? InputNode { get; set; }//вузол-джерело сигналу
        public string? SourceName { get; set; }//текстове ім'я джерела події
        public DateTime Time { get; set; }//час виникнення тривоги
        public DateTime ReceiveTime { get; set; }//час отримання тривоги сервером
        public LocalizedText? Message { get; set; }//текстове повідомлення тривоги
        public ushort Severity { get; set; }//рівень критичності тривоги
        public NodeId? ConditionClassId { get; set; }//ідентифікатор класу умови (в якому домені використовується)
        public string? ConditionName { get; set; }//ім'я конкретного типу тривоги (визначає екземпляр condition, з якого надходить умова)
        public LocalizedText? ConditionClassName { get; set; }//надає назву класу стану
        public NodeId? BranchId { get; set; }//ідентифікатор гілки
        public bool Retain { get; set; }//прапорець збереження
        public string? ClientUserId { get; set; }//строка, яка ідентифікує користувача, що запитує дію
        public DateTime OnDelay { get; set; }//налаштування часу для стрибків сигналу, які не спричинять тривогу 
        public DateTime OffDelay { get; set; } //налаштування часу для падінь сигналу, які не спричинять тривогу
        public bool SuppressedOrShelved { get; set; }//тривога не відображається, коли true і коли вона у відповідному стані
        public DateTime MaxTimeShelved { get; set; }//максимальний час відкладення тривоги
        public DateTime ReAlarmTime { get; set; }//якщо присутній, встановлює час, який використовується для повернення тривоги в початковий стан (якщо не повернулась - виникне нова тривога)
    }
}