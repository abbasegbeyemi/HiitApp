using NUnit.Framework;
using HiitApp.Core.ValueConverters;

namespace HiitApp.Core.Tests.ValueConverters
{
    [TestFixture]
    public class IntToStringValueConverterTests
    {
        [Test]
        public void Convert_ConvertsFromIntToString()
        {
            // Arrange
            var vc = new IntToStringValueConverter();

            // Act
            var converted = vc.Convert(123, null, null, null);

            // Assert
            Assert.AreEqual("123", converted);
        }

        [Test]
        public void ConvertBack_ConvertsFromStringToInt()
        {
            // Arrange
            var vc = new IntToStringValueConverter();

            // Act
            var convertedBack = vc.ConvertBack("123", null, null, null);

            // Assert
            Assert.AreEqual(123, convertedBack);
        }

    }
}
