using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    public abstract class Meter
    {
        public string ResourceType { get; set; } = "";
        public DateTime DateOfReading { get; set; }
        public double Value { get; set; }

        public abstract Meter SetMeterData(int endOfTypeIndex, string[] dataArray);

        public abstract string GetMeterData();
    }
}
