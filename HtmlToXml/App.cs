using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace HtmlToXml
{
    public partial class App : Form
    {
        Color _textBoxSourceHtmlFolderColor;
        Color _textBoxXmlTemplate;
        Color _textBoxDestinationXmlFolder;

        string _SupportedExtensions = "*.htm,*.html";

        public App()
        {
            InitializeComponent();

			this.textBoxSourceHtmlFolder.Text = @"D:\Documents\Documents\GitHub\HtmlToXml\HtmlToXml\bin\Release\input";
			this.textBoxXmlTemplate.Text = @"D:\Documents\Documents\GitHub\HtmlToXml\HtmlToXml\bin\Release\output\sample_template.xml";
			this.textBoxDestinationXmlFolder.Text = @"D:\Documents\Documents\GitHub\HtmlToXml\HtmlToXml\bin\Release\final";
        }

        private bool IsValidOption(ref TextBox InputTextBox, ref Color DefaultTextBoxBackColor)
        {
            bool IsValid = false;

            if(DefaultTextBoxBackColor == null)
            {
                DefaultTextBoxBackColor = InputTextBox.BackColor;
            }

            if (string.IsNullOrEmpty(InputTextBox.Text))
            {
                InputTextBox.BackColor = Color.LightPink;
            }
            else
            {
                InputTextBox.BackColor = DefaultTextBoxBackColor;
                IsValid = true;
            }

            return IsValid;
        }

        private void buttonSourceHtmlFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog(this) != DialogResult.OK)
                return;

            this.textBoxSourceHtmlFolder.Text = FBD.SelectedPath;
            this.IsValidOption(ref this.textBoxSourceHtmlFolder, ref this._textBoxSourceHtmlFolderColor);
        }

        private void buttonXmlTemplate_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.Multiselect = false;
            OFD.Filter = "XML Files (*.xml)|*.xml";

            if (OFD.ShowDialog(this) != DialogResult.OK)
                return;

            this.textBoxXmlTemplate.Text = OFD.FileName;
            this.IsValidOption(ref this.textBoxXmlTemplate, ref this._textBoxXmlTemplate);
        }

        private void buttonDestinationXmlFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog(this) != DialogResult.OK)
                return;

            this.textBoxDestinationXmlFolder.Text = FBD.SelectedPath;
            this.IsValidOption(ref this.textBoxDestinationXmlFolder, ref this._textBoxDestinationXmlFolder);
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            bool IsValid = true;

            IsValid = this.IsValidOption(ref this.textBoxSourceHtmlFolder, ref this._textBoxSourceHtmlFolderColor) && IsValid;
            IsValid = this.IsValidOption(ref this.textBoxXmlTemplate, ref this._textBoxXmlTemplate) && IsValid;
            IsValid = this.IsValidOption(ref this.textBoxDestinationXmlFolder, ref this._textBoxDestinationXmlFolder) && IsValid;

            if (!IsValid)
                return;

            this.buttonConvert.Enabled = false;

            IEnumerable<string> SupportFiles = Directory.GetFiles(this.textBoxSourceHtmlFolder.Text, "*.*", SearchOption.AllDirectories).Where(s => _SupportedExtensions.Contains(Path.GetExtension(s).ToLower()));
            progressBarStatus.Maximum = SupportFiles.Count();
            foreach (string ImportDataSourceFile in SupportFiles)
            {
				XmlTemplateRW XmlTemplateRWObj = new XmlTemplateRW();
				XmlTemplateRWObj.LoadXmlTemplate(this.textBoxXmlTemplate.Text);
				HtmlReader HtmlReadObj = new HtmlReader();
				if (HtmlReadObj.LoadHtml(ImportDataSourceFile))
				{
					string ImportDataDestinationFile = this.textBoxDestinationXmlFolder.Text + "\\" + Path.GetFileName(ImportDataSourceFile) + ".xml";

					XmlTemplateRWObj.ExecutePlaceholderReplacement(HtmlReadObj);
					XmlTemplateRWObj.Save(ImportDataDestinationFile);
				}

				progressBarStatus.PerformStep();
				Application.DoEvents();
            }

            progressBarStatus.Value = 0;
            this.buttonConvert.Enabled = true;
        }
    }
}
