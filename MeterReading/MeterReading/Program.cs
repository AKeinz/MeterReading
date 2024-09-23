using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string[] dataFromFile = ReadFromFile.ReadFile();

            foreach (string dataMeter in dataFromFile)
            {
                StringToMeter.TrySetMeterData(dataMeter);
            }

            foreach (Meter meter in StringToMeter.GetMetersList())
            {
               Console.WriteLine(meter.GetMeterData());
            }

            Console.ReadLine();
        }
    }
}
