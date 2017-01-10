using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MPAid.Cores;
using System.IO.Pipes;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MPAid.Models;
namespace MPAid
{
    /// <summary>
    /// Class to runs and closes plots written in python which has been converting into an exe.
    /// Creates a proccess which runs the exe file for the requested plot.
    /// 
    /// Also serves as the 'middle man' between the C# and Python code. Via a pipe can send and recieve messages
    /// from the python code.
    /// 
    /// Due the nature of the exes. This class limits the project to be purely windows based.
    /// </summary>
    public static class PlotController

    {

        public enum PlotType { formantPlot, vowelPlot }
        private static PlotType? plotType;
        private static VoiceType? voiceType;

        // Calls to the windows USER32.dll file, to make changes to the Python user interface.

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        /// <summary>
        /// If the  plot is running in the background, brings it to the foreground.
        /// </summary>
        /// <param name="title">The title of the  plot.</param>
        /// <returns>1 if the  plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int ShowPlot(string title)
        {
            // Get a handle to the Plot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Plot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            // Make Plot the foreground application
            SetForegroundWindow(handle);
            ShowWindow(handle, SW_SHOWNORMAL);

            return 0;
        }
        /// <summary>
        /// Returns a value indicating if a  plot has been started.
        /// </summary>
        /// <param name="title">The title of the  Plot</param>
        /// <returns>1 if the  plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int PlotStarted(string title)
        {
            // Get a handle to the Plot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that Plot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            return 0;
        }

        private static Process PlotExe;

        /// <summary>
        /// Method called by the button to show the  plot. 
        /// If there is already a  plot running, it is brought into the foreground.
        /// If not, a new process is created.
        /// 
        /// requestedPlotType determines if RunPlot runs a Vowel or Formant Plot.
        /// requestedVoiceType determines if we use heratage/ modern and masculine/feminine for the plots. 
        /// </summary>
        public static void RunPlot(PlotType? requestedPlotType, VoiceType? requestedVoiceType)
        {
            plotType = requestedPlotType;
            voiceType = requestedVoiceType;

            if (PlotStarted(GetPlotTitle()) == 1)
                StartPlot();
            else
                ShowPlot(GetPlotTitle());
        }
        /// <summary>
        /// Used to clean up after a  plot has been closed, as the process is simply put into the background.
        /// If this is called when the process does not exist yet, it does nothing.
        /// </summary>
        public static void ClosePlot()
        {
            if ((PlotExe != null) && (!PlotExe.HasExited))
            {
                PlotExe.Kill();

            }
        }
        /// <summary>
        /// Creates a new process, connects it to the python Runner file, and starts the  plot. 
        /// Also tidies up after an older process if it is still running.
        /// </summary>
        private static async void StartPlot()
        {

            try
            {
                // Before starting a new process, tidy up any old ones in the background.
                ClosePlot();


                PythonPipe pythonPipe = new PythonPipe();

                Thread oThread = new Thread(new ThreadStart(pythonPipe.ConnectAndRecieve));
                oThread.Start();

                Console.WriteLine("after Thread");



                PlotExe = new Process();

                if (plotType == PlotType.vowelPlot)
                {
                    PlotExe.StartInfo.FileName = "VowelRunner.exe";
                }
                else if (plotType == PlotType.formantPlot)
                {
                    PlotExe.StartInfo.FileName = "PlotRunner.exe";
                }

                // Gets the arguments required for the console command to run the exe file.
                // based on the requested voiceType.
                switch (voiceType)
                {
                    case VoiceType.MASCULINE_HERITAGE:
                        PlotExe.StartInfo.Arguments = @"masculine heritage";
                        break;
                    case VoiceType.MASCULINE_MODERN:
                        PlotExe.StartInfo.Arguments = @"masculine modern";
                        break;
                    case VoiceType.FEMININE_HERITAGE:
                        PlotExe.StartInfo.Arguments = @"feminine heritage";
                        break;
                    case VoiceType.FEMININE_MODERN:
                        PlotExe.StartInfo.Arguments = @"feminine modern";
                        break;
                    default:
                        PlotExe.StartInfo.Arguments = @"masculine heritage";
                        break;
                }

                PlotExe.StartInfo.UseShellExecute = true;
                PlotExe.StartInfo.WorkingDirectory = Path.Combine(Properties.Settings.Default.FomantFolder, @"dist");
                PlotExe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                PlotExe.Start();

                // Hang up the main application to wait until it finished starting
                while ((PlotStarted(GetPlotTitle()) == 1) && (!PlotExe.HasExited))
                {
                    //oThread.Abort();
                    //Console.WriteLine("Alpha.Beta has finished");

                    // Wait 5 ms before checking if secondary application has started, preventing CPU blocking.
                    await System.Threading.Tasks.Task.Delay(5);
                }

            }
            catch (Exception exp)
            {
                PlotExe = null;
                Console.WriteLine(exp);
            }
        }
        /// <summary>
        /// Getter for the title of the  plot.  
        /// </summary>
        /// <returns>The title of the  plot, as a string.</returns>
        public static string GetPlotTitle()
        {
            return (@"Vowel Plot");
        }
    }
    /// <summary>
    /// Python Pipe creates a connection between the c# and python applications, allowing the python to relay stats back to the c# in order to display to the user.
    /// </summary>
    public class PythonPipe
    {
        public void ConnectAndRecieve()
        {

            Console.WriteLine("PythonPipe.connectAndRecieve is running in its own thread");
            // Open the named pipe.
            var pipeServer = new NamedPipeServerStream("NPSSVowelPlot");

            Console.WriteLine("Waiting for connection...");

            pipeServer.WaitForConnection();

            Console.WriteLine("Connected.");
            var binaryReader = new BinaryReader(pipeServer);
            Console.WriteLine("Messages from VowelPlot.py...");
            while (true)
            {
                try
                {
                    var recievedLength = (int)binaryReader.ReadUInt64();            // Read string length
                    var recievedString = new string(binaryReader.ReadChars(recievedLength - 1));
                    Console.WriteLine("{0}", recievedString);


                }
                catch (EndOfStreamException)
                {
                    break;
                }
            }

            Console.WriteLine("Client disconnected.");
            pipeServer.Close();
            pipeServer.Dispose();
        }

    }
}