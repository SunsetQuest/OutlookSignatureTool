using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



//%username%\AppData\Roaming\Microsoft\Signatures



namespace CreateOutlookSignatureTool
{


    public partial class Form1 : Form
    {
        List<Templete> templates = new List<Templete>();
        string currentTempleteHTML;
        List<FieldsInTemplete> currentFields = new List<FieldsInTemplete>();

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo: make sure no templates works
            string[] paths = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Templates", "*.htm");
            foreach (var path in paths)
            {

                string nameToAdd = Path.GetFileNameWithoutExtension(path);
                // string nameToAdd = Regex.Match(path, @"[^\\]*(?=.htm$)").Value; // another method
                string pathWithoutExt = Path.Combine(Path.GetDirectoryName(path), nameToAdd);
                templates.Add( new Templete
                {
                    FilePath = pathWithoutExt,
                    Name = nameToAdd
                });
            }

            cboTemplate.DataSource = new BindingSource(templates,null);
            cboTemplate.DisplayMember = "Name";
            cboTemplate.SelectionChangeCommitted += (sender1, e1) => NewTempleteSelected();

            NewTempleteSelected();
        }


        void NewTempleteSelected()
        {
            // Lets get the text
            string path = (cboTemplate.SelectedValue as Templete).FilePath + ".htm";
            currentTempleteHTML = File.ReadAllText(path);
            currentTempleteHTML= Regex.Replace(currentTempleteHTML, @"[^\u0000-\u007F]+", string.Empty);

            // Clear the current fields
            currentFields.Clear();

            // Goes through text and finds the fillable fields 
            MatchCollection matches = Regex.Matches(currentTempleteHTML, @"(?:\{\*)([^\{\}]{1,15})(?:\*\})");

            flow.Controls.Clear();

            foreach (Match match in matches)
            {
                foreach (Capture capture in match.Captures)
                {
                    //Console.WriteLine("Index={0}, Value={1}", capture.Index, capture.Value);
                    Label lbl = new Label { Text = match.Groups[1].Value + ":", AutoSize = true};
                    flow.Controls.Add(lbl);
                    TextBox txt = new TextBox { /*Width = flow.Width - 120*/ };
                    txt.TextChanged += (s, e) => RefreshPreview(); 
                    flow.Controls.Add(txt);
                    flow.SetFlowBreak(txt, true);

                    var newField = new FieldsInTemplete { txtBox = txt, Name = match.Value };
                    txt.Tag = newField;
                    currentFields.Add(newField);
                }
            }

            RefreshPreview();
        }

        private void RefreshPreview()
        {
            string newHTML = currentTempleteHTML;
             newHTML = Regex.Replace(newHTML, @"[^\u0000-\u007F]+", string.Empty);
            foreach (var field in currentFields)
            {
                //if (!string.IsNullOrEmpty(field.txtBox.Text))
                    newHTML = newHTML.Replace(field.Name, field.txtBox.Text);
            }
            // Lets update the preview window
            webBrowserPreview.DocumentText = newHTML;
        }

        private void btnApplyToOutlook_Click(object sender, EventArgs e)
        {
            string name = (cboTemplate.SelectedValue as Templete).Name;
            string path = (cboTemplate.SelectedValue as Templete).FilePath;
            //path = Path.Combine(path, name);

            string newHTM = File.ReadAllText(path + ".htm");
            string newRTF = File.ReadAllText(path + ".rtf");
            string newTXT = File.ReadAllText(path + ".txt");

            newHTM = Regex.Replace(newHTM, @"[^\u0000-\u007F]+", string.Empty);
            newRTF = Regex.Replace(newRTF, @"[^\u0000-\u007F]+", string.Empty);
            newTXT = Regex.Replace(newTXT, @"[^\u0000-\u007F]+", string.Empty);

            foreach (var field in currentFields)
            {
                newHTM = newHTM.Replace(field.Name, field.txtBox.Text);
                newRTF = newRTF.Replace(field.Name, field.txtBox.Text);
                newTXT = newTXT.Replace(field.Name, field.txtBox.Text);
            }
            
            string SignaturesPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Microsoft","Signatures");

            string htmPath = Path.Combine(SignaturesPath, name + ".htm");
            File.WriteAllText(htmPath, newHTM);

            string rtfPath = Path.Combine(SignaturesPath, name + ".rtf");
            File.WriteAllText(rtfPath, newRTF);

            string txtPath = Path.Combine(SignaturesPath, name + ".txt");
            File.WriteAllText(txtPath, newTXT);

            //Now Create the folder
            string newPath = Path.Combine(SignaturesPath, name + "_files");
            if (!Directory.Exists(newPath))
                Directory.CreateDirectory(newPath);

            //Copy all the files & Replaces any files with the same name
            //string supportFiles = Path.Combine(SignaturesPath, path + "_files");
            foreach (var source in Directory.GetFiles(path + "_files"))
            {
                string target = Path.Combine(newPath, Path.GetFileName(source));
                File.Copy(source, target, true);
            }



        }


    }

    class Templete
    {
        public string Name { get; set; }
        public string FilePath;
    }

    class FieldsInTemplete
    {
        public string Name { get; set; }
        public TextBox txtBox;
    }
}
