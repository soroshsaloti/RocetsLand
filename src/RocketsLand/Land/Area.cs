namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public class Area : Landing
{

    public override int Size { get; protected set; } = 100;

    public override int Level { get; protected set; } = 1;

    public Area() : base()
    {

    }
}
