namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public interface IPlatform : ILanding
{
    IRocket PreviousPosition { get; }
    int FullSizeX { get; }
    int FullSizeY { get; }
    string RocektRequestLand(IRocket rocket);
}
public sealed class Platform : Landing, IPlatform
{
    private const string OK_FOR_LANDING = "ok for landing";
    private const string OUT_OF_PLATFORM = "out of platform";
    private const string CLASH = "clash";

    public override int Level { get; protected set; }

    public IRocket PreviousPosition { get; private set; }
    public int FullSizeX => Coordinate.X + Level;
    public int FullSizeY => Coordinate.Y + Level;

    public Platform(int x = 10, int y = 10, int level = 5) : this(new Coordinate(x, y), level)
    {
    }

    public Platform(Coordinate coordinate, int level = 5)
    {
        PreviousPosition = new Rocket();
        Coordinate = coordinate;
        Level = level;
        Land = new Square(this.Coordinate, Level);
    }

    public string RocektRequestLand(IRocket rocket)
    {
        var retVal = string.Empty;
        if (PreviousPosition.Level == 0 && IsCoordinateCrash(rocket))
            retVal = CLASH;
        else if (IsCoordinateOk(rocket))
            retVal = OK_FOR_LANDING;
        else
            retVal = OUT_OF_PLATFORM;

        PreviousPosition = new Rocket(rocket.Coordinate);
        return retVal;
    }


    private bool IsCoordinateOk(IRocket rocket)
    {
        return this.Coordinate.X >= rocket.Coordinate.X &&
             this.Coordinate.Y >= rocket.Coordinate.Y;

    }

    private bool IsCoordinateCrash(IRocket rocket)
    {
        return this.Coordinate.X >= rocket.Coordinate.X &&
             this.Coordinate.Y >= rocket.Coordinate.Y &&
            ( this.PreviousPosition.Coordinate.X >= rocket.FullSizeX - 1 ||
             this.PreviousPosition.Coordinate.Y >= rocket.FullSizeY - 1 );
    }
}

