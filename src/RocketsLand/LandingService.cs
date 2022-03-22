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
    private IPlatform _previousPosition;
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

    public string RocektRequestLand(IPlatform rocket)
    {
         
        var retVal = string.Empty;
        if (_previousPosition != null && IsCoordinateCrash(rocket))
            retVal = CLASH;
       else if (IsCoordinateOk(rocket))
            retVal = OK_FOR_LANDING;
        else
            retVal = OUT_OF_PLATFORM;

        _previousPosition = new Platform(rocket.Coordinate.Add(-1));
        return retVal;
    }
    private bool IsCoodinate(Coordinate rocketCoordinate, IPlatform platform)
    {
        return rocketCoordinate.X <= platform.Coordinate.X &&
             rocketCoordinate.Y <= platform.Coordinate.Y &&
             rocketCoordinate.X <= platform.Coordinate.X + platform.Level - 1 &&
             rocketCoordinate.Y <= platform.Coordinate.Y + platform.Level - 1;
    }
    private bool IsCoordinateOk(IPlatform rocket)
    {
        return IsCoodinate(rocket.Coordinate, _platform);
    }

    private bool IsCoordinateCrash(IPlatform rocket)
    {
        return IsCoodinate( _previousPosition.Coordinate, rocket);
    }

   

}
