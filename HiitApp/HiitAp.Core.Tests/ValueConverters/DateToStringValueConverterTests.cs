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
            string converted = (string)vc.Convert(dateToConvert, null, null, null);

            // Assert
            Assert.AreEqual(DateTime.Now.Date.ToString(), converted);
        }

        [Test]
        public void ConvertBack_ConvertsFromStringToDate()
        {
            // Arrange
            var vc = new DateToStringValueConverter();
            string dateStringToConvert = DateTime.Now.Date.ToString(); ;

            // Act
            DateTime convertedBack = (DateTime)vc.ConvertBack(dateStringToConvert, null, null, null);

            // Assert
            Assert.AreEqual(DateTime.Now.Date, convertedBack);
        }

    }
}