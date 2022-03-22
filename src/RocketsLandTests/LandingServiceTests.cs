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
    private const string OK_FOR_LANDING = "ok for landing";
    private const string OUT_OF_PLATFORM = "out of platform";
    private const string CLASH = "clash";

    public static readonly IEnumerable<object[]> testRequest = new[]
    {
            new object[]{ new Coordinate(0, 0), OK_FOR_LANDING},
            new object[]{ new Coordinate(5, 5), OK_FOR_LANDING},
            new object[]{ new Coordinate(16, 15), OUT_OF_PLATFORM}

    };

    public static readonly IEnumerable<object[]> testRequestTowRocket = new[]
    {
            new object[]{ new Coordinate(7, 7), OK_FOR_LANDING,new Coordinate(7, 8), CLASH},
            new object[]{ new Coordinate(7, 7), OK_FOR_LANDING,new Coordinate(6, 7), CLASH},
            new object[]{ new Coordinate(7, 7), OK_FOR_LANDING,new Coordinate(6, 6), CLASH},
            new object[]{ new Coordinate(5, 5), OK_FOR_LANDING,new Coordinate(5, 5), CLASH}
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
        var result = _landingService.RocektRequestLand(new Platform(request));

        result.Should().NotBeNull();
        result.Should().Be(expectedOutput);
    }

    [Theory]
    [MemberData(nameof(LandingServiceTests.testRequestTowRocket), MemberType = typeof(LandingServiceTests))]
    public void WhenRequestTowRocket(Coordinate requestFirst, string expectedOutputFirst, 
        Coordinate requestSecond, string expectedOutputSecond)
    {

        var result = _landingService.RocektRequestLand(new Platform(requestFirst));
        result.Should().NotBeNull();
        result.Should().Be(expectedOutputFirst);

        result = _landingService.RocektRequestLand(new Platform(requestSecond));
        result.Should().Be(expectedOutputSecond);
    }

    [Fact]
    public void WhenRequestLastPostionSame()
    {
        var result = _landingService.RocektRequestLand(new Platform(new Coordinate(5, 5)));
        result.Should().NotBeNull();
        result.Should().Be(OK_FOR_LANDING);

        result = _landingService.RocektRequestLand(new Platform(new Coordinate(5, 5)));
        result.Should().Be(CLASH);

    }

    [Fact]
    public void WhenRequestLastPostionLess()
    {
        var result = _landingService.RocektRequestLand(new Platform(new Coordinate(7, 7)));
        result.Should().NotBeNull();
        result.Should().Be(OK_FOR_LANDING);

        result = _landingService.RocektRequestLand(new Platform(new Coordinate(7, 8)));
        result.Should().Be(CLASH);

    }



}

