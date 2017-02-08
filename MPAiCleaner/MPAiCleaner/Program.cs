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

            Console.Write("MPAi Cleaner:");
            //Locations of files associated with the MPAi project.
            Console.Write("Getting appdata location...");
            Console.Write("Getting temp location...");
            string mpaiLocation = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), "MPAi");
            string tempLocation = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "MPAiTEMP");

            //Deletes the MPAi directory within the APPDATA path recursively, if it exists.
            Console.Write("Checking if MPAi exists...");

            if (Directory.Exists(mpaiLocation))
            {
                Console.Write("MPAi exists: Deleteing MPAi");
                Directory.Delete(mpaiLocation, true);
            }
            else {
                Console.Write("MPAi does not exist: Skipping");
            }

            //Deletes the MPAiTEMP directory within the TEMP path recursively, if it exists.
            Console.Write("Checking if MPAiTEMP exists...");

            if (Directory.Exists(tempLocation))
            {
                Console.Write("MPAiTEMP exists: Deleteing MPAi");

                Directory.Delete(tempLocation, true);
            } else
            {
                Console.Write("MPAiTEMP does not exist: Skipping");

            }

        }

    }
}
