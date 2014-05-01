namespace HtmlToXml
{
    partial class App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(App));
            this.labelSourceHtmlFolder = new System.Windows.Forms.Label();
            this.textBoxSourceHtmlFolder = new System.Windows.Forms.TextBox();
            this.buttonSourceHtmlFolder = new System.Windows.Forms.Button();
            this.buttonXmlTemplate = new System.Windows.Forms.Button();
            this.textBoxXmlTemplate = new System.Windows.Forms.TextBox();
            this.labelXmlTemplate = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.buttonDestinationXmlFolder = new System.Windows.Forms.Button();
            this.textBoxDestinationXmlFolder = new System.Windows.Forms.TextBox();
            this.labelDestinationXmlFolder = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSourceHtmlFolder
            // 
            this.labelSourceHtmlFolder.AutoSize = true;
            this.labelSourceHtmlFolder.Location = new System.Drawing.Point(7, 10);
            this.labelSourceHtmlFolder.Name = "labelSourceHtmlFolder";
            this.labelSourceHtmlFolder.Size = new System.Drawing.Size(97, 13);
            this.labelSourceHtmlFolder.TabIndex = 0;
            this.labelSourceHtmlFolder.Text = "Source Html Folder";
            // 
            // textBoxSourceHtmlFolder
            // 
            this.textBoxSourceHtmlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSourceHtmlFolder.Location = new System.Drawing.Point(10, 26);
            this.textBoxSourceHtmlFolder.Name = "textBoxSourceHtmlFolder";
            this.textBoxSourceHtmlFolder.ReadOnly = true;
            this.textBoxSourceHtmlFolder.Size = new System.Drawing.Size(319, 20);
            this.textBoxSourceHtmlFolder.TabIndex = 1;
            // 
            // buttonSourceHtmlFolder
            // 
            this.buttonSourceHtmlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSourceHtmlFolder.Location = new System.Drawing.Point(335, 24);
            this.buttonSourceHtmlFolder.Name = "buttonSourceHtmlFolder";
            this.buttonSourceHtmlFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonSourceHtmlFolder.TabIndex = 2;
            this.buttonSourceHtmlFolder.Text = "Browse";
            this.buttonSourceHtmlFolder.UseVisualStyleBackColor = true;
            this.buttonSourceHtmlFolder.Click += new System.EventHandler(this.buttonSourceHtmlFolder_Click);
            // 
            // buttonXmlTemplate
            // 
            this.buttonXmlTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXmlTemplate.Location = new System.Drawing.Point(335, 79);
            this.buttonXmlTemplate.Name = "buttonXmlTemplate";
            this.buttonXmlTemplate.Size = new System.Drawing.Size(75, 23);
            this.buttonXmlTemplate.TabIndex = 5;
            this.buttonXmlTemplate.Text = "Browse";
            this.buttonXmlTemplate.UseVisualStyleBackColor = true;
            this.buttonXmlTemplate.Click += new System.EventHandler(this.buttonXmlTemplate_Click);
            // 
            // textBoxXmlTemplate
            // 
            this.textBoxXmlTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXmlTemplate.Location = new System.Drawing.Point(10, 81);
            this.textBoxXmlTemplate.Name = "textBoxXmlTemplate";
            this.textBoxXmlTemplate.ReadOnly = true;
            this.textBoxXmlTemplate.Size = new System.Drawing.Size(319, 20);
            this.textBoxXmlTemplate.TabIndex = 4;
            // 
            // labelXmlTemplate
            // 
            this.labelXmlTemplate.AutoSize = true;
            this.labelXmlTemplate.Location = new System.Drawing.Point(7, 65);
            this.labelXmlTemplate.Name = "labelXmlTemplate";
            this.labelXmlTemplate.Size = new System.Drawing.Size(71, 13);
            this.labelXmlTemplate.TabIndex = 3;
            this.labelXmlTemplate.Text = "Xml Template";
            // 
            // buttonConvert
            // 
            this.buttonConvert.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonConvert.Location = new System.Drawing.Point(10, 181);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(400, 23);
            this.buttonConvert.TabIndex = 6;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarStatus.Location = new System.Drawing.Point(10, 204);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(400, 17);
            this.progressBarStatus.TabIndex = 7;
            // 
            // buttonDestinationXmlFolder
            // 
            this.buttonDestinationXmlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDestinationXmlFolder.Location = new System.Drawing.Point(335, 137);
            this.buttonDestinationXmlFolder.Name = "buttonDestinationXmlFolder";
            this.buttonDestinationXmlFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonDestinationXmlFolder.TabIndex = 11;
            this.buttonDestinationXmlFolder.Text = "Browse";
            this.buttonDestinationXmlFolder.UseVisualStyleBackColor = true;
            this.buttonDestinationXmlFolder.Click += new System.EventHandler(this.buttonDestinationXmlFolder_Click);
            // 
            // textBoxDestinationXmlFolder
            // 
            this.textBoxDestinationXmlFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDestinationXmlFolder.Location = new System.Drawing.Point(10, 139);
            this.textBoxDestinationXmlFolder.Name = "textBoxDestinationXmlFolder";
            this.textBoxDestinationXmlFolder.ReadOnly = true;
            this.textBoxDestinationXmlFolder.Size = new System.Drawing.Size(319, 20);
            this.textBoxDestinationXmlFolder.TabIndex = 10;
            // 
            // labelDestinationXmlFolder
            // 
            this.labelDestinationXmlFolder.AutoSize = true;
            this.labelDestinationXmlFolder.Location = new System.Drawing.Point(7, 123);
            this.labelDestinationXmlFolder.Name = "labelDestinationXmlFolder";
            this.labelDestinationXmlFolder.Size = new System.Drawing.Size(112, 13);
            this.labelDestinationXmlFolder.TabIndex = 9;
            this.labelDestinationXmlFolder.Text = "Destination Xml Folder";
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 231);
            this.Controls.Add(this.buttonDestinationXmlFolder);
            this.Controls.Add(this.textBoxDestinationXmlFolder);
            this.Controls.Add(this.labelDestinationXmlFolder);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.progressBarStatus);
            this.Controls.Add(this.buttonXmlTemplate);
            this.Controls.Add(this.textBoxXmlTemplate);
            this.Controls.Add(this.labelXmlTemplate);
            this.Controls.Add(this.buttonSourceHtmlFolder);
            this.Controls.Add(this.textBoxSourceHtmlFolder);
            this.Controls.Add(this.labelSourceHtmlFolder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "App";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "HtmlToXml";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSourceHtmlFolder;
        private System.Windows.Forms.TextBox textBoxSourceHtmlFolder;
        private System.Windows.Forms.Button buttonSourceHtmlFolder;
        private System.Windows.Forms.Button buttonXmlTemplate;
        private System.Windows.Forms.TextBox textBoxXmlTemplate;
        private System.Windows.Forms.Label labelXmlTemplate;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button buttonDestinationXmlFolder;
        private System.Windows.Forms.TextBox textBoxDestinationXmlFolder;
        private System.Windows.Forms.Label labelDestinationXmlFolder;
    }
}

