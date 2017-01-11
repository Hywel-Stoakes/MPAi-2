using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using MPAid.Cores;

namespace MPAid
{
    /// <summary>
    /// Class to run and close Formant plots.
    /// Also serves as the 'middle man' between the C# and Python code.
    /// </summary>
    public static class FormantPlotController
    {
        // Calls to the windows USER32.dll file, to make changes to the Python user interface.

        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;
        /// <summary>
        /// If the formant plot is running in the background, brings it to the foreground.
        /// </summary>
        /// <param name="title">The title of the Formant plot.</param>
        /// <returns>1 if the Formant plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int ShowFormantPlot(string title)
        {
            // Get a handle to the FormantPlot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that FormantPlot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            // Make FormantPlot the foreground application
            SetForegroundWindow(handle);
            ShowWindow(handle, SW_SHOWNORMAL);

            return 0;
        }
        /// <summary>
        /// Returns a value indicating if a Formant plot has been started.
        /// </summary>
        /// <param name="title">The title of the Formant Plot</param>
        /// <returns>1 if the Formant plot is not currently running, 0 if it has been shown successfully.</returns>
        public static int FormantPlotStarted(string title)
        {
            // Get a handle to the FormantPlot application.
            IntPtr handle = FindWindow(null, title);

            // Verify that FormantPlot is a running process.
            if (handle == IntPtr.Zero)
                return 1;

            return 0;
        }

        private static Process FormantPlotExe;
        /// <summary>
        /// Method called by the button to show the Formant plot. 
        /// If there is already a Formant plot running, it is brought into the foreground.
        /// If not, a new process is created.
        /// </summary>
        public static void RunFormantPlot()
        {
            if (FormantPlotStarted(GetFormantPlotTitle()) == 1)
                StartFormantPlot();
            else
                ShowFormantPlot(GetFormantPlotTitle());
        }
        /// <summary>
        /// Used to clean up after a Formant plot has been closed, as the process is simply put into the background.
        /// If this is called when the process does not exist yet, it does nothing.
        /// </summary>
        public static void CloseFormantPlot()
        {
            if ((FormantPlotExe != null) && (!FormantPlotExe.HasExited))
                FormantPlotExe.Kill();
        }
        /// <summary>
        /// Creates a new process, connects it to the python Runner file, and starts the Formant plot. 
        /// Also tidies up after an older process if it is still running.
        /// </summary>
        private static async void StartFormantPlot()
        {
            try
            {
                // Before starting a new process, tidy up any old ones in the background.
                CloseFormantPlot();

                FormantPlotExe = new Process();
                FormantPlotExe.StartInfo.FileName = "PlotRunner.exe";
                FormantPlotExe.StartInfo.UseShellExecute = true;
                FormantPlotExe.StartInfo.WorkingDirectory = Path.Combine(Properties.Settings.Default.FomantFolder, @"dist");
                FormantPlotExe.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                FormantPlotExe.Start();

                // Hang up the main application to wait until it finished starting
                while ((FormantPlotStarted(GetFormantPlotTitle()) == 1)
                    && (!FormantPlotExe.HasExited))
                    // Wait 5 ms before checking if secondary application has started, preventing CPU blocking.
                    await System.Threading.Tasks.Task.Delay(5);
            }
            catch (Exception exp)
            {
                FormantPlotExe = null;
                Console.WriteLine(exp);
            }
        }
        /// <summary>
        /// Getter for the title of the Formant plot.
        /// </summary>
        /// <returns>The title of the formant plot, as a string.</returns>
        public static string GetFormantPlotTitle()
        {
            return (@"Formant Plot");
        }
    }
}
