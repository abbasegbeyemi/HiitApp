using NUnit.Framework;
using HiitApp.Core.ValueConverters;
using System;
using System.Globalization;

namespace HiitApp.Core.Tests.ValueConverters
{
    [TestFixture]
    public class DateToStringValueConverterTests
    {
        [Test]
        public void Convert_ConvertsFromDateToString()
        {
            // Arrange
            var vc = new DateToStringValueConverter();
            DateTime dateToConvert = DateTime.Now.Date;

            // Act
            var converted = vc.Convert(dateToConvert, null, null, null);

            // Assert
            Assert.AreEqual("21/10/2019 00:00:00", converted);
        }

        [Test]
        public void ConvertBack_ConvertsFromStringToDate()
        {
            // Arrange
            var vc = new DateToStringValueConverter();
            string dateStringToConvert = "21/10/2019 00:00:00";

            // Act
            var convertedBack = vc.ConvertBack(dateStringToConvert, null, null, null);

            // Assert
            Assert.AreEqual(DateTime.Now.Date, convertedBack);
        }

    }
}