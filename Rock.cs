using System;

public class Rock : Cell
{
	public Rock(int x, int y, string value, bool movable, bool crossable) :
		base(x, y, value, movable, crossable)
	{
	}

	public Rock(int x, int y) :
		base(x, y, "r", true, false)
	{
	}
}

