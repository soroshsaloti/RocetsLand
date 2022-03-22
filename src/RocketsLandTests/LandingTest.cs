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

        landing.Size.Should().Be(100);
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

        landing.Size.Should().Be(10);
        landing.Level.Should().Be(5);
        landing.Coordinate.X.Should().Be(10);
        landing.Coordinate.Y.Should().Be(10); 
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
    [Fact]
    public void WhenLandIsRocket()
    {
        Landing landing = new Rocket(20,50);

        landing.Size.Should().Be(20);
        landing.Level.Should().Be(50);
        landing.Coordinate.X.Should().Be(20);
        landing.Coordinate.Y.Should().Be(20); 
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
}

