namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public interface IArea : ILanding {
}
public sealed class Area : Landing, IArea 
{

    public override int Size { get; protected set; } = 100;

    public override int Level { get; protected set; } = 1;

    public Area() : base()
    {
        Coordinate = new Coordinate(Size, Size);
        Land = new Square(this.Coordinate, Level);
    }
}
