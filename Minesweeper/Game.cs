using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Game
    {
        private readonly Tile[,] Board;
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }   
        public bool IsPlaying { get; private set; }
        public bool? GameWon { get {return WonGame(); }  }
        public int Bombs {  get; private set; }
        public Game(int width,int height,int Bombs_)
        {
            StartTime=DateTime.Now;
            EndTime=DateTime.Now;
            IsPlaying = true;
            Board = new Tile[width,height];
            Bombs = Bombs_;
            FillBoard();
        }
        public void FillBoard()
        {
            if (Board == null) return;
            Random rnd=new Random();
            List<int> heights=new List<int>();
            List<int> widths=new List<int>();
            for (int i = 0; i < Bombs; i++)//getting the locarions of bombs
            {
                int width = rnd.Next(Board.GetLength(0));
                int height = rnd.Next(Board.GetLength(1));
                if (widths.Contains(width) && heights.Contains(height)) i--;
                else
                {
                    widths.Add(width);
                    heights.Add(height);
                }
            }
            for(int i = 0; i < Board.GetLength(0); i++)//width
            {
                for(int j = 0; j < Board.GetLength(1); j++)//height
                {
                    Board[i,j] = new Tile(0);
                }
            }
            for(int i = 0;i < heights.Count; i++)//filling an empty board with tiles with bombs
            {
                Board[widths[i], heights[i]] = new Tile(-1);
                for (int k = -1; k <= 1; k++)
                {
                    for( int j = -1;j <= 1; j++)
                    {
                        if (k!=0|| j!=0)
                        {
                            bool withinBounds = 
                                (widths[i] + k >= 0 && widths[i] + k < Board.GetLength(0))//checks if the k value gives a tile that exists in the board array
                                &&
                                (heights[i] + j >= 0 && heights[i] + j < Board.GetLength(1));//checks if the j value gives a tile that exists in the board array
                            if (withinBounds) 
                            {
                                if(Board[widths[i] + k, heights[i] + j].Value!=-1)Board[widths[i] + k, heights[i] + j].AddBomb();
                            }
                        }
                    }
                }
            }

        }
        public void UnvailTile(int x,int y)
        {
            if ((x < 0 || y < 0 || x >= Board.GetLength(0) || y >= Board.GetLength(1))|| Board[x, y] == null)
            {
                Console.WriteLine("illegal move");
                return;
            }
            if (Board[x, y].Unvailed) return;
            
            if(!Board[x, y].Dig())
            {
                GameLost();
                return;
            }
            if (Board[x, y].Value == 0)
            {
                for (int k = -1; k <= 1; k++)
                {
                    for (int j = -1; j <= 1; j++)
                    {

                        if (k != 0 || j != 0)
                        {
                            bool withinBounds =
                                (x + k >= 0 && x + k < Board.GetLength(0))//checks if the k value gives a tile that exists in the board array
                                &&
                                (y + j >= 0 && y + j < Board.GetLength(1));//checks if the j value gives a tile that exists in the board array
                            if (withinBounds)
                            {
                                UnvailTile(x + k, y + j);
                            }
                        }
                    }
                }
            }
            EndTime = DateTime.Now;
        }
        public void GameLost()
        {
            for (int i = 0; i < Board.GetLength(0); i++)//width
            {
                for (int j = 0; j < Board.GetLength(1); j++)//height
                {
                    Board[i, j].Dig();
                }
            }
            EndTime = DateTime.Now;
            IsPlaying = false;
            Console.WriteLine(this);
        }
        
        public bool? WonGame()
        {
            return null;
        }
        public override string ToString()
        {
            string result = string.Empty;
            result += "Time: " + (EndTime - StartTime ).Hours + ":" + (EndTime - StartTime ).Minutes + ":" + (EndTime - StartTime ).Seconds + "\n";
            for (int j = 0; j < Board.GetLength(1); j++)//width
            {
                for (int i = 0; i < Board.GetLength(0); i++)//height
                {
                    result += Board[i,j] + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}
