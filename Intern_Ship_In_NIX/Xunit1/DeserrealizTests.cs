using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.Models.Objects;
using Transport.Serserrealization;
using Transport.TransfonrmOnFile;

namespace Xunit1
{



    public class DeserrealizTests
    {
        [Fact]
        public void DeserrealizationXML_ShouldReturnListOfObjects_WhenXMLIsValid()
        {
            // Arrange
            string xmlPath = "cars.xml";

            File.WriteAllText(xmlPath, @"
            <ArrayOfCar xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                <Car>
                    <Id>1</Id>
                    <Model>ModelX</Model>
                    <Brand>Tesla</Brand>
                    <FuelConsumption>10.5</FuelConsumption>
                    <Price>20000</Price>
                </Car>
                <Car>
                    <Id>2</Id>
                    <Model>i8</Model>
                    <Brand>BMW</Brand>
                    <FuelConsumption>8.2</FuelConsumption>
                    <Price>45000</Price>
                </Car>
            </ArrayOfCar>");
            var deserrealiz = new Deserrealiz<Car>();
            // Act
            var result = deserrealiz.DeserrealizationXML(xmlPath);
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("ModelX", result[0].Model);
            Assert.Equal("BMW", result[1].Brand);
            // Clean up
            File.Delete(xmlPath);
        }

        [Fact]
        public void Load_ShouldReturnCorrectList_WhenXMLFileIsValid()
        {
            // Arrange
            string path = "cars.xml";

            File.WriteAllText(path, @"
            <ArrayOfCar xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
                <Car>
                    <Id>1</Id>
                    <Model>ModelX</Model>
                    <Brand>Tesla</Brand>
                    <FuelConsumption>10.5</FuelConsumption>
                    <Price>50000</Price>
                </Car>
            </ArrayOfCar>");
            var transform = new TransformOnFile<Car>();
            // Act
            var result = transform.Load(path, new Car());
            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("ModelX", result[0].Model);
            // Clean up
            File.Delete(path);
        }

    }
}
