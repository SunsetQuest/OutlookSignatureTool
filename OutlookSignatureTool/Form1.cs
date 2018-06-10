using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;


namespace CreateOutlookSignatureTool
{
    public partial class Form1 : Form
    {
        List<SignatureTemplate> templates = new List<SignatureTemplate>();
        string currentTemplateHTML;
        List<FieldsInTemplate> currentFields = new List<FieldsInTemplate>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] paths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Templates", "*.htm");

            //Make sure no templates works
            if (paths.Length == 0)
            {
                MessageBox.Show(this, "There was no Templates found in the Templates folder.", "Missing Email Templates", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Close();
                return;
            }
            
            foreach (var path in paths)
            {
                string nameToAdd = Path.GetFileNameWithoutExtension(path);
                string pathWithoutExt = Path.Combine(Path.GetDirectoryName(path), nameToAdd);
                templates.Add( new SignatureTemplate
                {
                    FilePath = pathWithoutExt,
                    Name = nameToAdd
                });
            }

            cboTemplate.DataSource = new BindingSource(templates,null);
            cboTemplate.DisplayMember = "Name";
            cboTemplate.SelectionChangeCommitted += (sender1, e1) => NewTemplateSelected();

            NewTemplateSelected();
        }


        void NewTemplateSelected()
        {
            // Let's get the text
            string path = (cboTemplate.SelectedValue as SignatureTemplate).FilePath + ".htm";
            currentTemplateHTML = File.ReadAllText(path);
            currentTemplateHTML= Regex.Replace(currentTemplateHTML, @"[^\u0000-\u007F]+", string.Empty);

            // Clear the current fields
            currentFields.Clear();

            // Goes through text and finds the fillable fields 
            MatchCollection matches = Regex.Matches(currentTemplateHTML, @"(?:\{\*)([^\{\}]{1,15})(?:\*\})");

            flow.Controls.Clear();
            Label spacer = new Label();
            flow.Controls.Add(spacer);
            flow.SetFlowBreak(spacer, true);

            foreach (Match match in matches)
            {
                Label lbl = new Label { Text = match.Groups[1].Value + ":", Height= 25, Width=120, TextAlign = System.Drawing.ContentAlignment.MiddleRight};

                flow.Controls.Add(lbl);
                TextBox txt = new TextBox { Width = 300 };
                txt.TextChanged += (s, e) => RefreshPreview(); 
                flow.Controls.Add(txt);
                flow.SetFlowBreak(txt, true);

                var newField = new FieldsInTemplate { TxtBox = txt, Name = match.Value };
                txt.Tag = newField;
                currentFields.Add(newField);
            }

            RefreshPreview();
        }

        private void RefreshPreview()
        {

            string newHTML = currentTemplateHTML;
             newHTML = Regex.Replace(newHTML, @"[^\u0000-\u007F]+", string.Empty);
            foreach (var field in currentFields)
            {
                //if (!string.IsNullOrEmpty(field.txtBox.Text))
                    newHTML = newHTML.Replace(field.Name, field.TxtBox.Text);
            }

            // The WebBrowser control needs to full path to display properly. 
            SignatureTemplate sig = cboTemplate.SelectedValue as SignatureTemplate;
            newHTML = newHTML.Replace($"{sig.Name}_files/", $"{sig.FilePath}_files/");

            // Lets update the preview window
            webBrowserPreview.DocumentText = newHTML;
        }

        private void btnApplyToOutlook_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "Please Wait...";
            lblMsg.Visible = true;

            string name = (cboTemplate.SelectedValue as SignatureTemplate).Name;
            string path = (cboTemplate.SelectedValue as SignatureTemplate).FilePath;

            try
            {
                string newHTM = File.ReadAllText(path + ".htm");
                //string newRTF = File.ReadAllText(path + ".rtf");
                string newTXT = File.ReadAllText(path + ".txt");

                newHTM = Regex.Replace(newHTM, @"[^\u0000-\u007F]+", string.Empty);
                //newRTF = Regex.Replace(newRTF, @"[^\u0000-\u007F]+", string.Empty);
                newTXT = Regex.Replace(newTXT, @"[^\u0000-\u007F]+", string.Empty);

                foreach (var field in currentFields)
                {
                    newHTM = newHTM.Replace(field.Name, field.TxtBox.Text);
                    //newRTF = newRTF.Replace(field.Name, field.TxtBox.Text);
                    newTXT = newTXT.Replace(field.Name, field.TxtBox.Text);
                }

                string SignaturesPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Microsoft", "Signatures");

                Directory.CreateDirectory(SignaturesPath);

                string htmPath = Path.Combine(SignaturesPath, name + ".htm");
                File.WriteAllText(htmPath, newHTM);

                string rtfPath = Path.Combine(SignaturesPath, name + ".rtf");
                File.WriteAllText(rtfPath, "");

                string txtPath = Path.Combine(SignaturesPath, name + ".txt");
                File.WriteAllText(txtPath, newTXT);

                // Now Create the folder
                string newPath = Path.Combine(SignaturesPath, name + "_files");
                if (!Directory.Exists(newPath))
                    Directory.CreateDirectory(newPath);

                foreach (var source in Directory.GetFiles(path + "_files"))
                {
                    string target = Path.Combine(newPath, Path.GetFileName(source));
                    File.Copy(source, target, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "We could not save the files to the Outlook folder. Please use another method or contact your IT department.\r\n\r\n" 
                    + $"Message: {ex.Message}\r\n"
                    + $"Source: {ex.Source}\r\n"
                    + $"StackTrace: {ex.StackTrace}"
                    , "Signature update error"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                // Hide the "Please Wait..." message.
                lblMsg.Visible = false;
                return;
            }

            try
            {
                SetOutlooksDefaultSignature(name);
                var result = MessageBox.Show(this, "Your Outlook signature has been updated. Would you like to Close this app?"
                    , "Congratulations"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "The signature has been added to Outlook but still needs to be set as the default.\r\n"
                    + $"Message: {ex.Message}\r\n"
                    + $"Source: {ex.Source}\r\n"
                    + $"StackTrace: {ex.StackTrace}"
                    , "One final thing is needed"
                    , MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                System.Diagnostics.Process.Start("Docs\\How to set your signature to automatically show on new emails.pdf");
            }

            // Hide the "Please Wait..." message.
            lblMsg.Visible = false;
        }

        /// <summary>
        /// Sets Default Signature in Outlook
        /// </summary>
        private static void SetOutlooksDefaultSignature(string signature)
        {
            // Source: https://stackoverflow.com/a/23151372/2352507 (2018)
            Word.Application oWord = new Word.Application();
            Word.EmailOptions oOptions;
            oOptions = oWord.Application.EmailOptions;
            oOptions.EmailSignature.NewMessageSignature = signature;
            //oOptions.EmailSignature.ReplyMessageSignature = signature;
            // Release Word
            if (oOptions != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oOptions);
            if (oWord != null) System.Runtime.InteropServices.Marshal.ReleaseComObject(oWord);
        }

    }

    class SignatureTemplate
    {
        public string Name { get; set; }
        public string FilePath;
    }

    class FieldsInTemplate
    {
        public string Name { get; set; }
        public TextBox TxtBox;
    }
}
