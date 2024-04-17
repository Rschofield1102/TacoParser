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
