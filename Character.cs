using System;

public class Character : Cell
{
    public Character(int x, int y, string value, bool movable, bool crossable) :
        base(x, y, value, movable, crossable)
    {
    }

    public Character(int x, int y) :
        base(x, y, "c", false, true)
    {
    }
}


