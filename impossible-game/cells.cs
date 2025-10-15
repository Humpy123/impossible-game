using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace impossible_game
{
    public interface ICell
    {
        void OnEnter(Board board);
        char Symbol { get; }
        ConsoleColor Color { get; }
    }
    public class Empty : ICell
    {
        public void OnEnter(Board board) { }
        public char Symbol => '█';
        public ConsoleColor Color => ConsoleColor.White;
    }
    public class Apple : ICell
    {
        public void OnEnter(Board board)
        {
            board.GrowSnake();
            board.SetCurrentCell(new Empty());
            board.SetRandomCell(new Apple());
        }

        public char Symbol => 'A';
        public ConsoleColor Color => ConsoleColor.Red;
    }
    public class Wall : ICell
    {
        public void OnEnter(Board board) => board.KillSnake();
        public char Symbol => '█';
        public ConsoleColor Color => ConsoleColor.Cyan;
    }
}
