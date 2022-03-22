namespace RocketsLand.Land;

using RocketsLand.InfoStruct;

public  class Rocket : Landing
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
