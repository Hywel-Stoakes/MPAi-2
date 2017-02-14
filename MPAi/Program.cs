using MPAi.Forms;
using System;
using System.Windows.Forms;
using MPAi.Modules; 
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
            Console.WriteLine(VoiceType.getStringFromVoiceType(new VoiceType(GenderType.MASCULINE, LanguageType.MODERN)));


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