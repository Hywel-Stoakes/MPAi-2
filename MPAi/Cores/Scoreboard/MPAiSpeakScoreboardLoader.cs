using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace MPAi.Cores.Scoreboard
{
    static class MPAiSpeakScoreboardLoader
    {
        private static void ensureUserDirectoryExists(MPAiUser user)
        {
            if (!Directory.Exists(Path.Combine(Properties.Settings.Default.ReportFolder,user.getName())))
            {
                Directory.CreateDirectory(Path.Combine(Properties.Settings.Default.ReportFolder, user.getName()));
            }
        }

        public static string SpeakScoreboardFileAddress(MPAiUser user)
        {
            ensureUserDirectoryExists(user);
            return Path.Combine(Properties.Settings.Default.ReportFolder, user.getName(), "MPAiSpeakScoreboard.txt");

        }

        public static void SaveScoreboard(MPAiSpeakScoreBoard scoreboard)
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
                    foreach (MPAiSpeakScoreBoardSession session in scoreboard.Sessions)
                    {
                        if (session.IsEmpty())
                        {
                            continue;
                        }
                        sw.WriteLine("<Session>");
                        sw.WriteLine("<Date>");
                        sw.WriteLine(session.DateAndTime);
                        sw.WriteLine("</Date>");
                        sw.WriteLine("<Content>");
                        foreach (MPAiSpeakScoreBoardItem item in session.Content)
                        {
                            sw.WriteLine("<Expected>");
                            sw.WriteLine(item.ExpectedText);
                            sw.WriteLine("</Expected>");
                            sw.WriteLine("<Recognised>");
                            sw.WriteLine(item.RecognisedText);
                            sw.WriteLine("</Recognised>");
                            sw.WriteLine("<Analysis>");
                            sw.WriteLine(item.Analysis);
                            sw.WriteLine("</Analysis>");
                        }
                        sw.WriteLine("</Content>");
                        sw.WriteLine("</Session>");
                    }
                    sw.WriteLine("</Scoreboard>");
                }
            }
            File.SetAttributes(SpeakScoreboardFileAddress(scoreboard.User), File.GetAttributes(SpeakScoreboardFileAddress(scoreboard.User)) | FileAttributes.Hidden);
        }

        public static MPAiSpeakScoreBoard LoadScoreboard(MPAiUser user)
        {
            MPAiSpeakScoreBoard scoreboard = new MPAiSpeakScoreBoard(user);

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
                                    while (!line.Equals("</Session>"))
                                    {
                                        DateTime dateAndTime = new DateTime(); ;
                                        line = sr.ReadLine();
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

                                        List<MPAiSpeakScoreBoardItem> content = new List<MPAiSpeakScoreBoardItem>();
                                        if (line.Equals("<Content>"))
                                        {
                                            line = sr.ReadLine();
                                            while (!line.Equals("</Content>"))
                                            {
                                                string expected = "";
                                                string recognised = "";
                                                string analysis = "";

                                                if (line.Equals("<Expected>"))
                                                {
                                                    bool firstline = true;
                                                    line = sr.ReadLine();
                                                    while (!line.Equals("</Expected>"))
                                                    {
                                                        if(firstline)
                                                        {
                                                            firstline = false;
                                                            expected += line;
                                                        } else
                                                        {
                                                            expected += String.Format(@"{0}", Environment.NewLine) + line;
                                                        }
                                                        line = sr.ReadLine();
                                                    }
                                                    line = sr.ReadLine();
                                                }

                                                if (line.Equals("<Recognised>"))
                                                {
                                                    bool firstline = true;
                                                    line = sr.ReadLine();
                                                    while (!line.Equals("</Recognised>"))
                                                    {
                                                        if (firstline)
                                                        {
                                                            firstline = false;
                                                            recognised += line;
                                                        }
                                                        else
                                                        {
                                                            recognised += String.Format(@"{0}", Environment.NewLine) + line;
                                                        }
                                                        line = sr.ReadLine();
                                                    }
                                                    line = sr.ReadLine();
                                                }

                                                if (line.Equals("<Analysis>"))
                                                {
                                                    bool firstline = true;
                                                    line = sr.ReadLine();
                                                    while (!line.Equals("</Analysis>"))
                                                    {
                                                        if (firstline)
                                                        {
                                                            firstline = false;
                                                            analysis += line;
                                                        }
                                                        else
                                                        {
                                                            analysis += String.Format(@"{0}", Environment.NewLine) + line;
                                                        }
                                                        line = sr.ReadLine();
                                                    }
                                                    line = sr.ReadLine();
                                                }
                                                content.Add(new MPAiSpeakScoreBoardItem(expected, recognised, analysis));
                                            }
                                            line = sr.ReadLine();
                                        }
                                        scoreboard.NewScoreBoardSession(dateAndTime, content);
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