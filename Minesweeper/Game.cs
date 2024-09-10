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
        public Game(int height,int width,int Bombs_)
        {
            StartTime=DateTime.Now;
            EndTime=DateTime.Now;
            IsPlaying = true;
            Board = new Tile[height, width];
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
                    Board[i,j] = new Tile(0, false);
                }
            }
            for(int i = 0;i < heights.Count; i++)//filling an empty board with tiles with bombs
            {
                List<Tile> adj = new List<Tile>();
                if (widths[i] > 0 && widths[i] < Board.GetLength(0) - 1)
                {
                    if (heights[i] > 0 && heights[i] < Board.GetLength(1) - 1)//if in middle middle
                    {
                        
                    }
                    else//if in middle but no top or bottom
                    {

                    }
                }
                else
                {
                    if (heights[i] > 0 && heights[i] < Board.GetLength(1) - 1)//if in middle left or right
                    {

                    }
                    else//if in corner
                    {

                    }
                }
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="Case">1-middle middle.2-middle top/bottom.3-right/left middle.4-corner</param>
        /// <returns></returns>
        public List<Tile> GetAdj(int width,int height,int Case)
        {
            List<Tile> result=new List<Tile>();
            switch (Case) 
            {
                case 1:
                    for(int i=-1)
                case 2:
                case 3:
                case 4:
            }
        }
        
        public bool? WonGame()
        {
            return null;
        }
    }
}
