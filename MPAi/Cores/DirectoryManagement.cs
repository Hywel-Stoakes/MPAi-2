using MPAi.Modules;
using System;
using System.IO;

namespace MPAi.Cores
{
    static class DirectoryManagement
    {
        private static string scoreboardReportFolder;
        private static string videoFolder;
        private static string audioFolder;
        private static string recordingFolder;
        private static string htkFolder;
        private static string formantFolder;

        public static string ScoreboardReportFolder
        {
            get
            {
                if (scoreboardReportFolder == null)
                {
                    scoreboardReportFolder = Path.Combine(AppDataPath.Path, "ScoreboardReports");
                    Directory.CreateDirectory(scoreboardReportFolder);  // This method does nothing if the directory already exists
                }
                return scoreboardReportFolder;
            }
            set
            {
                scoreboardReportFolder = value;
            }
        }

        public static string VideoFolder
        {
            get
            {
                if (videoFolder == null)
                {
                    videoFolder = Path.Combine(AppDataPath.Path, "Video");
                    Directory.CreateDirectory(videoFolder); // This method does nothing if the directory already exists.
                }
                return videoFolder;
            }
            set
            {
                videoFolder = value;
            }
        }

        public static string AudioFolder
        {
            get
            {
                if (audioFolder == null)
                {
                    audioFolder = Path.Combine(AppDataPath.Path, "Audio");
                    Directory.CreateDirectory(audioFolder); // This method does nothing if the directory already exists.
                }
                return audioFolder;
            }
            set
            {
                audioFolder = value;
            }
        }

        public static string RecordingFolder
        {
            get
            {
                if (recordingFolder == null)
                {
                    recordingFolder = Path.Combine(AppDataPath.Path, "Recording");
                    Directory.CreateDirectory(recordingFolder); // This method does nothing if the directory already exists.
                }
                return recordingFolder;
            }
            set
            {
                recordingFolder = value;
            }
        }

        public static string HTKFolder
        {
            get
            {
                if (htkFolder == null)
                {
                    htkFolder = Path.Combine(AppDataPath.Path, "HTK");
                    Directory.CreateDirectory(htkFolder); // This method does nothing if the directory already exists.
                }
                return htkFolder;
            }
            set
            {
                htkFolder = value;
            }
        }

        public static string FormantFolder
        {
            get
            {
                if (formantFolder == null)
                {
                    formantFolder = Path.Combine(AppDataPath.Path, "Formant");
                    Directory.CreateDirectory(formantFolder); // This method does nothing if the directory already exists.
                }
                return formantFolder;
            }
            set
            {
                formantFolder = value;
            }
        }


        /// <summary>
        /// Writes all values to the settings file, and creates it if it does not already exist.
        /// </summary>
        public static void WritePaths()
        {
            string settingsFile = Path.Combine(AppDataPath.Path, "SystemPaths.dat");

            try
            {
                using (FileStream fs = new FileStream(settingsFile, FileMode.Create))
                {
                    using (BinaryWriter writer = new BinaryWriter(fs))
                    {
                        // This will write default values if they haven't already been set.
                        writer.Write(ScoreboardReportFolder);
                        writer.Write(VideoFolder);
                        writer.Write(AudioFolder);
                        writer.Write(RecordingFolder);
                        writer.Write(HTKFolder);
                        writer.Write(FormantFolder);

                        // Set file to hidden once it has been written to.
                        File.SetAttributes(settingsFile, File.GetAttributes(settingsFile) | FileAttributes.Hidden);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }
    }
}