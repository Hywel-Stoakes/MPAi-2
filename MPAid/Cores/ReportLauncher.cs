using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace MPAid.Cores
{
    /// <summary>
    /// Class that generates an HTML report based on data from a ScoreBoard object.
    /// </summary>
    class ReportLauncher
    {
        /// <summary>
        /// The address within the local repository of the generated report.
        /// </summary>
        public string ReportAddr
        {
            get
            {
                return Path.Combine(Properties.Settings.Default.ReportFolder, "Report.html");
            }
        }
        /// <summary>
        /// Generates an HTML score report based on an input scoreboard.
        /// </summary>
        /// <param name="scoreboard">The scoreboard to generate an HTML report of.</param>
        public void GenerateHTML(ScoreBoard scoreboard)
        {
            using ( FileStream fs = new FileStream(ReportAddr, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                    {
                        htw.RenderBeginTag(HtmlTextWriterTag.Html);
                        // Table settings
                        htw.RenderBeginTag(HtmlTextWriterTag.Head);
                        htw.RenderBeginTag(HtmlTextWriterTag.Style);
                        htw.WriteLine(@"table, th, td {border: 1px solid black; border - collapse: collapse;}");
                        htw.WriteLine(@"th, td {padding: 15px;}");
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        // Header row of the table
                        htw.RenderBeginTag(HtmlTextWriterTag.Body);
                        htw.RenderBeginTag(HtmlTextWriterTag.Table);
                        htw.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");
                        htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                        htw.RenderBeginTag(HtmlTextWriterTag.Th);
                        htw.Write(@"Expecting Word");
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Th);
                        htw.Write(@"Recognized Word");
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Th);
                        htw.Write(@"Similarity Score");
                        htw.RenderEndTag();
                        htw.RenderBeginTag(HtmlTextWriterTag.Th);
                        htw.Write(@"Analysis Tips");
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        // Table rows
                        foreach (ScoreBoardItem item in scoreboard.Content)
                        {
                            htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write(item.ExpectingText);
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write(item.RecognisedText);
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write(item.Similarity(SimilarityAlgorithm.DamereauLevensheinDistanceAlgorithm).ToString("0.0%"));
                            htw.RenderEndTag();
                            htw.RenderBeginTag(HtmlTextWriterTag.Td);
                            htw.Write(item.Analysis);
                            htw.RenderEndTag();
                            htw.RenderEndTag();
                        }
                        htw.RenderEndTag();
                        // Correctness score
                        htw.RenderBeginTag(HtmlTextWriterTag.Tr);
                        htw.RenderBeginTag(HtmlTextWriterTag.Td);
                        htw.Write(@"The correctness is: " + scoreboard.CalculateCorrectness.ToString("0.0%"));
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                        htw.RenderEndTag();
                    }
                }
            }
        }
    }
}
