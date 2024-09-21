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

        public static bool TrySetMeterData(string input)
        {
            string[] data = toDataArrayWithSingleSpaces(input);
            bool IsRightInput = checkData(data);
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
                double forTryParseValue;
                DateTime forTryParseDate;
                int endOfTypeIndex = Array.FindIndex(dataArray, word => word.EndsWith("\'") || word.EndsWith("\""));
                bool isTryParseDate = DateTime.TryParse(dataArray[endOfTypeIndex + 1], out forTryParseDate);
                bool isTryParseValue = Double.TryParse(dataArray[endOfTypeIndex + 2].Replace('.', ','), out forTryParseValue);
                if ((dataArray.Length - 1) - endOfTypeIndex == 2 && isTryParseDate && isTryParseValue && 
                    forTryParseValue>=0 && forTryParseDate<DateTime.Now)
                {
                    setMeterData(endOfTypeIndex, dataArray);
                    return true;
                }
            }
            return false;
        }

        private static void setMeterData(int endOfTypeIndex, string[] dataArray)
        {
            Meter meter = new Meter();
            for (int index = 0; index <= endOfTypeIndex; index++)
            {
                meter.MeterType += dataArray[index] + " ";
            }
            meter.DateOfReading = DateTime.Parse(dataArray[endOfTypeIndex + 1]);
            meter.Value = Double.Parse(dataArray[endOfTypeIndex + 2].Replace('.', ','));
            MeterInProcess = meter;
        }

    }
}
