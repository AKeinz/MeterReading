﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    public class Meter
    {
        public string ResourceType { get; set; } = "";
        public DateTime DateOfReading { get; set; }
        public double Value { get; set; }

        public virtual Meter SetMeterData(int endOfTypeIndex, string[] dataArray)
        {
            for (int index = 0; index <= endOfTypeIndex; index++)
            {
                ResourceType += dataArray[index] + " ";
            }
            DateOfReading = DateTime.Parse(dataArray[endOfTypeIndex + 1]);
            Value = Double.Parse(dataArray[endOfTypeIndex + 2].Replace('.', ','));
            return this;
        }

        public virtual string GetMeterData()
        {
            string output = "ResourceType: " + ResourceType + "\nDate: " + DateOfReading + "\nValue: " + Value + "\n";
            return output;
        }
    }
}
