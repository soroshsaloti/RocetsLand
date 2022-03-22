namespace RocketsLand.Land;

using RocketsLand.InfoStruct;

public interface IRocket : ILanding
{

}
public sealed class Rocket : Landing, IRocket
{
    public override  int Size { get; protected set; }

    public override int Level { get; protected set; }


    public Rocket(int size, int level) : base()
    {
        Size = size;
        Level = level;
        Coordinate = new Coordinate(Size, Size);
        Land = new Square(this.Coordinate, Level);
    }

}
