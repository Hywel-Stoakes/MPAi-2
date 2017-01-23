using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace MPAi.Cores.Scoreboard
{
    /// <summary>
    /// Class that generates an HTML report based on data from a MPAiSpeakScoreBoard object.
    /// </summary>
    static class ReportLauncher
    {
        private static void ensureUserDirectoryExists()
        {
            if (!Directory.Exists(Path.Combine(Properties.Settings.Default.ReportFolder, UserManagement.CurrentUser.getName())))
            {
                Directory.CreateDirectory(Path.Combine(Properties.Settings.Default.ReportFolder, UserManagement.CurrentUser.getName()));
            }
        }
        /// <summary>
        /// The address within the local repository of the generated Speak report.
        /// </summary>
        public static string MPAiSpeakScoreReportHTMLAddress
        {
            get
            {
                ensureUserDirectoryExists();
                return Path.Combine(Properties.Settings.Default.ReportFolder, UserManagement.CurrentUser.getName(), "MPAiSpeakReport.html");
            }
        }

        /// <summary>
        /// The address within the local repository of the generated Sound report.
        /// </summary>
        public static string MPAiSoundScoreReportHTMLAddress
        {
            get
            {
                ensureUserDirectoryExists();
                return Path.Combine(Properties.Settings.Default.ReportFolder, UserManagement.CurrentUser.getName(), "MPAiSoundReport.html");
            }
        }

        /// <summary>
        /// The address within the local repository of the generated CSS File.
        /// </summary>
        public static string ScoreboardReportCSSAddress
        {
            get
            {
                ensureUserDirectoryExists();
                return Path.Combine(Properties.Settings.Default.ReportFolder, UserManagement.CurrentUser.getName(), "Scoreboard.css");
            }
        }

        public static void ShowMPAiSpeakScoreReport()
        {
            if (File.Exists(MPAiSpeakScoreReportHTMLAddress))
            {
                IoController.ShowInBrowser(MPAiSpeakScoreReportHTMLAddress);
            }
        }

        public static void ShowMPAiSoundScoreReport()
        {
            if (File.Exists(MPAiSoundScoreReportHTMLAddress))
            {
                IoController.ShowInBrowser(MPAiSpeakScoreReportHTMLAddress);
            }

        }

        /// <summary>
        /// Generates the CSS File for the report, if it does not already exist.
        /// </summary>
        private static void generateScoreboardCSS()
        {
            if (!File.Exists(ScoreboardReportCSSAddress))
            {
                using (FileStream fs = new FileStream(ScoreboardReportCSSAddress, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("@import url(http://fonts.googleapis.com/css?family=Roboto:400,500,700,300,100);");
                        sw.WriteLine("");
                        sw.WriteLine("body {");
                        sw.WriteLine("  background-color: #7ea4ec;");
                        sw.WriteLine("  font-family: \"Roboto\", helvetica, arial, sans-serif;");
                        sw.WriteLine("  font-size: 16px;");
                        sw.WriteLine("  font-weight: 400;");
                        sw.WriteLine("  text-rendering: optimizeLegibility;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("div.title {");
                        sw.WriteLine("	text-align: center;");
                        sw.WriteLine("  display: block;");
                        sw.WriteLine("  margin: auto;");
                        sw.WriteLine("  max-width: 600px;");
                        sw.WriteLine("  padding:5px;");
                        sw.WriteLine("  width: 100%;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine(".title h3 {");
                        sw.WriteLine("   color: #fafafa;");
                        sw.WriteLine("   font-size: 36px;");
                        sw.WriteLine("   font-weight: 400;");
                        sw.WriteLine("   font-style: bold;");
                        sw.WriteLine("   font-family: \"Roboto\", helvetica, arial, sans-serif;");
                        sw.WriteLine("   text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);");
                        sw.WriteLine("   text-transform:uppercase;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("div.table-title {");
                        sw.WriteLine("	text-align: center;");
                        sw.WriteLine("  display: block;");
                        sw.WriteLine("  margin: auto;");
                        sw.WriteLine("  max-width: 600px;");
                        sw.WriteLine("  padding:5px;");
                        sw.WriteLine("  width: 100%;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine(".table-title h3 {");
                        sw.WriteLine("   color: #fafafa;");
                        sw.WriteLine("   font-size: 28px;");
                        sw.WriteLine("   font-weight: 400;");
                        sw.WriteLine("   font-style: normal;");
                        sw.WriteLine("   font-family: \"Roboto\", helvetica, arial, sans-serif;");
                        sw.WriteLine("   text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);");
                        sw.WriteLine("   text-transform:uppercase;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine(".table-fill {");
                        sw.WriteLine("  background: white;");
                        sw.WriteLine("  border-radius:3px;");
                        sw.WriteLine("  border-collapse: collapse;");
                        sw.WriteLine("  height: 320px;");
                        sw.WriteLine("  margin: auto;");
                        sw.WriteLine("  padding:50px;");
                        sw.WriteLine("  width: 90%;");
                        sw.WriteLine("  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.1);");
                        sw.WriteLine("  animation: float 5s infinite;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("th {");
                        sw.WriteLine("  color:#D5DDE5;");
                        sw.WriteLine("  background:#1b1e24;");
                        sw.WriteLine("  border-bottom:4px solid #9ea7af;");
                        sw.WriteLine("  border-right: 1px solid #343a45;");
                        sw.WriteLine("  font-size:23px;");
                        sw.WriteLine("  font-weight: 100;");
                        sw.WriteLine("  padding:24px;");
                        sw.WriteLine("  text-align:left;");
                        sw.WriteLine("  text-shadow: 0 1px 1px rgba(0, 0, 0, 0.1);");
                        sw.WriteLine("  vertical-align:middle;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("th:first-child {");
                        sw.WriteLine("  border-top-left-radius:3px;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("th:last-child {");
                        sw.WriteLine("  border-top-right-radius:3px;");
                        sw.WriteLine("  border-right:none;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr {");
                        sw.WriteLine("  border-top: 1px solid #C1C3D1;");
                        sw.WriteLine("  border-bottom: 1px solid #C1C3D1;");
                        sw.WriteLine("  color:#666B85;");
                        sw.WriteLine("  font-size:16px;");
                        sw.WriteLine("  font-weight:normal;");
                        sw.WriteLine("  text-shadow: 0 1px 1px rgba(256, 256, 256, 0.1);");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:hover td{");
                        sw.WriteLine("  background:#8E90aa;");
                        sw.WriteLine("  color:#FFFFFF;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:first-child {");
                        sw.WriteLine("  border-top:none;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:last-child {");
                        sw.WriteLine("  border-bottom:none;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:nth-child(odd) td {");
                        sw.WriteLine("  background:#EBEBEB;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:nth-child(odd):hover td {");
                        sw.WriteLine("  background:#8E90aa;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:last-child td:first-child {");
                        sw.WriteLine("  border-bottom-left-radius:3px;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:last-child td:last-child {");
                        sw.WriteLine("  border-bottom-right-radius:3px;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr.good-colour td {");
                        sw.WriteLine("  background:#A7FF66;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:hover.good-colour td {");
                        sw.WriteLine("  background:#88FF33;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr.medium-colour td {");
                        sw.WriteLine("  background:#FFDD66;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:hover.medium-colour td {");
                        sw.WriteLine("  background:#FFD333");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr.bad-colour  td {");
                        sw.WriteLine("  background:#FF666A;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("tr:hover.bad-colour  td {");
                        sw.WriteLine("  background:#FF333A;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("td {");
                        sw.WriteLine("  white-space:pre;");
                        sw.WriteLine("  background:#FFFFFF;");
                        sw.WriteLine("  padding:20px;");
                        sw.WriteLine("  text-align:left;");
                        sw.WriteLine("  vertical-align:middle;");
                        sw.WriteLine("  font-weight:300;");
                        sw.WriteLine("  font-size:18px;");
                        sw.WriteLine("  text-shadow: -1px -1px 1px rgba(0, 0, 0, 0.1);");
                        sw.WriteLine("  border-right: 1px solid #C1C3D1;");
                        sw.WriteLine("}");
                        sw.WriteLine("");
                        sw.WriteLine("td:last-child {");
                        sw.WriteLine("  border-right: 0px;");
                        sw.WriteLine("}");
                    }
                }
            }
        }
        /// <summary>
        /// Generates an HTML score report based on an input scoreboard.
        /// </summary>
        /// <param name="scoreboard">The scoreboard to generate an HTML report of.</param>
        public static void GenerateMPAiSpeakScoreHTML(MPAiSpeakScoreBoard scoreboard)
        {
            scoreboard.SaveScoreBoardToFile();

            if(!File.Exists(ScoreboardReportCSSAddress))
            {
                generateScoreboardCSS();
            }
            using (FileStream fs = new FileStream(MPAiSpeakScoreReportHTMLAddress, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Html);
                        // Table settings
                        htw.RenderBeginTag(HtmlTextWriterTag.Head);
                        htw.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
                        htw.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
                        htw.AddAttribute(HtmlTextWriterAttribute.Href, "Scoreboard.css");
                        htw.RenderBeginTag(HtmlTextWriterTag.Link);
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        //Scoreboard Title
                        htw.RenderBeginTag(HtmlTextWriterTag.Body);
                        htw.AddAttribute(HtmlTextWriterAttribute.Class, "title");
                        htw.RenderBeginTag(HtmlTextWriterTag.Div);
                        htw.RenderBeginTag(HtmlTextWriterTag.H3);
                        htw.Write(scoreboard.User.getName() + "'s MPAi Speak Pronunciation Scoreboard");
                        htw.RenderEndTag();
                        htw.RenderEndTag();

                        foreach(MPAiSpeakScoreBoardSession session in scoreboard.Sessions)
                        {
                            if (session.IsEmpty())
                            {
                                continue;
                            }
                            //Table Title
                            htw.AddAttribute(HtmlTextWriterAttribute.Class, "table-title");
                            htw.RenderBeginTag(HtmlTextWriterTag.Div);
                            htw.RenderBeginTag(HtmlTextWriterTag.H3);
                            htw.Write(session.DateAndTime.ToString());
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            // Header row of the table
                            htw.AddAttribute(HtmlTextWriterAttribute.Class, "table-fill");
                            htw.RenderBeginTag(HtmlTextWriterTag.Table);
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Expecting Word");
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Recognized Word");
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Similarity Score");
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Analysis Tips");
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            // Table rows
                            foreach (MPAiSpeakScoreBoardItem item in session.Content)
                            {
                                htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.ExpectedText);
                                htw.RenderEndTag();
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.RecognisedText);
                                htw.RenderEndTag();
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.Similarity.ToString("0.0%"));
                                htw.RenderEndTag();
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.Analysis);
                                htw.RenderEndTag();
                                htw.RenderEndTag();
                            }
                            // Correctness score
                            float correctness = session.OverallCorrectnessPercentage;
                            if (correctness >= 0.8)
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "good-colour");
                            }
                            else if (correctness >= 0.5)
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "medium-colour");
                            }
                            else
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "bad-colour");
                            }
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                            htw.AddAttribute(HtmlTextWriterAttribute.Colspan, "4");
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write("Pronunciation is " + correctness.ToString("0.0%") + " Correct");
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            htw.RenderEndTag();

                        }
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                    }
                }
            }
        }

        public static void GenerateMPAiSoundScoreHTML(MPAiSoundScoreBoard scoreboard)
        {
            scoreboard.SaveScoreBoardToFile();

            if (!File.Exists(ScoreboardReportCSSAddress))
            {
                generateScoreboardCSS();
            }
            using (FileStream fs = new FileStream(MPAiSoundScoreReportHTMLAddress, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Html);
                        // Table settings
                        htw.RenderBeginTag(HtmlTextWriterTag.Head);
                        htw.AddAttribute(HtmlTextWriterAttribute.Rel, "stylesheet");
                        htw.AddAttribute(HtmlTextWriterAttribute.Type, "text/css");
                        htw.AddAttribute(HtmlTextWriterAttribute.Href, "Scoreboard.css");
                        htw.RenderBeginTag(HtmlTextWriterTag.Link);
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        //Scoreboard Title
                        htw.RenderBeginTag(HtmlTextWriterTag.Body);
                        htw.AddAttribute(HtmlTextWriterAttribute.Class, "title");
                        htw.RenderBeginTag(HtmlTextWriterTag.Div);
                        htw.RenderBeginTag(HtmlTextWriterTag.H3);
                        htw.Write(scoreboard.User.getName() + "'s MPAi Sound Pronunciation Scoreboard");
                        htw.RenderEndTag();
                        htw.RenderEndTag();

                        foreach (MPAiSoundScoreBoardSession session in scoreboard.Sessions)
                        {
                            if(session.IsEmpty())
                            {
                                continue;
                            }
                            //Table Title
                            htw.AddAttribute(HtmlTextWriterAttribute.Class, "table-title");
                            htw.RenderBeginTag(HtmlTextWriterTag.Div);
                            htw.RenderBeginTag(HtmlTextWriterTag.H3);
                            htw.Write(session.DateAndTime.ToString());
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            // Header row of the table
                            htw.AddAttribute(HtmlTextWriterAttribute.Class, "table-fill");
                            htw.RenderBeginTag(HtmlTextWriterTag.Table);
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Vowel");
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Th);
                            htw.Write("Correctness Percentage");
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            // Table rows
                            foreach (MPAiSoundScoreBoardItem item in session.Content)
                            {
                                htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.Vowel);
                                htw.RenderEndTag();
                                htw.RenderBeginTag(HtmlTextWriterTag.Td);
                                htw.Write(item.CorrectnessPercentage);
                                htw.RenderEndTag();
                                htw.RenderEndTag();
                            }
                            // Correctness score
                            float correctness = session.OverallCorrectnessPercentage / 100;
                            if (correctness >= 0.8)
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "good-colour");
                            }
                            else if (correctness >= 0.5)
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "medium-colour");
                            }
                            else
                            {
                                htw.AddAttribute(HtmlTextWriterAttribute.Class, "bad-colour");
                            }
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                            htw.AddAttribute(HtmlTextWriterAttribute.Colspan, "2");
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write("Pronunciation is " + correctness.ToString("0.0%") + " Correct");
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                        }
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                    }
                }
            }
        }
    }
}
