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
        IPlatform landing = new Platform(); 
        landing.Level.Should().Be(5);
        landing.Coordinate.X.Should().Be(10);
        landing.Coordinate.Y.Should().Be(10);
        landing.FullSizeX.Should().Be(15);
        landing.FullSizeY.Should().Be(15);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
    [Fact]
    public void WhenLandIsPlatformDynamic()
    {
        IPlatform landing = new Platform(new Coordinate(10,10));
        landing.Level.Should().Be(5);
        landing.Coordinate.X.Should().Be(10);
        landing.Coordinate.Y.Should().Be(10);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }
    [Fact]
    public void WhenLandIsRocket()
    {
        IRocket landing = new Rocket(20, 50); 
        landing.Level.Should().Be(1);
        landing.Coordinate.X.Should().Be(20);
        landing.Coordinate.Y.Should().Be(50);
        landing.FullSizeX.Should().Be(21);
        landing.FullSizeY.Should().Be(51);
        landing.Land.Should().NotBeNull();
        landing.Land.Name.Should().Be(landing.Coordinate.ToString());
    }

    [Theory]
    [MemberData(nameof(LandingServiceTests.testRequestTowRocket), MemberType = typeof(LandingServiceTests))]
    public void WhenRequestTowRocket(Coordinate requestFirst, string expectedOutputFirst,
       Coordinate requestSecond, string expectedOutputSecond)
    {
        IPlatform landing = new Platform(new Coordinate(10, 10));
        var result = landing.RocektRequestLand(new Rocket(requestFirst));
        result.Should().NotBeNull();
        result.Should().Be(expectedOutputFirst);

        result = landing.RocektRequestLand(new Rocket(requestSecond));
        result.Should().Be(expectedOutputSecond);
    }

    [Theory]
    [MemberData(nameof(LandingServiceTests.testRequest), MemberType = typeof(LandingServiceTests))]
    public void WhenRequest(Coordinate request, string expectedOutput)
    {
        IPlatform landing = new Platform(new Coordinate(10, 10));

        var result = landing.RocektRequestLand(new Rocket(request));

        result.Should().NotBeNull();
        result.Should().Be(expectedOutput);
    }

    [Fact]
    public void WhenRequestLastPostionSame()
    {
        IPlatform landing = new Platform(new Coordinate(10, 10));

        var result = landing.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().NotBeNull();
        result.Should().Be(LandingServiceTests.OK_FOR_LANDING);

        result = landing.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().Be(LandingServiceTests.CLASH);

    }

    [Fact]
    public void WhenRequestLastPostionLess()
    {
        IPlatform landing = new Platform(new Coordinate(10, 10));

        var result = landing.RocektRequestLand(new Rocket(new Coordinate(7, 7)));
        result.Should().NotBeNull();
        result.Should().Be(LandingServiceTests.OK_FOR_LANDING);

        result = landing.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().Be(LandingServiceTests.CLASH);

    }
}

