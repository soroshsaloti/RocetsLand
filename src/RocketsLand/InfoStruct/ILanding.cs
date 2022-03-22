namespace RocketsLand.InfoStruct;
public interface ILanding
{
    Coordinate Coordinate { get; }
    Square Land { get; }
    int Level { get; }
    int Size { get; }
}

