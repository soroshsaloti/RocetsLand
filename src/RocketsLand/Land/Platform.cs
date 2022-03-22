namespace RocketsLand.Land;
using RocketsLand.InfoStruct;

public class Platform : Landing
{
    public override int Size { get; protected set; } = 10;

    public override int Level { get; protected set; } = 5;

    public Platform() : base()
    {
    }
}

