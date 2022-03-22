using System.Diagnostics.CodeAnalysis;

namespace RocketsLand.InfoStruct;
public struct Coordinate
{
    public readonly int X;
    public readonly int Y;

    public Coordinate(int X, int Y) { this.X = X; this.Y = Y; }

    public override string ToString() => $"{X},{Y}";

    public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode();

    public Coordinate Add(int n)
    {
        var x = this.X + n;
        var y = this.Y + n;
        return new Coordinate(x, y);
    }
    public static bool operator ==(Coordinate? left, Coordinate? right)
    {
        if (left is null)
        {
            if (right is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return left.Equals(right);
    }

    public static bool operator !=(Coordinate? left, Coordinate? right)
    {
        if (left is null)
        {
            if (right is null)
            {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // Equals handles case of null on right side.
        return !left.Equals(right);
    }

    public override bool Equals([NotNullWhen(true)] object? obj) => this.Equals(obj as Coordinate?);

    public bool Equals(Coordinate? c)
    {
        if (c is null)
        {
            return false;
        }

        if (Object.ReferenceEquals(this, c))
        {
            return true;
        }

        if (this.GetType() != c.GetType())
        {
            return false;
        }

        return ( X == c?.X ) && ( Y == c?.Y );
    }

}
