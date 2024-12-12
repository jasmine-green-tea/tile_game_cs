using System;
using System.Collections.Generic;

public class Game
{
    // 0..9
    public int BorderLeftX = 0;
    public int BorderRightX = 9;
    // 0..9
    public int BorderTopY = 0;
    public int BorderBottomY = 9;

    List<Grass> grasses = new List<Grass>();
    List<Rock> rocks = new();
    List<Tree> treeses = new();
    Character player = new(5, 5);
    List<Plate> plates = new();

    List<Cell> cells = new List<Cell>();

    private bool move_cell = false;
    private Cell cell_to_move;
    bool character_in_place = false;

    public Game()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                grasses.Add(new Grass(x, y));
            }
        }

        rocks.Add(new Rock(5, 6));
        treeses.Add(new Tree(7, 7));
        plates.Add(new Plate(2, 2));
        plates.Add(new Plate(2, 3));

        cells.AddRange(grasses);
        cells.AddRange(rocks);
        cells.AddRange(treeses);
        cells.Add(player);
        cells.AddRange(plates);
    }

    public void Print()
    {
        Console.Clear();
        var field = new string[10, 10];

        foreach (var grass in grasses)
        {
            field[grass.X, grass.Y] = grass.Value;
        }

        foreach (var rock in rocks)
        {
            field[rock.X, rock.Y] = rock.Value;
        }

        foreach (var tree in treeses)
        {
            field[tree.X, tree.Y] = tree.Value;
        }

        bool swap = false;

        foreach (var plate in plates)
        {
            field[plate.X, plate.Y] = plate.Value;

            if (player.X == plate.X && player.Y == plate.Y)
            {
                field[plate.X, plate.Y] = "C";
                character_in_place = true;
                swap = true;
            }

            foreach (var rock in rocks)
            {
                if (rock.X == plate.X && rock.Y == plate.Y)
                {
                    field[plate.X, plate.Y] = "R";
                }
            }
        }

        if (!swap)
            character_in_place = false;

        if (!character_in_place)
            field[player.X, player.Y] = player.Value;

        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                Console.Write(field[y, x] + " ");
            }
            Console.WriteLine();
        }

    }

    public bool CanIMoveCharacter(int x, int y)
    {
        int targetX = player.X + x;
        int targetY = player.Y + y;

        bool flag = true;

        foreach (var cell in cells)
        {
            if (cell.X == targetX && cell.Y == targetY)
            {
                if (cell.IsMovable)
                {
                    cell_to_move = cell;
                    move_cell = true;
                }
                if (!cell.IsMovable && !cell.IsCrossable)
                {
                    flag = false;
                    cell_to_move = null;
                    move_cell = false;
                }
                
            }
        }

        if (move_cell)
        {
            foreach (var cell in cells)
            {
                if ((cell.X == targetX + x) && (cell.Y == targetY + y))
                {
                    if (!cell.IsCrossable)
                    {
                        flag = false;
                        cell_to_move = null;
                        move_cell = false;
                    }
                }
            }
        }
        

        return flag;
    }

    public void MoveCharacter(int x, int y)
    {
        
        

        int topLimit = 10;
        int bottomLimit = -1;

        if (move_cell)
        {
            topLimit--;
            bottomLimit++;
        }

        player.X += x;
        player.Y += y;

        bool reset = false;

        if ((player.X == topLimit) && (x != 0))
        {
            reset = true;
            player.X--;
        }
        if ((player.X == bottomLimit) && (x != 0))
        {
            reset = true;
            player.X++;
        }
        if ((player.Y == topLimit) && (y != 0))
        {
            reset = true;
            player.Y--;
        }
        if ((player.Y == bottomLimit) && (y != 0))
        {
            reset = true;
            player.Y++;
        }


        
        if (move_cell && !reset)
        {
            cell_to_move.X += x;
            cell_to_move.Y += y;
        }

        cell_to_move = null;
        move_cell = false;



    }

    public void Run()
    {
        while (true)
        {
            Print();
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (CanIMoveCharacter(-1, 0))
                    {
                        MoveCharacter(-1, 0);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CanIMoveCharacter(1, 0))
                    {
                        MoveCharacter(1, 0);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (CanIMoveCharacter(0, -1))
                    {
                        MoveCharacter(0, -1);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CanIMoveCharacter(0, 1))
                    {
                        MoveCharacter(0, 1);
                    }
                    break;
            }

        }
    }
}