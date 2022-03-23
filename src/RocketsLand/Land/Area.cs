namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public interface IArea : ILanding
{
}
public sealed class Area : Landing, IArea
{
    public override int Level { get; protected set; } = 1; 

    public Area() : base()
    {
        Coordinate = new Coordinate(100, 100);
        Land = new Square(this.Coordinate, Level);
    }
}
