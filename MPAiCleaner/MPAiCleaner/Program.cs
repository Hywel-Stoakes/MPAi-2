using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MPAiCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("MPAi Cleaner:");
                //Locations of files associated with the MPAi project.
                string mpaiLocation = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), "MPAi");
                string tempLocation = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "MPAiTEMP");
                //Deletes the MPAi directory within the APPDATA path recursively, if it exists.
                if (Directory.Exists(mpaiLocation))
                {
                    Console.WriteLine("MPAi exists: Deleteing MPAi");
                    Directory.Delete(mpaiLocation, true);
                }
                else
                {
                    Console.WriteLine("MPAi does not exist: Skipping");
                }
                //Deletes the MPAiTEMP directory within the TEMP path recursively, if it exists.

                if (Directory.Exists(tempLocation))
                {
                    Console.WriteLine("MPAiTEMP exists: Deleteing MPAi");
                    Directory.Delete(tempLocation, true);
                }
                else
                {
                    Console.WriteLine("MPAiTEMP does not exist: Skipping");
                }
                Console.WriteLine("\nMPAi files have been Cleaned.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error cleaning MPAi, MPAi Files Not Cleaned.");
                Console.WriteLine("You may continue the installation, \nbut it is recommened when the installer begins you cancel the installation.\n and Restart your computer before re running the setup.exe");
                Console.WriteLine(e.StackTrace);
            }
            finally {
                Console.WriteLine("Press any key to continue... ");
                Console.ReadLine();
            }

        }

    }
}
