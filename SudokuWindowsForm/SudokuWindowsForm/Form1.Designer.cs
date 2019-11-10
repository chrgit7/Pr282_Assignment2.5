using System;

namespace WindowsFormsApplicationDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.Label();
            this.gameOverTxBx = new System.Windows.Forms.Label();
            this.loadCSVBtn = new System.Windows.Forms.Button();
            this.timerDisplay = new System.Windows.Forms.Label();
            this.CompleteTxBox = new System.Windows.Forms.Label();
            this.RowTxBox = new System.Windows.Forms.Label();
            this.ColTxBox = new System.Windows.Forms.Label();
            this.SqrTxBox = new System.Windows.Forms.Label();
            this.TitleTxBox = new System.Windows.Forms.Label();
            this.WinTxBox = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadNormal = new System.Windows.Forms.Button();
            this.LevelTxBox = new System.Windows.Forms.Label();
            this.ScoreTxBox = new System.Windows.Forms.Label();
            this.UndoButton = new System.Windows.Forms.Button();
            this.RedoButton = new System.Windows.Forms.Button();
            this.HintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(605, 419);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Silver;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(543, 56);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // gameOverTxBx
            // 
            this.gameOverTxBx.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.gameOverTxBx.Location = new System.Drawing.Point(175, 173);
            this.gameOverTxBx.Name = "gameOverTxBx";
            this.gameOverTxBx.Size = new System.Drawing.Size(309, 219);
            this.gameOverTxBx.TabIndex = 3;
            this.gameOverTxBx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.gameOverTxBx.Visible = false;
            // 
            // loadCSVBtn
            // 
            this.loadCSVBtn.Location = new System.Drawing.Point(605, 260);
            this.loadCSVBtn.Name = "loadCSVBtn";
            this.loadCSVBtn.Size = new System.Drawing.Size(75, 23);
            this.loadCSVBtn.TabIndex = 4;
            this.loadCSVBtn.Text = "LoadCSV";
            this.loadCSVBtn.UseVisualStyleBackColor = true;
            this.loadCSVBtn.Visible = false;
            this.loadCSVBtn.Click += new System.EventHandler(this.loadCSVBtn_Click);
            // 
            // timerDisplay
            // 
            this.timerDisplay.BackColor = System.Drawing.Color.Silver;
            this.timerDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.timerDisplay.Location = new System.Drawing.Point(543, 80);
            this.timerDisplay.Name = "timerDisplay";
            this.timerDisplay.Size = new System.Drawing.Size(229, 24);
            this.timerDisplay.TabIndex = 5;
            // 
            // CompleteTxBox
            // 
            this.CompleteTxBox.BackColor = System.Drawing.Color.Silver;
            this.CompleteTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CompleteTxBox.Location = new System.Drawing.Point(543, 152);
            this.CompleteTxBox.Name = "CompleteTxBox";
            this.CompleteTxBox.Size = new System.Drawing.Size(229, 24);
            this.CompleteTxBox.TabIndex = 6;
            this.CompleteTxBox.Text = "===Complete===";
            // 
            // RowTxBox
            // 
            this.RowTxBox.BackColor = System.Drawing.Color.Silver;
            this.RowTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RowTxBox.Location = new System.Drawing.Point(543, 176);
            this.RowTxBox.Name = "RowTxBox";
            this.RowTxBox.Size = new System.Drawing.Size(229, 24);
            this.RowTxBox.TabIndex = 7;
            this.RowTxBox.Text = "Row:         ";
            // 
            // ColTxBox
            // 
            this.ColTxBox.BackColor = System.Drawing.Color.Silver;
            this.ColTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColTxBox.Location = new System.Drawing.Point(543, 200);
            this.ColTxBox.Name = "ColTxBox";
            this.ColTxBox.Size = new System.Drawing.Size(229, 24);
            this.ColTxBox.TabIndex = 8;
            this.ColTxBox.Text = "Column:         ";
            // 
            // SqrTxBox
            // 
            this.SqrTxBox.BackColor = System.Drawing.Color.Silver;
            this.SqrTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SqrTxBox.Location = new System.Drawing.Point(543, 224);
            this.SqrTxBox.Name = "SqrTxBox";
            this.SqrTxBox.Size = new System.Drawing.Size(229, 24);
            this.SqrTxBox.TabIndex = 9;
            this.SqrTxBox.Text = "Square:         ";
            // 
            // TitleTxBox
            // 
            this.TitleTxBox.BackColor = System.Drawing.Color.Silver;
            this.TitleTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TitleTxBox.Location = new System.Drawing.Point(543, 32);
            this.TitleTxBox.Name = "TitleTxBox";
            this.TitleTxBox.Size = new System.Drawing.Size(229, 24);
            this.TitleTxBox.TabIndex = 10;
            this.TitleTxBox.Text = "===Sudoku 2.0===";
            // 
            // WinTxBox
            // 
            this.WinTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.WinTxBox.Location = new System.Drawing.Point(107, 104);
            this.WinTxBox.Name = "WinTxBox";
            this.WinTxBox.Size = new System.Drawing.Size(279, 219);
            this.WinTxBox.TabIndex = 11;
            this.WinTxBox.Text = "Congratulations!You won this round of Sudoku";
            this.WinTxBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WinTxBox.Visible = false;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(605, 341);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadNormal
            // 
            this.LoadNormal.Location = new System.Drawing.Point(605, 315);
            this.LoadNormal.Name = "LoadNormal";
            this.LoadNormal.Size = new System.Drawing.Size(75, 23);
            this.LoadNormal.TabIndex = 13;
            this.LoadNormal.Text = "Load";
            this.LoadNormal.UseVisualStyleBackColor = true;
            this.LoadNormal.Click += new System.EventHandler(this.LoadNormal_Click);
            // 
            // LevelTxBox
            // 
            this.LevelTxBox.BackColor = System.Drawing.Color.Silver;
            this.LevelTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LevelTxBox.Location = new System.Drawing.Point(543, 104);
            this.LevelTxBox.Name = "LevelTxBox";
            this.LevelTxBox.Size = new System.Drawing.Size(229, 24);
            this.LevelTxBox.TabIndex = 14;
            // 
            // ScoreTxBox
            // 
            this.ScoreTxBox.BackColor = System.Drawing.Color.Silver;
            this.ScoreTxBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ScoreTxBox.Location = new System.Drawing.Point(543, 128);
            this.ScoreTxBox.Name = "ScoreTxBox";
            this.ScoreTxBox.Size = new System.Drawing.Size(229, 24);
            this.ScoreTxBox.TabIndex = 15;
            // 
            // UndoButton
            // 
            this.UndoButton.Location = new System.Drawing.Point(560, 519);
            this.UndoButton.Name = "UndoButton";
            this.UndoButton.Size = new System.Drawing.Size(75, 23);
            this.UndoButton.TabIndex = 16;
            this.UndoButton.Text = "<-- Undo";
            this.UndoButton.UseVisualStyleBackColor = true;
            this.UndoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // RedoButton
            // 
            this.RedoButton.Location = new System.Drawing.Point(641, 519);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(75, 23);
            this.RedoButton.TabIndex = 17;
            this.RedoButton.Text = "Redo -->";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.RedoButton_Click);
            // 
            // HintButton
            // 
            this.HintButton.Location = new System.Drawing.Point(605, 467);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(75, 23);
            this.HintButton.TabIndex = 18;
            this.HintButton.Text = "Hint";
            this.HintButton.UseVisualStyleBackColor = true;
            this.HintButton.Click += new System.EventHandler(this.HintButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 761);
            this.Controls.Add(this.HintButton);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.UndoButton);
            this.Controls.Add(this.ScoreTxBox);
            this.Controls.Add(this.LevelTxBox);
            this.Controls.Add(this.LoadNormal);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.WinTxBox);
            this.Controls.Add(this.TitleTxBox);
            this.Controls.Add(this.SqrTxBox);
            this.Controls.Add(this.ColTxBox);
            this.Controls.Add(this.RowTxBox);
            this.Controls.Add(this.CompleteTxBox);
            this.Controls.Add(this.timerDisplay);
            this.Controls.Add(this.loadCSVBtn);
            this.Controls.Add(this.gameOverTxBx);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label textBox1;
        private System.Windows.Forms.Label gameOverTxBx;
        private System.Windows.Forms.Button loadCSVBtn;
        private System.Windows.Forms.Label timerDisplay;
        private System.Windows.Forms.Label CompleteTxBox;
        private System.Windows.Forms.Label RowTxBox;
        private System.Windows.Forms.Label ColTxBox;
        private System.Windows.Forms.Label SqrTxBox;
        private System.Windows.Forms.Label TitleTxBox;
        private System.Windows.Forms.Label WinTxBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadNormal;
        private System.Windows.Forms.Label LevelTxBox;
        private System.Windows.Forms.Label ScoreTxBox;
        private System.Windows.Forms.Button UndoButton;
        private System.Windows.Forms.Button RedoButton;
        private System.Windows.Forms.Button HintButton;
    }
}

