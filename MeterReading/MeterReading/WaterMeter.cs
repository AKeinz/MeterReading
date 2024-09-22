using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class WaterMeter: Meter
    {
        public string TypeOfWater {  get; set; }

        public override Meter SetMeterData(int endOfTypeIndex, string[] dataArray)
        {
            for (int index = 0; index <= endOfTypeIndex; index++)
            {
                ResourceType += dataArray[index] + " ";
            }
            DateOfReading = DateTime.Parse(dataArray[endOfTypeIndex + 1]);
            Value = Double.Parse(dataArray[endOfTypeIndex + 2].Replace('.', ','));
            TypeOfWater = dataArray[endOfTypeIndex + 3];
            return this;
        }

        public override string GetMeterData()
        {
            string output = "ResourceType: " + ResourceType + "\nDate: " + DateOfReading + "\nValue: " + Value
                + "\nTypeOfWater: " + TypeOfWater + "\n";
            return output;
        }
    }
}
