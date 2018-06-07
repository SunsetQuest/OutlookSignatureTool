namespace CreateOutlookSignatureTool
{
    partial class Form1
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
            this.webBrowserPreview = new System.Windows.Forms.WebBrowser();
            this.label8 = new System.Windows.Forms.Label();
            this.btnApplyToOutlook = new System.Windows.Forms.Button();
            this.flow = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTemplate = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserPreview
            // 
            this.webBrowserPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserPreview.Location = new System.Drawing.Point(0, 0);
            this.webBrowserPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPreview.Name = "webBrowserPreview";
            this.webBrowserPreview.Size = new System.Drawing.Size(538, 258);
            this.webBrowserPreview.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(254, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 13;
            // 
            // btnApplyToOutlook
            // 
            this.btnApplyToOutlook.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnApplyToOutlook.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyToOutlook.Location = new System.Drawing.Point(0, 576);
            this.btnApplyToOutlook.Name = "btnApplyToOutlook";
            this.btnApplyToOutlook.Size = new System.Drawing.Size(538, 34);
            this.btnApplyToOutlook.TabIndex = 16;
            this.btnApplyToOutlook.Text = "Apply To Outlook";
            this.btnApplyToOutlook.UseVisualStyleBackColor = true;
            this.btnApplyToOutlook.Click += new System.EventHandler(this.btnApplyToOutlook_Click);
            // 
            // flow
            // 
            this.flow.AutoScroll = true;
            this.flow.AutoSize = true;
            this.flow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flow.Location = new System.Drawing.Point(0, 0);
            this.flow.Name = "flow";
            this.flow.Size = new System.Drawing.Size(538, 240);
            this.flow.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboTemplate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 74);
            this.panel1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(351, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Step 2:  Fill in your Name, Phone, etc. Watch the preview window below.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Step 1: Select Template:";
            // 
            // cboTemplate
            // 
            this.cboTemplate.FormattingEnabled = true;
            this.cboTemplate.Location = new System.Drawing.Point(129, 16);
            this.cboTemplate.Name = "cboTemplate";
            this.cboTemplate.Size = new System.Drawing.Size(230, 21);
            this.cboTemplate.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.flow);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowserPreview);
            this.splitContainer1.Size = new System.Drawing.Size(538, 502);
            this.splitContainer1.SplitterDistance = 240;
            this.splitContainer1.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 610);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnApplyToOutlook);
            this.Controls.Add(this.label8);
            this.Name = "Form1";
            this.Text = "Outlook Signature Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.WebBrowser webBrowserPreview;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnApplyToOutlook;
        private System.Windows.Forms.FlowLayoutPanel flow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboTemplate;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

