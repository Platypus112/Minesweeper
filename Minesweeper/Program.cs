namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10, 16, 7);
            game.Play();
        }
    }
}
