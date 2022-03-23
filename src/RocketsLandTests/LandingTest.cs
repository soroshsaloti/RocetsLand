namespace RocketsLandTests;

using FluentAssertions;
using RocketsLand.InfoStruct;
using RocketsLand.Land;
using Xunit;
public class LandingTest
{
    [Fact]
    public void WhenLandIsArea()
    {
        Landing landing = new Area();
        landing.Level.Should().Be(1);
        landing.Coordinate.X.Should().Be(100);
        landing.Coordinate.Y.Should().Be(100);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }

    [Fact]
    public void WhenLandIsPlatform()
    {
        Landing landing = new Platform(); 
        landing.Level.Should().Be(5);
        landing.Coordinate.X.Should().Be(10);
        landing.Coordinate.Y.Should().Be(10);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
    [Fact]
    public void WhenLandIsPlatformDynamic()
    {
        Landing landing = new Platform(new Coordinate(10,10));
        landing.Level.Should().Be(5);
        landing.Coordinate.X.Should().Be(10);
        landing.Coordinate.Y.Should().Be(10);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
    [Fact]
    public void WhenLandIsRocket()
    {
        Landing landing = new Rocket(20, 50); 
        landing.Level.Should().Be(1);
        landing.Coordinate.X.Should().Be(20);
        landing.Coordinate.Y.Should().Be(50);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
}

