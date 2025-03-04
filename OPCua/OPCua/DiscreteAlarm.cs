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
    }
}
