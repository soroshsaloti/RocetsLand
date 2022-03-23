namespace RocketsLandTests;

using FluentAssertions;
using RocketsLand;
using RocketsLand.InfoStruct;
using RocketsLand.Land;
using System;
using System.Collections.Generic;
using Xunit;

public class LandingServiceTests
{

    public static readonly IEnumerable<object[]> testRequest = new[]
    {
            new object[]{ new Coordinate(0, 0),Platform.OK_FOR_LANDING},
            new object[]{ new Coordinate(5, 5), Platform.OK_FOR_LANDING},
            new object[]{ new Coordinate(16, 15), Platform.OUT_OF_PLATFORM}

    };

    public static readonly IEnumerable<object[]> testRequestTowRocket = new[]
    {
            new object[]{ new Coordinate(7, 7), Platform.OK_FOR_LANDING,new Coordinate(7, 8), Platform.CLASH},
            new object[]{ new Coordinate(7, 7), Platform.OK_FOR_LANDING,new Coordinate(6, 7), Platform.CLASH},
            new object[]{ new Coordinate(7, 7), Platform.OK_FOR_LANDING,new Coordinate(6, 6), Platform.CLASH},
            new object[]{ new Coordinate(5, 5), Platform.OK_FOR_LANDING,new Coordinate(5, 5), Platform.CLASH}
    };


    public readonly IArea _area;
    public readonly IPlatform _platform;
    public readonly LandingService _landingService;

    public LandingServiceTests()
    {
        _area = new Area();
        _platform = new Platform();
        _landingService = new LandingService(_area, _platform);
    }

    [Fact]
    public void WhenHappyLand()
    {
        var landingService = new LandingService(_area, _platform);
        landingService.Should().NotBeNull();
    }

    [Fact]
    public void WhenLandPlatformNull()
    {
        Assert.Throws<ArgumentException>(() => { _ = new LandingService(_area, null); });
    }

    [Fact]
    public void WhenLandAreaNull()
    {
        Assert.Throws<ArgumentException>(() => { _ = new LandingService(null, _platform); });
    }


    [Fact]
    public void WhenLandPlatforFullSizeBiggerThanAreaSize()
    {
        Assert.Throws<ArgumentException>(() => { _ = new LandingService(_area, new Platform(100, 500)); });
    }

    [Theory]
    [MemberData(nameof(LandingServiceTests.testRequest), MemberType = typeof(LandingServiceTests))]
    public void WhenRequest(Coordinate request, string expectedOutput)
    {
        var result = _landingService.RocektRequestLand(new Rocket(request));

        result.Should().NotBeNull();
        result.Should().Be(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(LandingServiceTests.testRequestTowRocket), MemberType = typeof(LandingServiceTests))]
    public void WhenRequestTowRocket(Coordinate requestFirst, string expectedOutputFirst,
        Coordinate requestSecond, string expectedOutputSecond)
    {

        var result = _landingService.RocektRequestLand(new Rocket(requestFirst));
        result.Should().NotBeNull();
        result.Should().Be(expectedOutputFirst);

        result = _landingService.RocektRequestLand(new Rocket(requestSecond));
        result.Should().Be(expectedOutputSecond);
    }

    [Fact]
    public void WhenRequestLastPostionSame()
    {
        var result = _landingService.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().NotBeNull();
        result.Should().Be(Platform.OK_FOR_LANDING);

        result = _landingService.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().Be(Platform.CLASH);

    }

    [Fact]
    public void WhenRequestLastPostionLess()
    {
        var result = _landingService.RocektRequestLand(new Rocket(new Coordinate(7, 7)));
        result.Should().NotBeNull();
        result.Should().Be(Platform.OK_FOR_LANDING);

        result = _landingService.RocektRequestLand(new Rocket(new Coordinate(5, 5)));
        result.Should().Be(Platform.CLASH);

    }



}

