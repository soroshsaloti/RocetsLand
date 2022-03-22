namespace RocketsLandTests;

using AutoFixture;
using FluentAssertions;
using RocketsLand.InfoStruct;
using RocketsLand.Land;
using Xunit;

public class SquareTests
{
    [Fact]
    public void WhenHappySquare()
    {
        var fixture = new Fixture();
        var coordinate = fixture.Create<Coordinate>();
        var square = new Square(coordinate, 10);
        square.Should().NotBeNull();
        square.Name.Should().Be(coordinate.ToString());
        square.Coordinate.Should().Be(coordinate);
    }
}

