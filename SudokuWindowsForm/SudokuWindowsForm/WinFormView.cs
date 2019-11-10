using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    public partial class Form1 : IView
    {
        Dictionary<Graphics,int[]> lines = new Dictionary<Graphics, int[]>();
        private int[] GridArea = new int[4];

        public void SetController(Controller controller)
        {
            myController = controller;
        }

        public void Show(string message)
        {
            textBox1.Text = message;
        }                

        public int[] GetGridArea()
        {
            return this.GridArea;
        }

        public void CreateCells(int[] inputCells, int maxValue, int squareHeight, int squareWidth)
        {
            int amountOfColumns;
            int numberOfSquares = maxValue;            
            int columnInsertionPoint = numberOfSquares / squareHeight;
            int rowInsertionPoint = squareHeight * numberOfSquares;
            int colGapCounter = (numberOfSquares / squareHeight) - 1;
            if (maxValue == 9)
            {               
                amountOfColumns = 9;
            }
            else if (maxValue == 6)
            {                
                amountOfColumns = 6;                
            }
            else if (maxValue == 4)
            {
                amountOfColumns = 4;
            }
            else
            {
                amountOfColumns = 0;
            }
            int columnCount = 0;           
            int rowCount = 0;
            int dispCol = 0;           
            int dispRow = 0;            
            for (int i = 0; i < inputCells.Length; i++)
            {                
                if (columnCount < amountOfColumns && i % amountOfColumns != 0)
                {
                    columnCount++;
                }
                else if (i != 0)
                {
                    columnCount = 0;
                    rowCount++;
                }
                if (i % numberOfSquares == 0)
                {
                    dispCol = 0;
                }
                if (i % columnInsertionPoint == 0 && i % numberOfSquares != 0)
                {
                    dispCol += 10;
                    //DrawIt(dispCol + columnCount * 50 + 5, 12, dispCol + columnCount * 50 + 5, maxValue * 50 + (colGapCounter * 10 + (6 * 1))); // 6  * 1 is 6 gaps times the size which is 1                    
                }
                if (i % rowInsertionPoint == 0 && i % inputCells.Length != 0)
                {
                    dispRow += 10;
                }
                // length of column line is (Ys)
                // maxValue  * 50 + (gapcounter * 10)
                MakeButton("btn_", inputCells[i].ToString(), rowCount, columnCount, i, dispCol, dispRow); // btn_0_0 col_row
            }            
        }

        public void DrawIt(int startX, int startY, int finishX, int finishY)
        {
            System.Drawing.Graphics newLine = this.CreateGraphics();
            newLine.DrawLine(System.Drawing.Pens.Black, startX, startY, finishX, finishY);
            newLine.Dispose();
            int[] coordsArr = new int[4];
            coordsArr[0] = startX;
            coordsArr[1] = startY;
            coordsArr[2] = finishX;
            coordsArr[3] = finishY;
            lines.Add(newLine, coordsArr);            
        }

        public void ClearCellButtons()
        {
            List<Button> buttonsToDelete = new List<Button>();
            foreach (Control c in this.Controls)
            {
                if (c.Name.Contains("btn"))
                {
                    Button nextButton = c as Button;
                    buttonsToDelete.Add(nextButton);
                }
            }
            foreach (Button nextButton in buttonsToDelete)
            {
                this.Controls.Remove(nextButton);
            }
        }

        public void DeleteLines()
        {
            foreach (var item in lines.Values)
            {
                System.Drawing.Graphics newLine = this.CreateGraphics();
                Pen myPen = new Pen(Color.FromArgb(240, 240, 240));
                newLine.DrawLine(myPen, item[0], item[1], item[2], item[3]);
                newLine.Dispose();
                //nextLine.Key.DrawLine(System.Drawing.Pens.White, nextLine.Value.GetValue[0], nextLine.Value.[1], nextLine.Value.[2], nextLine.Value.[3]);
                lines = new Dictionary<Graphics, int[]>();
            }
        }

        public void GameOverVisible(Boolean flag)
        {
            if (flag)
            {
                gameOverTxBx.Visible = true;
            }
            else
            {
                gameOverTxBx.Visible = false;
            }
        }
    }
}
