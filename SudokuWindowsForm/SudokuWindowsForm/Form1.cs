using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    public partial class Form1 : Form
    {
        private string ClickedText;
        private Controller myController;
        private int timerCounter;
        private Boolean counting;
        private Timer MyTimer;        

        public Form1()
        {
            InitializeComponent();            
            counting = true;
            timerCounter = 500;            
        }

        public void TimerCreate()
        {
            if (MyTimer == null)
            {
                MyTimer = new Timer();
                MyTimer.Interval = 1000; // 1 sec
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();
            }
            else
            {
                counting = true;
                MyTimer.Start();
            }
        }

        public void CreateBottomButtons()
        {
            for (int j = 1; j < 10; ++j)
            {
                MakeButton("iptbtn_", j.ToString(), 10, j, -1 );
            }
            this.ClickedText = "1"; // default setting before a number has been chosen
        }

        public void SetClicks()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    Button who = c as Button;
                    if (who.Name.StartsWith("btn"))
                    {
                        who.Click += new EventHandler(MoveRecord);                        
                    }
                    who.Click += new EventHandler(WhoClicked);
                    if (who.Name.StartsWith("btn"))
                    {
                        who.Click += new EventHandler(UpdateBoard);
                        who.Click += new EventHandler(IsGameComplete);                       
                    }                   
                }                
            }
        }        

        public void UpdateCorrectText(string type, int intToUpdate, List<int> correctList)
        {            
            if (type == "row")
            {
                RowTxBox.Text = "Row:" + String.Join(", ", correctList);
            }
            else if (type == "col")
            {
                ColTxBox.Text = "Col:" + String.Join(", ", correctList);
            }
            else if (type == "sqr")
            {
                SqrTxBox.Text = "Sqr:" + String.Join(", ", correctList);
            }
        }

        public void SetButton(string name, string text)
        {            
            foreach (Control c in Controls)
            {
                if (c is Button btnWho)
                {
                    if (btnWho.Name == name)
                    {
                        btnWho.Text = text;
                    }
                }
            }            
        }

        public void setTimerCounter(int timeAmount)
        {
            this.timerCounter = timeAmount;
        }

        public void SetLevelDialog(string level)
        {
            LevelTxBox.Text = "Level: " + level;
        }

        public int GetTimeAmount()
        {
            return timerCounter;
        }

        public void SaveDialog(string csv)
        {
            SaveFileDialog newFileSave = new SaveFileDialog();
            newFileSave.Filter = "CSV files|*.csv";
            newFileSave.FileName = "saveGame" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");            
            newFileSave.Title = "Save your Game";
            string CombinedPath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");
            newFileSave.InitialDirectory = Path.GetFullPath(CombinedPath);
            if (newFileSave.ShowDialog() == DialogResult.OK)
            {
                string path = newFileSave.FileName;
                using (StreamWriter bw = new StreamWriter(File.Create(path)))
                {
                    bw.Write(csv);
                    bw.Close();
                }
            }
        }

        public void FreezeButtons(int [] frozenValues)
        {
            int counter = 0;
            if (frozenValues == null) { return; }
            foreach (Control c in Controls)
            {
                if (c is Button btnWho)
                {
                    if (btnWho.Name.StartsWith("btn"))
                    {
                        if (frozenValues[counter] != 0)
                        {
                            btnWho.Enabled = false;
                        }
                        counter++;                        
                    }
                }
            }
            
        }

        protected void MakeButton(string name, string text, int row, int column, int arrIndex, int dispCol = 0, int dispRow = 0 )
        {
            // btn_0_0_00 col_row_indexArr
            Button btnNew = new Button();
            btnNew.Name = name + column.ToString() + "_" + row.ToString() + "_" + arrIndex.ToString();            
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);            
            if (text == "0")
            {
                text = " ";                
            }            
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * column + dispCol, 10 + 50 * row + dispRow);            
            btnNew.Font = new Font(btnNew.Font.FontFamily, 8);
            
            Controls.Add(btnNew);
        }

        protected void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            if (btnWho.Name.StartsWith("btn"))
            {
                btnWho.Text = ClickedText;
            }
            else if (btnWho.Name.StartsWith("iptbtn_"))
            {
                this.ClickedText = btnWho.Text;
            }
        }

        public string UserInput(string message, string title)
        {
            string promptValue = Prompt.ShowDialog(message, title);
            return promptValue;
        }
        
        public void MessagePrompt(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }

        public void SetScore(string score)
        {
            ScoreTxBox.Text = "Score: " + score;
        }

        private void UpdateBoard(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            myController.UpdateBoard(btnWho.Name, Int32.Parse(btnWho.Text));
        }

        private void MoveRecord(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            myController.RecordMove(btnWho.Name, btnWho.Text, ClickedText);
        }

        private void IsGameComplete( object sender, EventArgs e)
        {
            Button btnWho = sender as Button;
            myController.CheckTableSection(btnWho.Name);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            myController.Start();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (counting)
            {
                timerCounter--;
                timerDisplay.Text = timerCounter.ToString();                
            }
            else
            {
                MyTimer.Stop();
            }            
            if (timerCounter == 0)
            {
                GameOverScreen();
            }
        }

        private void GameOverScreen()
        {
            counting = false;
            foreach (Control c in this.Controls)
            {
                
                if (c.Name.Contains("btn"))
                {
                    Button nextButton = c as Button;
                    nextButton.Visible = false;                    
                }
            }
            DeleteLines();            
            gameOverTxBx.Text = "Game Over" + "\nTime ran out!";
            gameOverTxBx.Visible = true;           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void loadCSVBtn_Click(object sender, EventArgs e)
        {
            LoadDialog();
        }

        private void LoadDialog()
        {
            Stream myStream = null;
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open CSV File";
            theDialog.Filter = "CSV files|*.csv";
            string CombinedPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\");
            theDialog.InitialDirectory = System.IO.Path.GetFullPath(CombinedPath);
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            IEnumerable<string> fileLines = File.ReadLines(theDialog.FileName);
                            string buttons = fileLines.ElementAt(0);
                            int timerAmount = Int32.Parse(fileLines.ElementAt(1));
                            string frozenButtons = null;
                            try
                            {
                                frozenButtons = fileLines.ElementAt(2);
                            }catch(Exception e)
                            {
                                // no default values to find 
                            }
                            
                            myController.OnLoad(timerAmount, buttons, frozenButtons);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Equals(false);
                }
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            myController.Save(timerCounter);
        }

        private void LoadNormal_Click(object sender, EventArgs e)
        {           
            LoadDialog();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            myController.Undo();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            myController.Redo();
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            myController.Hint();
        }
    }
}
