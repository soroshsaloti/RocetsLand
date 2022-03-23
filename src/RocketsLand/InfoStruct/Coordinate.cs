using System.Diagnostics.CodeAnalysis;

namespace RocketsLand.InfoStruct;
public struct Coordinate
{
    public readonly int X;
    public readonly int Y;

    public Coordinate(int X, int Y) { this.X = X; this.Y = Y; }

    public override string ToString() => $"{X},{Y}"; 

    public Coordinate Add(int n)
    {
        var x = this.X + n;
        var y = this.Y + n;
        return new Coordinate(x, y);
    }
     
}
