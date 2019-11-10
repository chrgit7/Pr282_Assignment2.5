using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    public static class Prompt
    {
        public static string ShowDialog(string message, string title)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = title,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = message };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
