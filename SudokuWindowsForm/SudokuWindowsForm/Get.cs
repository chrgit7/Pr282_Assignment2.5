using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public class Get : IGet
    {
        Game myGame;       
        public Get(Game theGame)
        {
            myGame = theGame;            
        }

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            int ArrayValue = (rowIndex * myGame.GetMaxValue()) + columnIndex;
            return myGame.SudokuCells[ArrayValue];
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            int ArrayValue = (rowIndex * myGame.GetMaxValue()) + columnIndex;
            return myGame.SudokuCells[ArrayValue];
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            var squareSize = myGame.GetMaxValue();
            var squareWidth = myGame.GetSquareWidth();
            var squareHeight = myGame.GetSquareHeight();

            var externalSquareRow = squareIndex / squareHeight;
            var externalSquareColumn = squareIndex % squareHeight;
            var rowStartIndex = externalSquareRow * squareHeight * squareSize;
            var externalColumnShift = externalSquareColumn * squareWidth;
            var firstSquareCellIndex = rowStartIndex + externalColumnShift;

            var internalSquareRow = positionIndex / squareWidth;
            var internalSquareColumn = positionIndex % squareWidth;
            var internalShift = internalSquareRow * squareSize + internalSquareColumn;
            var cellIndex = firstSquareCellIndex + internalShift;

            
            try
            {
                return myGame.SudokuCells[cellIndex];
            }
            catch{
                return 1;
            }
            
        }

        public bool IsRowValid(int rowIndex)
        {
            int[] rowToCheck = new int[myGame.GetMaxValue()];
            bool result = false;

            for (int i = 0; i < myGame.GetMaxValue(); i++)
            {
                rowToCheck[i] = GetByRow(rowIndex, i);
            }

            for (int i = 1; i <= myGame.GetMaxValue(); i++)
            {
                if (rowToCheck.Contains(i))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool IsColumnValid(int columnIndex)
        {
            int[] columnToCheck = new int[myGame.GetMaxValue()];
            bool result = false;

            for (int i = 0; i < myGame.GetMaxValue(); i++)
            {
                columnToCheck[i] = GetByColumn(columnIndex, i);
            }

            for (int i = 1; i <= myGame.GetMaxValue(); i++)
            {
                if (columnToCheck.Contains(i))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public bool IsSquareValid(int squareIndex)
        {
            int[] squareToCheck = new int[myGame.GetMaxValue()];
            bool result = false;

            for (int i = 0; i < myGame.GetMaxValue(); i++)
            {
                squareToCheck[i] = GetBySquare(squareIndex, i);
            }

            for (int i = 1; i <= myGame.GetMaxValue(); i++)
            {
                if (squareToCheck.Contains(i))
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }            
            return result;
        }

        public string GetPossibleValuesFromSqr(int squareNumber)
        {
            int[] squareArr = new int[myGame.GetMaxValue()];
            string possibleValues = "";
            for (int i = 0; i < myGame.GetMaxValue(); i++)
            {
                squareArr[i] = GetBySquare(squareNumber, i);
            }
            for (int i = 1; i <= myGame.GetMaxValue(); i++)
            {
                if (!squareArr.Contains(i))
                {
                    possibleValues += i + ", ";
                }
            }
            possibleValues = possibleValues.Substring(0, possibleValues.Length - 2);
            return possibleValues;            
        }
    }
}
