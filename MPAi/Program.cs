using MPAi.Forms;
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
            if (args.Length > 0)
            {
                if (args[0] == "initDB")
                {
                    Application.Run(new LoginScreen("initDB"));
                    return;
                }
            }
            Console.WriteLine("Running Normally.");

            
            Application.Run(new LoginScreen());

            Application.Exit();
        }
    } 
}