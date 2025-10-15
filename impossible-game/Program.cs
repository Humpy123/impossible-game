namespace impossible_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create and configure board
            var board = new Board(12, 12);
            board.SetRandomCell(new Apple());
            board.SetRandomCell(new Wall());
            board.SetRandomCell(new Wall());
            board.SetRandomCell(new Wall());

            // Create and run game
            var game = new Game(board);
            game.Run();
        }
    }
}
