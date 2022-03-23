namespace RocketsLand;

using RocketsLand.InfoStruct;
using RocketsLand.Land;
using System;
public class LandingService
{ 
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
        if (_platform.FullSizeX > _area.Coordinate.X || _platform.FullSizeY > _area.Coordinate.Y)
            throw new ArgumentException("[ERROR]: the landing platform full size must be less than the landing area size");
    }

    public string RocektRequestLand(IRocket rocket)
    {
         return _platform.RocektRequestLand(rocket);
    }
   
    public string RocektRequestLand(int x, int y)
    {
        return RocektRequestLand( new Rocket(x, y) );
    }



}
