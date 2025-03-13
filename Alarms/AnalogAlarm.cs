using Opc.Ua;
using OPCua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPC_ua_modules
{
	class AnalogAlarm : BaseAlarm
	{
		public required double HighHighLimit { get; set; } // Верхня критична межа
		public required double HighLimit { get; set; } // Верхня межа
		public required double LowLimit { get; set; } // Нижня межа
		public required double LowLowLimit { get; set; } // Нижня критична межа
		public double SeverityHighHigh { get; set; } //Рівень серйозності при перевищенні верхньої критичної межі
		public double SeverityHigh { get; set; } //Рівень серйозності при перевищенні верхньої межі
		public double SeverityLow { get; set; } // Рівень серйозності при падінні нижче нижньої межі
		public double SeverityLowLow { get; set; } // Рівень серйозності при падінні нижче нижньої критичної межі
		public double HighHighDeadband { get; set; } // Зона нечутливості для гранично високої межі
		public double HighDeadband { get; set; } // Зона нечутливості для високої межі
		public double LowDeadband { get; set; } // Зона нечутливості для низької межі
		public double LowLowDeadband { get; set; } // Зона нечутливості для гранично низької межі
	}
}
