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
        public NodeId? BranchId { get; set; }//ідентифікатор гілки
        public bool Retain { get; set; }//прапорець збереження
        public string? ClientUserId { get; set; }//строка, яка ідентифікує користувача, що запитує дію

    }
}
