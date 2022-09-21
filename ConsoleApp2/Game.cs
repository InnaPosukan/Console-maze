using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp2
{
    internal class Game
    {
        private World MyWorld;
        private Player CurrentPlayer;

       
        public void Start()
        {
           
            string[,] grid = {
             
                { " ", " ", "a", "=", " ", "=", "=",  "="},
                { " ", "=", "=", "b", "=", "=", "=",  " "},
                { " ", "m", "=", " ", " ", "=", "=",  "="},
                { " ", "A", "=", " ", " ", " ", " ",  "="},
                { "=", " ", " ", "m", " ", "=", "B",  "X"},
                { "=", "=", " ", " ", " ", "m", " ",  "="},
            };
            MyWorld = new World(grid);

            CurrentPlayer = new Player(0, 0);



            RunGameLoop();

          
        }
        private void DisplayIntro()
        {
            WriteLine("Press any key to start...");
            WriteLine("m - bomb");
            WriteLine("a - key from door A , b - key from door B");
            WriteLine("You finish this game");
            WriteLine("Press any key to start...");

           
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void GetA()
        {
            string[,] grid = {

                { " ", " ", " ", "=", " ", "=", "=",  "="},
                { " ", "=", "=", "b", "=", "=", "=",  " "},
                { " ", "m", "=", " ", " ", "=", "=",  "="},
                { " ", " ", "=", " ", " ", " ", " ",  "="},
                { "=", " ", " ", "m", " ", "=", "B",  "X"},
                { "=", "=", " ", " ", " ", "m", " ",  "="},
            };
            MyWorld = new World(grid);
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void GetB()
        {
            string[,] grid = {

                { " ", " ", " ", "=", " ", "=", "=",  "="},
                { " ", "=", "=", " ", "=", "=", "=",  " "},
                { " ", "m", "=", " ", " ", "=", "=",  "="},
                { " ", " ", "=", " ", " ", " ", " ",  "="},
                { "=", " ", " ", "m", " ", "=", " ",  "X"},
                { "=", "=", " ", " ", " ", "m", " ",  "="},
            };
            MyWorld = new World(grid);
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKeyInfo keyInfo = ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;

                    }

                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }

                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {

                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }

                    break;
                case ConsoleKey.W:
                    {
                        if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                        {
                            CurrentPlayer.Y -= 1;

                        }
                        break;
                    }

                case ConsoleKey.S:
                    {
                        if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                        {
                            CurrentPlayer.Y += 1;

                        }
                        break;
                    }
                         case ConsoleKey.A:
                    {
                        if (MyWorld.IsPositionWalkable(CurrentPlayer.X-1, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X -= 1;

                        }
                        break;
                    }

                        case ConsoleKey.D:
                    {
                        if (MyWorld.IsPositionWalkable(CurrentPlayer.X+1, CurrentPlayer.Y))
                        {
                            CurrentPlayer.X += 1;

                        }
                        break;


                    }
                default:
                    break;
            }

        }
        private void RunGameLoop()
        {
            DisplayIntro();
            while (true)
            {
                DrawFrame();
                HandlePlayerInput();
                string elementsAtPlayerPos = MyWorld.GetElementsAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementsAtPlayerPos == "X")
                {
                    Clear();
                    WriteLine("You finish this game");
                    WriteLine("Press ENTER to exit...");
                    ReadLine();
                    break;
                }
                else if (elementsAtPlayerPos == "a")
                {
                    GetA();
                    
                }
                else if (elementsAtPlayerPos == "b")
                {
                    GetB();

                }
                else if (elementsAtPlayerPos == "m")
                {
                    Clear();
                    WriteLine("GAMEOVER! MINA!");
                    WriteLine("Press ENTER to exit...");
                    ReadLine();
                    break;

                }

                System.Threading.Thread.Sleep(20);

            }
        }
    }
}
