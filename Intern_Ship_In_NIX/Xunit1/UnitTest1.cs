using Transport.Models.Objects;

namespace Xunit1
{
    public class UnitTest1
    {
        [Fact]
        public void PrinAllProperties_ShouldReturnCorrectHeader()
        {
            var car = new Car();
            // Act
            var result = car.PrinAllProperties();
            // Assert
            Assert.Equal("\tId\tModel\t\tBrand\tFuel Consumption\tPrice", result);
        }
        [Fact]
        public void ToString_ShouldReturnFormattedCarDetails()
        {
            // Arrange
            var car = new Car(1, "ModelX", "Tesla", 10.5f, 50000);
            // Act
            var result = car.ToString();
            // Assert
            Assert.Equal("\t1\tModelX\t\tTesla\t10,5\t\t\t50000$", result);
        }


    }
}