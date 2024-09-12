namespace Minesweeper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10, 16, 7);
            int input = 0;
            while (input != -1&&game.IsPlaying)
            {
                Console.Clear();
                Console.WriteLine(game);
                Console.WriteLine("write the x value of the spot you want to dig");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("write the y value of the spot you want to dig");
                int y = int.Parse(Console.ReadLine());
                
                game.UnvailTile(x, y);
                Console.WriteLine("input");
                input= int.Parse(Console.ReadLine());
            }
        }
    }
}
