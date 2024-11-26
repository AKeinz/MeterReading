using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MeterReading
{
    public class StringToMeter
    {
        public static Meter MeterInProcess;
        public static bool IsRightInput = false;
        private static readonly List<Meter> meters = new List<Meter>();

        public static bool TrySetMeterData(string input)
        {
            string[] data = toDataArrayWithSingleSpaces(input);
            IsRightInput = checkData(data);
            return IsRightInput;
        }

        public static string[] toDataArrayWithSingleSpaces(string inputData)
        {
            string data = string.Empty;
            char[] copyData = inputData.ToArray();

            for (int index = 1; index < copyData.Length; index++)
            {

                if ((index == 1) && (!copyData[0].Equals(' '))) 
                { 
                    data += copyData[0]; 
                }
                if (!((copyData[index - 1].Equals(' ')) && (copyData[index].Equals(' '))))
                {
                    data += copyData[index];
                }
            }
            return data.Split(' ');
        }

        public static bool checkData(string[] dataArray)
        {
            try
            {
                if ((dataArray[0].StartsWith("\'")) && (dataArray.Any(type => type.ToUpper().Contains("ELECTRICITY") || type.ToUpper().Contains("WATER"))))
                {
                    int endOfTypeIndex = Array.FindIndex(dataArray, word => word.EndsWith("\'"));
                    string type = "";
                    bool isTryParseDate = DateTime.TryParse(dataArray[endOfTypeIndex + 1], out DateTime forTryParseDate);
                    bool isTryParseValue = Double.TryParse(dataArray[endOfTypeIndex + 2].Replace('.', ','), out double forTryParseValue);
                    if (((dataArray.Length - 1) - endOfTypeIndex == 3) && (isTryParseDate) && (isTryParseValue)
                        && (forTryParseValue >= 0) && (forTryParseDate < DateTime.Now))
                    {
                        setMeterData(endOfTypeIndex, dataArray);
                        return true;
                    }
                }
            }
            catch(NullReferenceException) { return false; }
            catch (IndexOutOfRangeException) { return false; }
            return false;
        }

        private static void setMeterData(int endOfTypeIndex, string[] dataArray)
        {
            Meter meter = defineMeterType(endOfTypeIndex, dataArray);
            if (meter != null)
            {
                MeterInProcess = meter.SetMeterData(endOfTypeIndex, dataArray);
                meters.Add(meter);
            }
        }

        public static Meter defineMeterType(int endOfTypeIndex, string[] dataArray)
        {
            string meterType = "";
            for (int i = 0; i <= endOfTypeIndex; i++)
            {
                meterType += dataArray[i];
            }
            try
            {
                if (meterType.Remove(0, 1).StartsWith("Elec"))
                {
                    return new ElectricityMeter() { ResourceType = meterType };
                }
                else if (meterType.Remove(0, 1).StartsWith("Water") && (dataArray[3].Equals("\'cold\'") || dataArray[3].Equals("\'hot\'")))
                {
                    return new WaterMeter() { ResourceType = meterType };
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
            return null;
        }

        public static List<Meter> GetMetersList()
        {
            List<Meter> metersList = new List<Meter>();
            metersList = meters;
            return metersList;
        }
    }
}
