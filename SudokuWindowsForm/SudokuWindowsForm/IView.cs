using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplicationDemo
{
    public interface IView
    {
        void Show(string message);
        void SetController(Controller controller);
        void CreateCells(int[] inputCells, int maxValue, int squareHeight, int squareWidth);
        void TimerCreate();
        void CreateBottomButtons();
        void SetClicks();        
        int[] GetGridArea();
        void DrawIt(int startX, int startY, int finishX, int finishY);
        void UpdateCorrectText(string type, int intToUpdate, List<int> correctList);
        void ClearCellButtons();
        void DeleteLines();
        void GameOverVisible(Boolean flag);
        void setTimerCounter(int timeAmount);
        void MessagePrompt(string message);
        void SaveDialog(string csv);
        void SetLevelDialog(string level);
        int GetTimeAmount();
        void SetScore(string score);
        void SetButton(string name, string text);
        void FreezeButtons(int[] frozenValues);
        string UserInput(string message, string title);
    }
}
