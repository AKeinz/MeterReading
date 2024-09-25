using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class ElectricityMeter: Meter
    {
        public int MeterNumber {  get; set; }

        public override Meter SetMeterData(int endOfTypeIndex, string[] dataArray)
        {
            DateOfReading = DateTime.Parse(dataArray[endOfTypeIndex + 1]);
            Value = Double.Parse(dataArray[endOfTypeIndex + 2].Replace('.', ','));
            MeterNumber = int.Parse(dataArray[endOfTypeIndex + 3]);
            return this;
        }

        public override string GetMeterData()
        {
            string output = "ResourceType: " + ResourceType + "\nDate: " + DateOfReading + "\nValue: " + Value
                + "\nMeterNumber: " + MeterNumber + "\n"; ;
            return output;
        }
    }


}
