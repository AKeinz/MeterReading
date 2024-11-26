using MeterReading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class StringToMeterTests
    {
        [TestMethod]
        public void TrySetRightMeterDataTest()
        {
            bool actual = StringToMeter.TrySetMeterData("'Electricity'        2004.10.12  45  1200023");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void TrySetSmallMeterDataTest()
        {
            bool actual = StringToMeter.TrySetMeterData("'Electricity'        45  1200023");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TrySetBigMeterDataTest()
        {
            bool actual = StringToMeter.TrySetMeterData("'Electricity'     2004.10.12 12   45  1200023");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TrySetWrongParameterTest()
        {
            bool actual = StringToMeter.TrySetMeterData("'Electricity'     12    45  1200023");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void TrySetEmptyDataTest()
        {
            bool actual = StringToMeter.TrySetMeterData("");
            Assert.IsFalse(actual);
        }


        [TestMethod]
        public void toDataArrayWithSingleSpacesTest()
        {
            PrivateObject privateObject = new PrivateObject(typeof(StringToMeter));
            //string[] actual = (string[])privateObject.Invoke("toDataArrayWithSingleSpaces", "'Electricity'        2004.10.12    45      1200023");
            string[] actual = StringToMeter.toDataArrayWithSingleSpaces("'Electricity'        2004.10.12    45      1200023");
            string[] expected = {"\'Electricity\'", "2004.10.12", "45", "1200023"};
            int k = 0;
            foreach (string a in actual)
            {
                Assert.AreEqual(expected[k], actual[k]);
                k++;
            }
        }

        [TestMethod]
        public void checkRightDataTest()
        {
            string[] input = { "\'Electricity\'", "2004.10.12", "45", "1200023" };
            bool actual = StringToMeter.checkData(input);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void checkWrongDataTest()
        {
            string[] input = { "\'Electricity\'", "2004.e10.12", "45", "1200023" };
            bool actual = StringToMeter.checkData(input);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void checkEmptyDataTest()
        {
            string[] input = new string[0];
            bool actual = StringToMeter.checkData(input);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void defineElectrMeterTypeTest()
        {
            string[] input = { "\'Electricity\'", "2004.10.12", "45", "1200023" };
            Meter meter = StringToMeter.defineMeterType(1, input);
            string actual = meter.GetType().ToString();
            string expected = "MeterReading.ElectricityMeter";
            Assert.AreEqual (expected, actual);
        }

        [TestMethod]
        public void defineWaterMeterTypeTest()
        {
            string[] input = { "\'Water\'", "2004.10.12", "45", "\'cold\'" };
            Meter meter = StringToMeter.defineMeterType(1, input);
            string actual = meter.GetType().ToString();
            string expected = "MeterReading.WaterMeter";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void defineNoneMeterTypeTest()
        {
            string[] input = { "\'not exist\'", "2004.10.12", "45", "1200023" };
            Meter meter = StringToMeter.defineMeterType(1, input);
            var actual = meter;
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void defineEmptyMeterTypeTest()
        {
            string[] input = Array.Empty<string>();
            Meter meter = StringToMeter.defineMeterType(-1, input);
            var actual = meter;
            Assert.IsNull(actual);
        }
    }
}
