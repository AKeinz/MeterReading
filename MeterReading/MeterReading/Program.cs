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
            string input = "  \'Счетчик электрической энергии\'        2004.10.12  0";
            Console.WriteLine($"Введены следующие показания счетчика: {input}");
            StringToMeter.TrySetMeterData(input);
            if (StringToMeter.TrySetMeterData(input))
            {
                Console.WriteLine("MeterType: " + StringToMeter.MeterInProcess.MeterType);
                Console.WriteLine("Date: " + StringToMeter.MeterInProcess.DateOfReading);
                Console.WriteLine("Value: " + StringToMeter.MeterInProcess.Value);
            }
            else 
            {
                Console.WriteLine("Неверно введены данные");
            }
        }
    }
}
