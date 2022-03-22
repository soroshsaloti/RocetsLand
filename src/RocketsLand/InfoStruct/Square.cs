namespace RocketsLand.InfoStruct;
public struct Square
{
    private readonly Coordinate _coordinate;
    private readonly string _name;
    private readonly int _level;

    public Coordinate Coordinate { get { return _coordinate; } }
    public string Name { get { return _name; } }
    public int Level { get { return _level; } }
    public Square(Coordinate coordinate, int level)
    {
        _coordinate = coordinate;
        _level = level;
        _name = _coordinate.ToString();
    }

}
