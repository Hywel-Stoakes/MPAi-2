using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MPAi.Cores.Scoreboard
{
    static class MPAiSoundScoreboardLoader
    {
        private static void ensureUserDirectoryExists(MPAiUser user)
        {
            if (!Directory.Exists(Path.Combine(Properties.Settings.Default.ReportFolder, user.getName())))
            {
                Directory.CreateDirectory(Path.Combine(Properties.Settings.Default.ReportFolder, user.getName()));
            }
        }

        public static string SpeakScoreboardFileAddress(MPAiUser user)
        {
            ensureUserDirectoryExists(user);
            return Path.Combine(Properties.Settings.Default.ReportFolder, user.getName(), "MPAiSoundScoreboard.txt");

        }

        public static void SaveScoreboard(MPAiSoundScoreBoard scoreboard)
        {
            if (scoreboard.IsEmpty())
            {
                return;
            }
            if (File.Exists(SpeakScoreboardFileAddress(scoreboard.User)))
            {
                File.Delete(SpeakScoreboardFileAddress(scoreboard.User));
            }
            using (FileStream fs = new FileStream(SpeakScoreboardFileAddress(scoreboard.User), FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("<Scoreboard>");
                    foreach (MPAiSoundScoreBoardSession session in scoreboard.Sessions)
                    {
                        if (session.IsEmpty())
                        {
                            continue;
                        }
                        sw.WriteLine("<Session>");
                        sw.WriteLine("<Date>");
                        sw.WriteLine(session.DateAndTime);
                        sw.WriteLine("</Date>");
                        sw.WriteLine("<OverallCorrectnessPercentage>");
                        sw.WriteLine(session.OverallCorrectnessPercentage);
                        sw.WriteLine("</OverallCorrectnessPercentage>");
                        sw.WriteLine("<Content>");
                        foreach (MPAiSoundScoreBoardItem item in session.Content)
                        {
                            sw.WriteLine("<Vowel>");
                            sw.WriteLine(item.Vowel);
                            sw.WriteLine("</Vowel>");
                            sw.WriteLine("<CorrectnessPercentage>");
                            sw.WriteLine(item.CorrectnessPercentage);
                            sw.WriteLine("</CorrectnessPercentage>");
                        }
                        sw.WriteLine("</Content>");
                        sw.WriteLine("</Session>");
                    }
                    sw.WriteLine("</Scoreboard>");
                }
            }
            File.SetAttributes(SpeakScoreboardFileAddress(scoreboard.User), File.GetAttributes(SpeakScoreboardFileAddress(scoreboard.User)) | FileAttributes.Hidden);
        }

        public static MPAiSoundScoreBoard LoadScoreboard(MPAiUser user)
        {
            MPAiSoundScoreBoard scoreboard = new MPAiSoundScoreBoard(user);

            if (File.Exists(SpeakScoreboardFileAddress(scoreboard.User)))
            {
                using (FileStream fs = new FileStream(SpeakScoreboardFileAddress(scoreboard.User), FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string line;
                        line = sr.ReadLine();
                        //MessageBox.Show(line + ": <Scoreboard> expected");
                        if (line.Equals("<Scoreboard>"))
                        {
                            //MessageBox.Show("Success, entered <Scoreboard>");
                            while (!line.Equals("</Scoreboard>"))
                            {
                                line = sr.ReadLine();
                                while (line.Equals("<Session>"))
                                {
                                    line = sr.ReadLine();
                                    while (!line.Equals("</Session>"))
                                    {
                                        DateTime dateAndTime = new DateTime(); ;
                                        if (line.Equals("<Date>"))
                                        {
                                            line = sr.ReadLine();
                                            while (!line.Equals("</Date>"))
                                            {
                                                dateAndTime = new DateTime();
                                                if (!DateTime.TryParse(line, out dateAndTime))
                                                {
                                                    throw new FileLoadException("Date could not be read");
                                                }
                                                line = sr.ReadLine();
                                            }
                                            line = sr.ReadLine();
                                        }

                                        float overallCorrectnessPercentage = -1;
                                        if (line.Equals("<OverallCorrectnessPercentage>"))
                                        {
                                            line = sr.ReadLine();
                                            while (!line.Equals("</OverallCorrectnessPercentage>"))
                                            {
                                                if (!float.TryParse(line, out overallCorrectnessPercentage))
                                                {
                                                    throw new FileLoadException("Overall Correctness Percentage could not be read");
                                                }
                                                line = sr.ReadLine();
                                            }
                                            line = sr.ReadLine();
                                        }

                                        List<MPAiSoundScoreBoardItem> content = new List<MPAiSoundScoreBoardItem>();
                                        if (line.Equals("<Content>"))
                                        {
                                            line = sr.ReadLine();
                                            while (!line.Equals("</Content>"))
                                            {
                                                string vowel = "";
                                                float correctnessPercentage = -1;

                                                if (line.Equals("<Vowel>"))
                                                {
                                                    bool firstline = true;
                                                    line = sr.ReadLine();
                                                    while (!line.Equals("</Vowel>"))
                                                    {
                                                        if (firstline)
                                                        {
                                                            firstline = false;
                                                            vowel += line;
                                                        }
                                                        else
                                                        {
                                                            vowel += String.Format(@"{0}", Environment.NewLine) + line;
                                                        }
                                                        line = sr.ReadLine();
                                                    }
                                                    line = sr.ReadLine();
                                                }

                                                if (line.Equals("<CorrectnessPercentage>"))
                                                {
                                                    bool firstline = true;
                                                    line = sr.ReadLine();
                                                    while (!line.Equals("</CorrectnessPercentage>"))
                                                    {
                                                        if (!float.TryParse(line, out correctnessPercentage)) 
                                                        {
                                                            throw new FileLoadException("Correctness Percentage could not be read");
                                                        }    
                                                        line = sr.ReadLine();
                                                    }
                                                    line = sr.ReadLine();
                                                }
                                                content.Add(new MPAiSoundScoreBoardItem(vowel, correctnessPercentage));
                                            }
                                            line = sr.ReadLine();
                                        }
                                        MPAiSoundScoreBoardSession session = scoreboard.NewScoreBoardSession(dateAndTime, content);
                                        session.OverallCorrectnessPercentage = overallCorrectnessPercentage;
                                    }
                                    line = sr.ReadLine();
                                }
                            }
                        }
                    }
                }
            }
            return scoreboard;
        }
    }

}
