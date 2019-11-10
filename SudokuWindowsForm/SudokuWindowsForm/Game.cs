using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public class Game : IGame
    {

        public int[] SudokuCells;
        private int MaxValue;
        private int SquareHeight;
        private int SquareWidth;        

        public void Restart()
        {
            this.SudokuCells = new int[SudokuCells.Length];
        }

        public void Set(int[] cellValues, string configVersion)
        {
            SudokuCells = cellValues;
            Dictionary<string, int[]> setCellInfo = new Dictionary<string, int[]>();
            setCellInfo.Add("9a", new int[] { 9, 3, 3 });
            setCellInfo.Add("6a", new int[] { 6, 2, 3 });
            setCellInfo.Add("6b", new int[] { 6, 3, 2 });
            setCellInfo.Add("4a", new int[] { 4, 2, 2 });
            int[] input = { 9, 3,3 };

            try
            {
                input = setCellInfo[configVersion];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Only three sizes are acceptable: 4, 6 or 9");
            }

            SetMaxValue(input[0]);
            SetSquareHeight(input[1]);
            SetSquareWidth(input[2]);
        }

        public void SetMaxValue(int maximum)
        {
            MaxValue = maximum;            
        }

        public int GetMaxValue()
        {
            return MaxValue;
        }

        public void SetSquareHeight(int squareHeight)
        {
            this.SquareHeight = squareHeight;
        }

        public int GetSquareHeight()
        {
            return this.SquareHeight;
        }

        public void SetSquareWidth(int squareWidth)
        {
            this.SquareWidth = squareWidth;
        }

        public int GetSquareWidth()
        {
            return this.SquareWidth;
        }

        public int[] ToArray()
        {
            return SudokuCells;
        }
    }
}
