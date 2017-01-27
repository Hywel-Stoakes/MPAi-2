using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MPAi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MPAi.NewForms.MPAiMessageBoxFactory.Show("blah", NewForms.MPAiMessageBoxButtons.YesNoCancel);
            if (args.Length > 0)
            {
                if (args[0] == "initDB")
                {
                    Application.Run(new NewForms.LoginScreen("initDB"));
                    return;
                }
            }
            Console.WriteLine("Running Normally.");

            Application.Run(new NewForms.LoginScreen());
            Application.Exit();
        }
    } 
}