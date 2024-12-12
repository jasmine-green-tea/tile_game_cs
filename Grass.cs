using System;

public class Grass : Cell
{
	public Grass(int x, int y, string value, bool movable, bool crossable) :
		base(x, y, value, movable, crossable)
	{
	}

	public Grass(int x, int y) :
		base(x, y, "#", false, true)
	{
	}
}
