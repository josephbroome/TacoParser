using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {

            
            var tacoParser = new TacoParser();

            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.00,0,taco bell",0)]
        [InlineData ("34.047374,-84.223918,Taco Bell Alpharetta...",-84.223918)]
       
       
        public void ShouldParseLongitude(string line, double? expected)
        {
            
            var longtitude = new TacoParser();

            
            var actual=longtitude.Parse(line).Location.Longitude;
           
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", 32.571331)]
        [InlineData("33.59453,-86.694742,Taco Bell Birmingham...", 33.59453)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var latitude= new TacoParser();

            var actual =latitude.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }

        

    }
}
