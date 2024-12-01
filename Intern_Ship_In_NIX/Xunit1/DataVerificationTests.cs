using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DisplayConsole;

namespace Xunit1
{
    public class DataVerificationTests
    {
        [Fact]
        public void CorrectDataInt_ShouldReturnValidInt()
        {
            // Arrange
            var dataVerification = new DataVerification();
            var input = new StringReader("5\n");
            Console.SetIn(input);

            // Act
            var result = dataVerification.CorrectDataInt("Enter number: ");

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void CorrectDataString_ShouldReturnValidString()
        {
            // Arrange
            var dataVerification = new DataVerification();
            var input = new StringReader("TestString\n");
            Console.SetIn(input);

            // Act
            var result = dataVerification.CorrectDataString("Enter string: ");

            // Assert
            Assert.Equal("TestString", result);
        }
    }
}
