using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp2
{
    internal class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;
        public World(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);
                    Write(element);
                }
            }
        }
        public string GetElementsAt(int x, int y)
        {
        return Grid[y, x];
        }
        
        public bool IsPositionWalkable(int x, int y)
        {
           
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
           
            return Grid[y, x] == " " || Grid[y, x] == "X" || Grid[y, x] == "a" || Grid[y, x] == "b" || Grid[y, x] == "m";


        }
    }
}

