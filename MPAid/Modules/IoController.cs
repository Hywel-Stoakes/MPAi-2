using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace MPAid
{
    /// <summary>
    /// Handles running other programs (Such as Notepad or a browser) from within this one.
    /// Also has methods to get the MPAid directory.
    /// Doesn't store state, and is accessed from many classes, so was made static.
    /// </summary>
    public static class IoController
    {

        /// <summary>
        /// Gets the current MPAid directory.
        /// </summary>
        /// <returns>The current MPAid directory, as a string.</returns>
        public static string GetAppDataDir()
        {
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid");
            }
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MPAid";
        }

        /// <summary>
        /// Gets the input user's directory in the MPAid directory.
        /// </summary>
        /// <param name="user">The MPAiUser object representing the user who owns the directory.</param>
        /// <returns>The directory of that user, as a string.</returns>
        public static string GetAppDataDir(MPAiUser user)
        {
            return (GetAppDataDir() + Path.DirectorySeparatorChar + user.getName()) + "\\";
        }

        /// <summary>
        /// Loads the user's default browser to view the specified HTML file.
        /// </summary>
        /// <param name="htmlPath">The file path of the HTML file to be viewed, as a string.</param>
        public static void ShowInBrowser(string htmlPath)
        {
            Process browser = new Process();
            browser.StartInfo.FileName = htmlPath;
            browser.Start();
        }

        /// <summary>
        /// Loads Notepad to view the specified text file.
        /// </summary>
        /// <param name="FilePath">The file path of the text file to be viewed, as a string.</param>
        public static void ShowInNotepad(string FilePath)
        {
            Process notepad = new Process();
            notepad.StartInfo.FileName = "notepad";
            notepad.StartInfo.Arguments = FilePath;
            notepad.Start();
        }

        /// <summary>
        /// Loads File Explorer to view the specified directory.
        /// </summary>
        /// <param name="FilePath">The file path of the directory to be viewed, as a string.</param>
        public static void ShowInExplorer(string FilePath)
        {
            Process explorer = new Process();
            explorer.StartInfo.FileName = "explorer";
            explorer.StartInfo.Arguments = FilePath;
            explorer.Start();
        }

    }
}
