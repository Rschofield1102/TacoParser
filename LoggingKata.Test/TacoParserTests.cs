using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();
            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            //Assert
            Assert.NotNull(actual);
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.784434,-84.771556,Taco Bell Chatswort...", -84.771556)]
        [InlineData("32.524378,-84.88839,Taco Bell Columbus...", -84.88839)]
        [InlineData("31.236691,-85.459825,Taco Bell Dothan...", -85.459825)]
        [InlineData("31.935914,-87.737701,Taco Bell Thomasville...", -87.737701)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange
            var tacoS = new TacoParser();
            //Act
            var actual = tacoS.Parse(line);
            //Assert
            Assert.Equal(expected,actual.Location.Longitude) ;
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.764965, -86.48607, Taco Bell Huntsvill..", 34.764965)]
        [InlineData("34.7348,-86.633875,Taco Bell Huntsville...", 34.7348)]
        [InlineData("30.417628,-86.653669,Taco Bell Mary Esthe..", 30.417628)]
        [InlineData("30.349378, -87.266033, Taco Bell Pensacol...", 30.349378)]
        [InlineData("30.459515,-84.35516,Taco Bell Tallahassee...", 30.459515)]
        [InlineData("724109,-84.937891,Taco Bell Villa Ric...", 724109)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoS = new TacoParser();
            //Act
            var actual = tacoS.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }
    }
}
