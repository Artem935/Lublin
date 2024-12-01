using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DisplayConsole;

namespace Xunit1
{
    public class MainDisplayTest
    {
        [Fact]
        public void Menu_ShouldReturnSelectedOption()
        {
            // Arrange
            var display = new MainDisplay();
            var input = new StringReader("1\n");
            Console.SetIn(input);

            // Act
            var result = display.Menu();

            // Assert
            Assert.Equal(1, result);
        }

    }
}
