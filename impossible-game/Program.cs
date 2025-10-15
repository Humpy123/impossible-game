namespace impossible_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("█████████\n███████");

            // Create and configure board
            var board = new Board(50, 25);
            board.SetRandomCell(new Apple());
            Console.WriteLine("█████████\n███████");

            // Create and run game
            var game = new Game(board);
            game.Run();
        }
    }
}
