using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCua
{
    class DiscreteAlarm : BaseAlarm
    {
        public bool ActiveStateId { get; set; }//стан аварії
        public DateTime ActiveStateTransitionTime { get; set; }//час останньої зміни стану
        public NodeId? NormalState { get; set; }//властивість, що вказує на змінну в нормальному стані
        public DateTime OnDelay { get; set; }//налаштування часу для стрибків сигналу, які не спричинять тривогу 
        public DateTime OffDelay { get; set; } //налаштування часу для падінь сигналу, які не спричинять тривогу
        public bool SuppressedOrShelved { get; set; }//тривога не відображається, коли true і коли вона у відповідному стані
        public DateTime MaxTimeShelved { get; set; }//максимальний час відкладення тривоги
        public DateTime ReAlarmTime { get; set; }//якщо присутній, встановлює час, який використовується для повернення тривоги в початковий стан (якщо не повернулась - виникне нова тривога)
    }
}
