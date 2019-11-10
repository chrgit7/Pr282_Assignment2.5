using System;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 myFrm = new Form1();
            Controller myCon = new Controller(myFrm, new Game());
            myFrm.SetController(myCon);
            Application.Run(myFrm);            
        }
    }
}
