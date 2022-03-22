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
            new object[]{ new Coordinate(0, 0), OUT_OF_PLATFORM},
            new object[]{ new Coordinate(5, 5), OK_FOR_LANDING},
            new object[]{ new Coordinate(16, 15), OUT_OF_PLATFORM}

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
        var result = _landingService.RocektRequestLand(request);

        result.Should().NotBeNull();
        result.Should().Be(expectedOutput);
    }

     


}

