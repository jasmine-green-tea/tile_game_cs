using System;

public class Plate : Cell
{
    public Plate(int x, int y, string value, bool movable, bool crossable) :
        base(x, y, value, movable, crossable)
    {
    }

    public Plate(int x, int y) :
        base(x, y, "O", false, true)
    {
    }
}


