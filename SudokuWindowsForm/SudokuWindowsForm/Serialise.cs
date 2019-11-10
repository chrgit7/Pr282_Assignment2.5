using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public class Serialise : ISerialise
    {
        Game myGame;
        public Serialise(Game theGame)
        {
            myGame = theGame;
        }

        public void FromCSV(string csv)
        {            
            int[] cellArr = csv.Split(',').Select(int.Parse).ToArray();
            myGame.Set(cellArr, Math.Sqrt((double)cellArr.Length).ToString() + "a");
        }

        public int GetCell(int gridIndex)
        {
            int output = 0;            
            if (gridIndex > (myGame.SudokuCells.Length - 1) || gridIndex < 0)
            {
                Console.WriteLine("You tried to get a cell outside the range of the array!");
                output = 0;
            }
            else
            {
                output = myGame.SudokuCells[gridIndex];
            }            
            return output;
        }

        public void SetCell(int value, int gridIndex)
        {
            if (gridIndex > (myGame.SudokuCells.Length - 1) || gridIndex < 0)
            {
                Console.WriteLine("You tried to set a cell outside the range of the array!");                
            }
            else
            {
                myGame.SudokuCells[gridIndex] = value;
            }
        }

        public string ToCSV()
        {
            string CSVString = string.Join(",", myGame.SudokuCells);
            return CSVString;
        }

        public string ToPrettyString()
        {
            string output = "";
            int prettyFormattingColumn;
            int prettyFormattingRow;
            int amountOfColumns;
            int amountOfRows;
            string horBar;
            if (myGame.GetMaxValue() == 9)
            {
                prettyFormattingColumn = 3;
                prettyFormattingRow = 27;
                amountOfColumns = 2;
                amountOfRows = 2;
                horBar = "------+-------+------";

            }
            else if (myGame.GetMaxValue() == 6)
            {
                prettyFormattingColumn = 3;
                prettyFormattingRow = 12;
                amountOfColumns = 1;
                amountOfRows = 2;
                horBar = "------+------";
            }
            else if (myGame.GetMaxValue() == 4)
            {
                prettyFormattingColumn = 2;
                prettyFormattingRow = 8;
                amountOfColumns = 1;
                amountOfRows = 1;
                horBar = "----+----";
            }
            else
            {
                prettyFormattingColumn = 0;
                prettyFormattingRow = 0;
                amountOfColumns = 0;
                amountOfRows = 0;
                horBar = "";
            }
            int count = 1;            
            int columnCounter = 0;            
            int rowCounter = 0;            
            for (int i = 0; i < myGame.SudokuCells.Length; i++)
            {
                output += myGame.SudokuCells[i] + " ";

                if (count % prettyFormattingColumn == 0)
                {
                    if (columnCounter < amountOfColumns)
                    {
                        output += "| ";
                        columnCounter++;
                    }
                    else
                    {
                        columnCounter = 0;
                    }
                }
                if (count % myGame.GetMaxValue() == 0)
                {
                    if (count % prettyFormattingRow == 0)
                    {
                        if (rowCounter < amountOfRows)
                        {
                            output += "\n" + horBar;
                            rowCounter++;
                        }                        
                    }                    
                    output += "\n";
                }
                count++;
            }
            return output;
        }
    }
}
