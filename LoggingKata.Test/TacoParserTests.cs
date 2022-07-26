using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.00,0,taco bell",0)]
       
       
        public void ShouldParseLongitude(string line, double? expected)
        {
            // TODO: Complete - "line" represents input data we will Parse to
            //       extract the Longitude.  Your .csv file will have many of these lines,
            //       each representing a TacoBell location

            //Arrange
            var longtitude = new TacoParser();

            //Act
            var actual=longtitude.Parse(line).Location.Longitude;
            //Assert
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", 32.571331)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var latitude= new TacoParser();

            var actual =latitude.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }
        //TODO: Create a test ShouldParseLatitude

    }
}
