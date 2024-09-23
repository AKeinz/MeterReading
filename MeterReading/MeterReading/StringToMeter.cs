using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeterReading
{
    internal class StringToMeter
    {
        public static Meter MeterInProcess;
        static bool IsRightInput = false;
        private static readonly List<Meter> meters = new List<Meter>();

        public static bool TrySetMeterData(string input)
        {
            string[] data = toDataArrayWithSingleSpaces(input);
            IsRightInput = checkData(data);
            if (IsRightInput) { return true; }
            return false;
        }

        private static string[] toDataArrayWithSingleSpaces(string inputData)
        {
            string data = string.Empty;
            char[] copyData = inputData.ToArray();
            for (int index = 1; index < copyData.Length; index++)
            {
                if (index == 1 && !copyData[index - 1].Equals(' ')) { data += copyData[index - 1]; }
                if (!(copyData[index - 1].Equals(' ') && copyData[index].Equals(' ')))
                {
                    data += copyData[index];
                }
            }
            return data.Split(' ');
        }

        private static bool checkData(string[] dataArray)
        {
            if (dataArray[0].StartsWith("\'") || dataArray[0].StartsWith("\""))
            {
                int endOfTypeIndex = Array.FindIndex(dataArray, word => word.EndsWith("\'") || word.EndsWith("\""));
                bool isTryParseDate = DateTime.TryParse(dataArray[endOfTypeIndex + 1], out DateTime forTryParseDate);
                bool isTryParseValue = Double.TryParse(dataArray[endOfTypeIndex + 2].Replace('.', ','), out double forTryParseValue);
                if ((dataArray.Length - 1) - endOfTypeIndex == 3 && isTryParseDate && isTryParseValue && forTryParseValue>=0 && forTryParseDate<DateTime.Now)
                {
                    setMeterData(endOfTypeIndex, dataArray);
                    return true;
                }
            }
            return false;
        }

        private static void setMeterData(int endOfTypeIndex, string[] dataArray)
        {
            Meter meter = defineMeterType(endOfTypeIndex, dataArray);
            MeterInProcess = meter.SetMeterData(endOfTypeIndex, dataArray);
            meters.Add(meter);
        }

        private static Meter defineMeterType(int endOfTypeIndex, string[] dataArray)
        {
            if (int.TryParse(dataArray[endOfTypeIndex + 3], out _ ))
            {
                return new ElectricityMeter();
            }
            else
            {
                return new WaterMeter();
            }
        }

        public static List<Meter> GetMetersList()
        {
            List<Meter> metersList = new List<Meter>();
            metersList = meters;
            return metersList;
        }
    }
}
