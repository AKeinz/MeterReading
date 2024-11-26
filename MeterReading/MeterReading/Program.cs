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

            for (int k = 0; k < dataFromFile.Length; k++)
            {
                string dataMeter = dataFromFile[k];
                StringToMeter.TrySetMeterData(dataMeter);
                if (!StringToMeter.IsRightInput)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неверные данные в {k+1} строке! Объект не создан.\n\n");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("---------Список счетчиков---------");
            foreach (Meter meter in StringToMeter.GetMetersList())
            {
               Console.WriteLine(meter.GetMeterData());
            }

            Console.ReadLine();
        }
    }
}
