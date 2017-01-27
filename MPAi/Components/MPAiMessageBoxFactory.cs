using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MPAi.NewForms
{
    public static class MPAiMessageBoxFactory
    {
        public static MPAiMessageBoxResults Show(string message)
        {
            MPAiMessageBoxTemplate messageBox = new MPAiMessageBoxTemplate();
            messageBox.SetMessageText(message);
            messageBox.ShowDialog();
            return MPAiMessageBoxResults.None;
        }

        public static MPAiMessageBoxResults Show(string message, MPAiMessageBoxButtons buttons)
        {
            MPAiMessageBoxTemplate messageBox = new MPAiMessageBoxTemplate();
            messageBox.SetMessageText(message);
            switch (buttons)
            {
                case MPAiMessageBoxButtons.OK:
                    messageBox.SetPanel3Button(MPAiButtonFactory.OKButton());
                    break;
                case MPAiMessageBoxButtons.OKCancel:
                    messageBox.SetPanel1Button(MPAiButtonFactory.CancelButton());
                    messageBox.SetPanel3Button(MPAiButtonFactory.OKButton());
                    break;
                case MPAiMessageBoxButtons.YesNo:
                    messageBox.SetPanel1Button(MPAiButtonFactory.YesButton());
                    messageBox.SetPanel3Button(MPAiButtonFactory.NoButton());
                    break;
                case MPAiMessageBoxButtons.YesNoCancel:
                    messageBox.SetPanel1Button(MPAiButtonFactory.YesButton());
                    messageBox.SetPanel2Button(MPAiButtonFactory.NoButton());
                    messageBox.SetPanel3Button(MPAiButtonFactory.CancelButton());
                    break;
            }
            messageBox.ShowDialog();
            return MPAiMessageBoxResults.None;
        }
    }

    static class MPAiButtonFactory {

        public static MPAiButton YesButton()
        {
            MPAiButton button = new MPAiButton();
            button.Anchor = System.Windows.Forms.AnchorStyles.None;
            button.Name = "yesButton";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Yes";
            button.UseVisualStyleBackColor = true;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Dock = System.Windows.Forms.DockStyle.None;
            button.MaximumSize = new System.Drawing.Size(75,23);

            return button;
        }

        public static MPAiButton NoButton()
        {
            MPAiButton button = new MPAiButton();
            button.Anchor = System.Windows.Forms.AnchorStyles.None;
            button.Name = "noButton";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "No";
            button.UseVisualStyleBackColor = true;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Dock = System.Windows.Forms.DockStyle.None;
            button.MaximumSize = new System.Drawing.Size(75, 23);

            return button;
        }

        public static MPAiButton OKButton()
        {
            MPAiButton button = new MPAiButton();
            button.Anchor = System.Windows.Forms.AnchorStyles.None;
            button.Name = "okButton";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Okay";
            button.UseVisualStyleBackColor = true;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Dock = System.Windows.Forms.DockStyle.None;
            button.MaximumSize = new System.Drawing.Size(75, 23);

            return button;
        }

        public static MPAiButton CancelButton()
        {
            MPAiButton button = new MPAiButton();
            button.Anchor = System.Windows.Forms.AnchorStyles.None;
            button.Name = "cancelButton";
            button.Size = new System.Drawing.Size(75, 23);
            button.Text = "Cancel";
            button.UseVisualStyleBackColor = true;
            button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            button.Dock = System.Windows.Forms.DockStyle.None;
            button.MaximumSize = new System.Drawing.Size(75, 23);

            return button;
        }
    }

    public enum MPAiMessageBoxButtons
    {
        OK, OKCancel, YesNo, YesNoCancel
    }

    public enum MPAiMessageBoxResults
    {
        OK, Cancel, Yes, No, None
    }
}
