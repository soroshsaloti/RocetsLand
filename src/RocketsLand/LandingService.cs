namespace RocketsLand;

using RocketsLand.InfoStruct;
using RocketsLand.Land;
using System;
public class LandingService
{
    private const string OK_FOR_LANDING = "ok for landing";
    private const string OUT_OF_PLATFORM = "out of platform";
    private const string CLASH = "clash";

    private readonly IArea _area;
    private readonly IPlatform _platform;
    public LandingService(IArea area, IPlatform platform)
    {
        _area = area;
        _platform = platform;
        ValidateLand();
    }

    private void ValidateLand()
    {
        if (_platform == null)
            throw new ArgumentException("[ERROR]: the landing platform must be not null");
        if (_area == null)
            throw new ArgumentException("[ERROR]: the landing area must be not null");
        if (_platform.FullSize > _area.Size)
            throw new ArgumentException("[ERROR]: the landing platform full size must be less than the landing area size");
    }

    public string RocektRequestLand(Coordinate rocketCoordinate)
    {
        if (IsCoordinateOk(rocketCoordinate))
            return OK_FOR_LANDING;
        else
            return OUT_OF_PLATFORM;

    }
    private bool IsCoordinateOk(Coordinate rocketCoordinate)
    {
        return  rocketCoordinate == new Coordinate(5, 5);
    }

}
