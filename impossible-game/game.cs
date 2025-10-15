using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impossible_game
{
    public class Game
    {
        private Board board;

        public Game(Board board) =>
            this.board = board;

        public void Run()
        {
            while (!board.IsGameOver)
            {
                board.Print();
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow) board.MoveSnake(0, -1);
                else if (key == ConsoleKey.DownArrow) board.MoveSnake(0, 1);
                else if (key == ConsoleKey.LeftArrow) board.MoveSnake(-1, 0);
                else if (key == ConsoleKey.RightArrow) board.MoveSnake(1, 0);
            }
            board.Print();

            Console.WriteLine();
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
