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

        
    }
}