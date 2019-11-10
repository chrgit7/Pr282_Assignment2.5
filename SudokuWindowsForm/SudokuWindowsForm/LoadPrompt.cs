using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    class LoadPrompt
    {
        public string[] LoadDialogPrompt()
        {
            string[] output = new string[] { "error" };

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
                            output = GetFileContents(theDialog.FileName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Equals(false);
                }
            }

            return output;
        }

        private string[] GetFileContents(string fileName)
        {
            IEnumerable<string> fileLines = File.ReadLines(fileName);
            string buttons = fileLines.ElementAt(0);
            int timerAmount = Int32.Parse(fileLines.ElementAt(1));
            string frozenButtons = null;
            try
            {
                frozenButtons = fileLines.ElementAt(2);
            }
            catch
            {
                // no default values to find 
            }

            string[] output = new string[] { timerAmount.ToString(), buttons, frozenButtons };
            return output;
        }
    }
}
