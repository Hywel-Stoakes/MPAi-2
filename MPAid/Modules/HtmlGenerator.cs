using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace MPAid
{
    /// <summary>
    /// Class handling generation of an HTML report displaying results.
    /// *** Not called anywhere else in the code, marked for deletion ***
    /// </summary>
    class HtmlGenerator
    {
        private string htmlPath = null;
        private HtmlConfig myConfig;
        private const string MaoriEncodingCode = "iso-8859-1";
        /// <summary>
        /// Constructor. Sets the configuration details for the HTML, and uses them to set the path.
        /// </summary>
        /// <param name="config">The configuration details, as an HtmlConfig object.</param>
        public HtmlGenerator(HtmlConfig config)
        {
            myConfig = config;
            htmlPath = config.GetHtmlFullPath();
        }
        /// <summary>
        /// Compares two strings, checking if the first contains the second, or if they are equal.
        /// </summary>
        /// <param name="rec">The string that may contain the other.</param>
        /// <param name="lab">The string that may be contained within the other.</param>
        /// <returns>0 if the strings are equal, 1 if rec contains lab, and 2 otherwise.</returns>
        private int getComparedResult(string rec, string lab)
        {
            if (rec == lab)
                return 0;
            if (rec.Contains(lab))
                return 1;
            if (!rec.Contains(lab))
                return 2;
            return 0;
        }
        /// <summary>
        /// Used to set the class of each row in the table, based on the results of the getComparedResult method in the Examiner class.
        /// </summary>
        /// <param name="result">The integer result of the comparison.</param>
        /// <returns>The html class for the row, as a string.</returns>
        private string resultToClassName(int result)
        {
            if (result == 0)
                return "correct";
            if (result == 1)
                return "warning";
            if (result == 2)
                return "error";
            return null;
        }
        /// <summary>
        /// Builds all of the variables in config into an HTML file.
        /// </summary>
        public void Run()
        {
            StringBuilder strBldr = new StringBuilder();
            StringWriter strWriter = new StringWriter(strBldr);
            HtmlTextWriter writer = new HtmlTextWriter(strWriter);

            string cssContent = Properties.Resources.CssContent;
            string jsContent = Properties.Resources.JsContent;

            //<!DOCTYPE html>
            writer.WriteLine("<!DOCTYPE html>");

            //<html>
            writer.RenderBeginTag(HtmlTextWriterTag.Html);

            // <head>
            writer.RenderBeginTag(HtmlTextWriterTag.Head);

            // <meta charset="iso-8859-1">
            writer.WriteLine("<meta charset=\"iso-8859-1\">");
            
            // <style>
            writer.RenderBeginTag(HtmlTextWriterTag.Style);

            writer.Write(cssContent);
            
            // </style>
            writer.RenderEndTag();

            //<script>
            writer.RenderBeginTag(HtmlTextWriterTag.Script);

            writer.Write(jsContent);

            //</script>
            writer.RenderEndTag();

            // </head>
            writer.RenderEndTag();

            // <body>
            writer.RenderBeginTag(HtmlTextWriterTag.Body);

            // <p style="text-align:center">
            writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, "center");
            writer.RenderBeginTag(HtmlTextWriterTag.H2);
            writer.Write("HTK Results Analysis for ");

            // <strong>
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "blue");
            writer.RenderBeginTag(HtmlTextWriterTag.Strong);
            writer.Write(myConfig.myWord);
            
            // </strong>
            writer.RenderEndTag();

            // </p>
            writer.RenderEndTag();

            //<div class="alert alert-info">
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "alert alert-info");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "quicktips");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "removetips()");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            //<strong>
            writer.RenderBeginTag(HtmlTextWriterTag.Strong);
            writer.Write("Quick Tips! ");

            //</strong>
            writer.RenderEndTag();
            writer.Write("Some of the contents don't work well on Internet Explorer. " +
                "If you encounter any problems, try using Firefox or Google Chrome.");

            //</div>
            writer.RenderEndTag();

            // <table id="t01">
            writer.AddAttribute(HtmlTextWriterAttribute.Id, "t01");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            // <tr>
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            // <th>
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("Correctness");

            // </th>
            writer.RenderEndTag();
            
            // <th>
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("Recognized");

            // </th>
            writer.RenderEndTag();
            
            // <th>
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("User recording");

            // </th>
            writer.RenderEndTag();

            // <th>
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.Write("Sample recording");

            // </th>
            writer.RenderEndTag();

            // </tr>
            writer.RenderEndTag();
            
            if ((myConfig.listRecognized != null) && (myConfig.listRecognized.Count > 0))
            {
                // this counter is for the wave files for the user recording 
                int userRecordingId = 0;

                foreach (string word in myConfig.listRecognized)
                {
                    Examiner examiner = new Examiner(word, myConfig.myWord);
                    int result = examiner.getComparedResult();

                    // <tr class="?">
                    writer.AddAttribute(HtmlTextWriterAttribute.Class, resultToClassName(result));
                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);

                    // <td>
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);

                    // <img src="the path" alt="correctness">
                    writer.AddAttribute(HtmlTextWriterAttribute.Src,
                        ((examiner.wordsMatch()) ? "image/correct.png" : "image/wrong.png"));
                    writer.AddAttribute(HtmlTextWriterAttribute.Alt,
                        ((examiner.wordsMatch()) ? "Correct" : "Wrong"));

                    writer.RenderBeginTag(HtmlTextWriterTag.Img);

                    // </img>
                    writer.RenderEndTag();

                    // </td>
                    writer.RenderEndTag();

                    // <td>
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);

                    writer.Write(word);

                    // </td>
                    writer.RenderEndTag();

                    // <td>
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);

                    // add the user recording to the html report
                    // <audio controls>
                    userRecordingId += 1;
                    writer.RenderBeginTag("audio controls");

                    writer.AddAttribute(HtmlTextWriterAttribute.Src,
                          myConfig.GetRecPath(userRecordingId, HtmlConfig.pathType.partialUserRecPath));
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "audio/wav");
                    
                    // <source>
                    writer.RenderBeginTag("source");
                    writer.Write("Your browser does not support the audio element.");
                   
                    // </source>
                    writer.RenderEndTag();

                    // </audio>
                    writer.RenderEndTag();

                    // </td>
                    writer.RenderEndTag();

                    // <td>
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);

                    // add the user recording to the html report
                    // <audio controls>
                    writer.RenderBeginTag("audio controls");

                    //writer.AddAttribute(HtmlTextWriterAttribute.Src,
                    //    string.Format("sound/sampleRecording-{0}.wav", userRecordingId.ToString("D4")));

                    writer.AddAttribute(HtmlTextWriterAttribute.Src, 
                        myConfig.GetRecPath(userRecordingId, HtmlConfig.pathType.partialSampleRecPath));
                    writer.AddAttribute(HtmlTextWriterAttribute.Type, "audio/wav");

                    // <source>
                    writer.RenderBeginTag("source");
                    writer.Write("Your browser does not support the audio element.");

                    // </source>
                    writer.RenderEndTag();

                    // </audio>
                    writer.RenderEndTag();

                    // </td>
                    writer.RenderEndTag();

                    // </tr>
                    writer.RenderEndTag();
                }
            }
            
            // </table>
            writer.RenderEndTag();

            // <h3>
            writer.RenderBeginTag(HtmlTextWriterTag.H3);
            writer.Write("Overall Results");

            // </h3>
            writer.RenderEndTag();

            // <p style="color:green">
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "green");
            writer.RenderBeginTag(HtmlTextWriterTag.P);

            writer.Write(string.Format("Correctness = {0}", myConfig.correctnessValue));

            // </p>
            writer.RenderEndTag();

            // </body>
            writer.RenderEndTag();

            // </html>
            writer.RenderEndTag();

            File.WriteAllText(htmlPath, writer.InnerWriter.ToString(), Encoding.GetEncoding(MaoriEncodingCode));
        }
    }
}
