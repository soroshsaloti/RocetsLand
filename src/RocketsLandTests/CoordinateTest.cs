namespace RocketsLandTests;

using FluentAssertions;
using RocketsLand;
using RocketsLand.InfoStruct;
using Xunit;
public class CoordinateTest
{
    [Fact]
    public void WhenCoordinateToString()
    {
        Coordinate coordinate = new Coordinate ( 10, 30 );
        coordinate.ToString().Should().Be("10,30");
    }
}
