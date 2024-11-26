using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace MeterReading
{
    public class ReadFromFile
    {
        static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data.txt");
        
        public static string[] ReadFile()
        {
            string[] MetersData = new string[0];
            try
            {
                string[] data = File.ReadAllLines(filePath).Where(x => !string.IsNullOrEmpty(x)).ToArray();
                MetersData = data;
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Не найден файл " + filePath + "\n Создать файл? (наберите \'да\' для создания)");
                string output = Console.ReadLine();
                if (output.ToUpper().Equals("ДА"))
                {
                    File.Create(filePath);
                }
            }
            return MetersData;
        }

        
    }
}
