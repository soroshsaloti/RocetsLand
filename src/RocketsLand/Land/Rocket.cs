namespace RocketsLand.Land;

using RocketsLand.InfoStruct;

public interface IRocket : ILanding
{
    int FullSizeX { get; }
    int FullSizeY { get; }
}
public sealed class Rocket : Landing, IRocket
{
    public int FullSizeX => Coordinate.X + Level;
    public int FullSizeY => Coordinate.Y + Level;

    public override int Level { get; protected set; }


    public Rocket(int x , int y ) : this(new Coordinate(x, y))
    {
    }

    public Rocket(Coordinate coordinate)
    {
        Coordinate = coordinate;
        Level = 1;
        Land = new Square(this.Coordinate, 1);
    }
}
