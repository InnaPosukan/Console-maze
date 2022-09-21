using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp2
{
    internal class Player
    { 
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarket;
        private ConsoleColor PlayerColor;
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarket = "O";
            PlayerColor = ConsoleColor.Red;   

        }
        public void Draw()
        {
            ForegroundColor = PlayerColor;
            SetCursorPosition(X, Y);
            Write(PlayerMarket);
            ResetColor();


        }
    }
}
