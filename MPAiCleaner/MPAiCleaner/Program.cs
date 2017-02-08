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
            //Locations of files associated with the MPAi project.
            string mpaiLocation = Path.Combine(Environment.GetEnvironmentVariable("APPDATA"), "MPAi");
            string tempLocation = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "MPAiTEMP");

            //Deletes the MPAi directory within the APPDATA path recursively, if it exists.
            if (Directory.Exists(mpaiLocation))
            {
                Directory.Delete(mpaiLocation, true);
            } 

            //Deletes the MPAiTEMP directory within the TEMP path recursively, if it exists.
            if (Directory.Exists(tempLocation))
            {
                Directory.Delete(tempLocation, true);
            }

        }

    }
}
