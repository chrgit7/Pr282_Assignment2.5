using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public class Controller
    {
        public IView myView;
        public Game myGame;
        public Serialise mySerialise;
        public Get myGet;
        public Set mySet;        
        private List<int> correctRows = new List<int>();
        private List<int> correctCols = new List<int>();
        private List<int> correctSqrs = new List<int>();
        private int Level;
        private int Score;
        private int AmountOfMoves;
        private int CurrentMove;
        private List<string[]> MovesMade = new List<string[]>();
        private int[] FrozenValues;
        private Boolean XType;

        public Controller(IView theView, Game theGame)
        {
            myView = theView;
            myGame = theGame;
            mySerialise = new Serialise(myGame);
            myGet = new Get(myGame);
            mySet = new Set(myGame);            
        }

        public void Start()
        {
            int[] inputArray = { 0, 3, 0, 4, 4, 0, 0, 0, 0, 0, 0, 1, 1, 0, 2, 0};
            myGame.Set(inputArray, Math.Sqrt((double)inputArray.Length).ToString() + "a");
            Level = 1;
            Score = 0;
            myView.SetLevelDialog(Level.ToString());
            myView.SetScore(Score.ToString());
            RecreateUI();
            AmountOfMoves = 0;
            CurrentMove = 0;
            XType = false;
        }

        public void OnLoad(int timeAmount, string csv, string frozen = null )
        {
            if (frozen != null)
            {
                FrozenValues = frozen.Split(',').Select(int.Parse).ToArray();
            }            
            mySerialise.FromCSV(csv);
            AskIfXType();
            myView.ClearCellButtons();
            myView.DeleteLines();
            myView.GameOverVisible(false);
            myView.setTimerCounter(timeAmount);
            myView.SetScore(Score.ToString());
            RecreateUI();
            CheckEntireTable();
        }

        public void Undo()
        {
            //[0] = name, [1] = prevMove, [2] = futureMove

            string[] name;
            try
            {
                name = MovesMade[CurrentMove - 1];
            }
            catch
            {
                myView.MessagePrompt("You can only undo 5 times!");
                CurrentMove++;
                return;
            }
            myView.SetButton(name[0], name[1]);
            if(CurrentMove >= 2)
            {
                CurrentMove--;
            }
        }

        public void Redo()
        {
            //[0] = name, [1] = prevMove, [2] = futureMove
            string[] name;
            try
            {
                name = MovesMade[CurrentMove - 1];
            }
            catch
            {
                myView.MessagePrompt("You can only redo 5 times!");
                CurrentMove--;
                return;
            }
            
            myView.SetButton(name[0], name[2]);
            if (CurrentMove <= 4)
            {
                CurrentMove++;
            }
        }

        public void LoadDialog()
        {
            string[] getFileContents = new LoadPrompt().LoadDialogPrompt();
            //OnLoad( int timeAmount, string csv, string frozen = null)
        }


        protected void RecreateUI()
        {
            myView.CreateCells(myGame.SudokuCells, myGame.GetMaxValue(), myGame.GetSquareHeight(), myGame.GetSquareWidth());
            myView.CreateBottomButtons();            
            myView.SetClicks();
            myView.TimerCreate();
            myView.FreezeButtons(FrozenValues);
        }

        internal void Hint()
        {
            string getInput = myView.UserInput("Enter the square number (remember it's 0 based): ", "Hint");
            int squareNumber = 1;
            try
            {
                squareNumber = Int32.Parse(getInput);
            }
            catch
            {
                return;
            }
            if (squareNumber < 0 || squareNumber > myGame.GetMaxValue())
            {
                myView.MessagePrompt("Enter a number between 0 and " + myGame.GetMaxValue().ToString());
                return;
            }            
            string values = "";
            if (correctSqrs.Contains(squareNumber))
            {
                myView.MessagePrompt("That square is already complete!");
            }
            else
            {
                values = myGet.GetPossibleValuesFromSqr(squareNumber);
            }
            myView.MessagePrompt(values);

        }

        internal void RecordMove(string name, string prevMove, string futureMove)
        {
            
            if (MovesMade.Count >= 5)
            {
                MovesMade.RemoveAt(0);
            }
            else
            {
                AmountOfMoves++;                             
            }
            if (CurrentMove != AmountOfMoves)
            {
                CurrentMove = AmountOfMoves;
            }
            else if (CurrentMove < 5)
            {
                CurrentMove++;
            }
            MovesMade.Add(new string[]{name, prevMove, futureMove});
        }

        internal void CheckTableSection(string name)
        {
            // 0 = btn_ 1 = col, 2 = row, 3 = arrIndex
            string[] values = name.Split('_');
            int col = Int32.Parse(values[1]);
            int row = Int32.Parse(values[2]);
            int sqr = RowColToSqr(row, col);
            if (sqr != 0)
            {
                sqr -= 1;
            }
            CheckTableIsValid(row, "row");
            CheckTableIsValid(col, "col");
            CheckTableIsValid(sqr, "sqr");
            CheckTableIsValid(1, "x"); // fix this later
            
            IfVictory();
        }

        private int RowColToSqr(int row, int col)
        {
            int majorRow = row / myGame.GetSquareWidth();  
            int majorCol = col / myGame.GetSquareWidth();
            return majorCol + majorRow * myGame.GetSquareWidth() + 1;
        }

        private void CheckEntireTable()
        {
            correctCols = new List<int>();
            correctRows = new List<int>();
            correctSqrs = new List<int>();

            for (int i = 0; i < myGame.GetMaxValue(); i++)
            {
                CheckTableIsValid(i, "row");
                CheckTableIsValid(i, "col");
                CheckTableIsValid(i, "sqr");
            }
            IfVictory();
        }

        private void AskIfXType()
        {
            if (myGame.SudokuCells.Length != 36)
            {
                XType = true;
            }            
        }

        private void IfVictory()
        {
            if (correctCols.Count == myGame.GetMaxValue() && correctRows.Count == myGame.GetMaxValue() && correctSqrs.Count == myGame.GetMaxValue())
            {
                myView.MessagePrompt("Congratulations!\nYou have completed the puzzle");                
                NextLevel();
            }
        }
        
        private void NextLevel()
        {            
            myView.SetLevelDialog(Level.ToString());
            string levelToLoad = "";
            if (Level == 1)
            {
                levelToLoad = @"6x6_incomplete.csv";
            }
            else if (Level == 2)
            {
                levelToLoad = @"9x9_incomplete.csv";
            }
            Level++;
            Score += 50;

            string combinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");
            string finalPath = System.IO.Path.GetFullPath(combinedPath);
            IEnumerable<string> fileLines = File.ReadLines(finalPath + levelToLoad);
            string csv = fileLines.ElementAt(0);
            int timerAmount = Int32.Parse(fileLines.ElementAt(1));           
            
            OnLoad(timerAmount, csv);
        }

        private void CheckTableIsValid(int EntitryNumber, string entityToCheck)
        {            
            int EntityNumber = EntitryNumber;            
            int correctEntity = EntitryNumber;
            Boolean IsValid = false;
            List<int> CorrectList = new List<int>();
            if (entityToCheck == "row")
            {
                correctEntity = EntityNumber;
                IsValid = myGet.IsRowValid(EntityNumber);
                CorrectList = correctRows;                
            }
            else if (entityToCheck == "col")
            {
                correctEntity = EntitryNumber;
                IsValid = myGet.IsColumnValid(EntitryNumber);
                CorrectList = correctCols;
            }
            else if (entityToCheck == "sqr")
            {
                correctEntity = EntitryNumber;
                IsValid = myGet.IsSquareValid(EntitryNumber);
                CorrectList = correctSqrs;
            }

            if (IsValid)
            {
                if (!CorrectList.Contains(correctEntity))
                {
                    CorrectList.Add(correctEntity);
                }
            }
            else if (CorrectList.Contains(correctEntity))
            {
                CorrectList.Remove(correctEntity);
            }
            CorrectList.Sort();
            myView.UpdateCorrectText(entityToCheck, correctEntity, CorrectList);
        }

        internal void UpdateBoard(string name, int value)
        {
            // 0 = btn_ 1 = col, 2 = row, 3 = arrIndex
            string[] values = name.Split('_');
            int arrIndex = Int32.Parse(values[3]);
            mySerialise.SetCell(value, Int32.Parse(values[3]));
        }
        
        internal void Save(int timeAmount)
        {
            string csv = mySerialise.ToCSV();
            csv += "\n" + timeAmount.ToString()
                + "\n" + string.Join(",", FrozenValues);
            myView.SaveDialog(csv);
        }

        internal int GetArrLength()
        {
            return myGame.SudokuCells.Length;
        }
    }
}
