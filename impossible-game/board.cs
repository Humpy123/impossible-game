using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace impossible_game
{
    public class Board
    {
        private int width;
        private int height;
        private ICell[,] cells;
        private Snake snake;
        private Random random = new Random();

        public Board(int width, int height)
        {
            this.width = width;
            this.height = height;
            cells = new ICell[width, height];
            snake = new Snake(width / 2, height / 2);

            // Initialize all cells as empty
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    cells[x, y] = new Empty();

            // Add walls around the perimeter
            for (int x = 0; x < width; x++)
            {
                cells[x, 0] = new Wall();         // Top wall
                cells[x, height - 1] = new Wall(); // Bottom wall
            }
            for (int y = 0; y < height; y++)
            {
                cells[0, y] = new Wall();         // Left wall
                cells[width - 1, y] = new Wall();  // Right wall
            }
        }

        public List<(int x, int y)> GetEmptyPositions()
        {
            var emptyPositions = new List<(int x, int y)>();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    if (cells[x, y] is Empty && !snake.IsAt(x, y))
                        emptyPositions.Add((x, y));

            return emptyPositions;
        }

        public void Print()
        {
            Console.Clear();
            Console.WriteLine("Snake Game - Use arrows to move");
            Console.WriteLine();

            void Print(string text, ConsoleColor color)
            {
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ResetColor();
            }

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (snake.IsAt(x, y))
                        Print(snake.IsAlive ? "●" : "X", ConsoleColor.Green);
                    else
                    {
                        var cell = cells[x, y];
                        Print(cell.Symbol.ToString(), cell.Color);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Print("●", ConsoleColor.Green);
            Console.WriteLine(" = Snake");
            Print("•", ConsoleColor.Red);
            Console.WriteLine(" = Apple");
            Print("▓", ConsoleColor.Gray);
            Console.WriteLine(" = Wall");
            Print("·", ConsoleColor.Gray);
            Console.WriteLine(" = Empty");
        }

        public bool IsGameOver => !snake.IsAlive;

        public void SetCell(int x, int y, ICell obj)
        {
            if (x >= 0 && x < width && y >= 0 && y < height)
                cells[x, y] = obj;
        }

        public void SetCurrentCell(ICell cell) =>
            SetCell(snake.Head.x, snake.Head.y, cell);

        public void SetRandomCell(ICell cell)
        {
            var emptyPositions = GetEmptyPositions();
            if (emptyPositions.Count > 0)
            {
                var randomIndex = random.Next(emptyPositions.Count);
                var (x, y) = emptyPositions[randomIndex];
                SetCell(x, y, cell);
            }
        }

        public void MoveSnake(int dx, int dy)
        {
            snake.Move(dx, dy);
            var currentCell = cells[snake.Head.x, snake.Head.y];
            currentCell.OnEnter(this);
        }

        public void GrowSnake() => snake.Grow();

        public void KillSnake() => snake.Die();
    }
}
