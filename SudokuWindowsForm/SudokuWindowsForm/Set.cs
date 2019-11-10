using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public class Set : ISet
    {
        Game myGame;
        public Set(Game theGame)
        {
            myGame = theGame;
        }

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            int arrayIndex = columnIndex + rowIndex * myGame.GetMaxValue();
            myGame.SudokuCells[arrayIndex] = value;
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            int arrayIndex = columnIndex + rowIndex * myGame.GetMaxValue();
            myGame.SudokuCells[arrayIndex] = value;
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            int magicColumnAdd = positionIndex % 3;
            int magicRowAdd = positionIndex % 3;
            int startingColumnIndex = squareIndex * myGame.GetSquareWidth();
            int startingRowIndex = (squareIndex / 3) * 3;
            SetByRow(value, startingColumnIndex + magicColumnAdd, startingRowIndex + magicRowAdd);
        }        
    }
}
