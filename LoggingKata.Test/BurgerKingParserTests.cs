using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoggingKata.Test
{
   public class BurgerKingParserTests
   {
        
        
        [Theory]
        [InlineData("-149.95032, 61.13782, BurgerKing - Anchorage", 61.13782)]
        [InlineData("34.00,0,Buger King", 0)]
        [InlineData("-149.12048,61.59984,BurgerKing-Palmer", 61.59984)]


        public void ShouldParseLongitude(string line, double? expected)
        {

            var longtitude = new BurgerKingParser();


            var actual = longtitude.Parse(line).Location.Longitude;

            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData("149.81281,61.21526,BurgerKing-Anchorage", 149.81281)]
        [InlineData("-86.73055,33.55953,BurgerKing-Birmingham", -86.73055)]
        public void ShouldParseLatitude(string line, double expected)
        {
            var latitude = new BurgerKingParser();

            var actual = latitude.Parse(line).Location.Latitude;

            Assert.Equal(expected, actual);
        }




    }
}
