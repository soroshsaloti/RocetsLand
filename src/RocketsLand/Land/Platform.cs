namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public interface IPlatform : ILanding
{
  int FullSize { get; }
}
public sealed class Platform : Landing, IPlatform
{
    public override int Size { get; protected set; }

    public override int Level { get; protected set; }

    public int FullSize => Size+Level;

    public Platform(int size = 10, int level = 5)
    {
        Size = size;
        Level = level;
        Coordinate = new Coordinate(Size, Size);
        Land = new Square(this.Coordinate, Level);
    }
}

