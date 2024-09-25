using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class ReadFromFile
    {
        static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt");
        
        public static string[] ReadFile()
        {
            string[] MetersData = File.ReadAllLines(filePath);
            return MetersData;
        }
    }
}
