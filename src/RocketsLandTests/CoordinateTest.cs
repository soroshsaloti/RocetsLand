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
    [Fact]
    public void WhenCoordinateAdd()
    {
        Coordinate coordinate = new Coordinate(10, 30);
        var new1=coordinate.Add(1);
        new1.ToString().Should().Be("11,31");
        var new2 =new1.Add(-1);
        coordinate.Should().Be(new2);
    }
}
