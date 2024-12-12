using System;


public class Cell
{
	public int X;
	public int Y;
	public string Value;
	public bool IsMovable;
	public bool IsCrossable;

	public Cell(int x, int y, string value, bool movable, bool crossable)
	{
		X = x;
		Y = y;
		Value = value;
		IsMovable = movable;
		IsCrossable = crossable;
	}
}
