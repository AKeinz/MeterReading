using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class ReadFromFile
    {
        static string filePath = "C:\\Users\\user\\Desktop\\MeterReading\\MeterReading\\MeterReading\\Data.txt";

        public static string ReadFile()
        {
            string[] MetersData = File.ReadAllLines(filePath);
            string output = "";
            foreach (string MeterData in MetersData)
            {
                StringToMeter.TrySetMeterData(MeterData);
                output += StringToMeter.GetMeterData() + "\n";
            }
            return output;
        }
    }
}
