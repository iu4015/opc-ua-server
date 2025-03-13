using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OPC_ua_modules
{
    class BaseAlarm
    {
        public string? EventId { get; set; }//ідентифікатор тривоги
        public NodeId? EventType { get; set; }//тип події (аналогова, чи дискретна)
        public NodeId? SourceNode { get; set; }//вузол, що ініціював тривогу
        public string? SourceName { get; set; }//текстове ім'я джерела події
        public LocalizedText? Message { get; set; }//текстове повідомлення тривоги
        public ushort Severity { get; set; }//рівень критичності тривоги
        public int OnDelay { get; set; }//налаштування часу для стрибків сигналу, які не спричинять тривогу 
        public int OffDelay { get; set; } //налаштування часу для падінь сигналу, які не спричинять тривогу
    }
}