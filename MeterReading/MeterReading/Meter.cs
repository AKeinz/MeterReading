using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    public class Meter
    {
        public string MeterType { get; set; } = "";
        public DateTime DateOfReading { get; set; }
        public double Value { get; set; }
    }
}
