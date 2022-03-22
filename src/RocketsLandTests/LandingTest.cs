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
    }

    [Fact]
    public void WhenLandIsPlatform()
    {
        Landing landing = new Platform();

        landing.Size.Should().Be(10);
        landing.Level.Should().Be(5);
    }
    [Fact]
    public void WhenLandIsRocket()
    {
        Landing landing = new Rocket(20,50);

        landing.Size.Should().Be(20);
        landing.Level.Should().Be(50);
    }
}

