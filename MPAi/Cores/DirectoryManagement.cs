using MPAi.Modules;
using System.IO;

namespace MPAi.Cores
{
    static class DirectoryManagement
    {
        private static string scoreboardReportFolder;
        private static string videoFolder;
        private static string audioFolder;
        private static string recordingFolder;

        public static string ScoreboardReportFolder
        {
            get
            {
                if (scoreboardReportFolder == null)
                {
                    string path = Path.Combine(AppDataPath.Path, "ScoreboardReports");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return scoreboardReportFolder;
                }
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
                    string path = Path.Combine(AppDataPath.Path, "Video");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return videoFolder;
                }
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
                    string path = Path.Combine(AppDataPath.Path, "Audio");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return audioFolder;
                }
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
                    string path = Path.Combine(AppDataPath.Path, "Recording");
                    ensureDirectoryExists(path);
                    return Path.Combine(path);
                }
                else
                {
                    return recordingFolder;
                }
            }
            set
            {
                recordingFolder = value;
            }
        }

        private static void ensureDirectoryExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}