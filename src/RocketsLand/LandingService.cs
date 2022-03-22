namespace RocketsLand;
using RocketsLand.Land;
using System;
public class LandingService
{
    public readonly IArea _area;
    public readonly IPlatform _platform;

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


}
