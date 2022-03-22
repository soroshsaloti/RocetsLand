﻿namespace RocketsLand.InfoStruct;
public abstract class Landing
{
    public abstract int Size { get; protected set; }

    public abstract int Level { get; protected set; }

    public Square Land { get; protected set; }

    public Coordinate Coordinate { get; protected set; } 
    
}
