namespace RocketsLandTests;

using FluentAssertions;
using RocketsLand;
using RocketsLand.Land;
using System;
using Xunit;

public class LandingServiceTests
{
    public readonly IArea _area;
    public readonly IPlatform _platform;
    public readonly LandingService _landingService;  

    public LandingServiceTests()
    {
        _area = new Area();
        _platform = new Platform();
        _landingService =  new LandingService(_area, _platform);
    }

    [Fact]
    public void WhenHappyLand()
    {
        var landingService= new LandingService(_area, _platform);
        landingService._platform.Should().NotBeNull();
        landingService._area.Should().NotBeNull();
    }

    [Fact]
    public void WhenLandPlatformNull()
    {
        Assert.Throws<ArgumentException>(()=>{ _ = new LandingService(_area,  null); });
    }

    [Fact]
    public void WhenLandAreaNull()
    {
        Assert.Throws<ArgumentException>(() => { _ = new LandingService(null, _platform); });
    }


    [Fact]
    public void WhenLandPlatforFullSizeBiggerThanAreaSize()
    {
        Assert.Throws<ArgumentException>(() => { _ = new LandingService(_area, new Platform(100,500)); });
    }
}

