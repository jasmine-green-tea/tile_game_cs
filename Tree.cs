using System;

public class Tree : Cell
{
    public Tree(int x, int y, string value, bool movable, bool crossable) :
        base(x, y, value, movable, crossable)
    {
    }

    public Tree(int x, int y) :
        base(x, y, "T", false, false)
    {
    }
}


