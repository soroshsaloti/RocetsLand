namespace RocketsLand.InfoStruct;
public abstract class Landing : ILanding
{
    public abstract int Level { get; protected set; }

    public Square Land { get; protected set; }

    public Coordinate Coordinate { get; protected set; }
 
}
