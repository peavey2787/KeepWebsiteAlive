namespace KeepWebsiteAlive
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
            this.urlToKeepAlive = new System.Windows.Forms.TextBox();
            this.lblUrlToKeepAlive = new System.Windows.Forms.Label();
            this.WebsiteCheckDuration = new System.Windows.Forms.TextBox();
            this.lblWebsiteCheckDuration = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblMinutesWarning = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.statusConsole = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.showBrowser = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // urlToKeepAlive
            // 
            this.urlToKeepAlive.Location = new System.Drawing.Point(12, 23);
            this.urlToKeepAlive.Name = "urlToKeepAlive";
            this.urlToKeepAlive.Size = new System.Drawing.Size(259, 20);
            this.urlToKeepAlive.TabIndex = 0;
            this.urlToKeepAlive.Text = "https://www.google.com";
            // 
            // lblUrlToKeepAlive
            // 
            this.lblUrlToKeepAlive.AutoSize = true;
            this.lblUrlToKeepAlive.Location = new System.Drawing.Point(9, 7);
            this.lblUrlToKeepAlive.Name = "lblUrlToKeepAlive";
            this.lblUrlToKeepAlive.Size = new System.Drawing.Size(96, 13);
            this.lblUrlToKeepAlive.TabIndex = 1;
            this.lblUrlToKeepAlive.Text = "URL to keep alive:";
            // 
            // WebsiteCheckDuration
            // 
            this.WebsiteCheckDuration.Location = new System.Drawing.Point(143, 80);
            this.WebsiteCheckDuration.Name = "WebsiteCheckDuration";
            this.WebsiteCheckDuration.Size = new System.Drawing.Size(28, 20);
            this.WebsiteCheckDuration.TabIndex = 2;
            this.WebsiteCheckDuration.Text = "1";
            // 
            // lblWebsiteCheckDuration
            // 
            this.lblWebsiteCheckDuration.AutoSize = true;
            this.lblWebsiteCheckDuration.Location = new System.Drawing.Point(17, 55);
            this.lblWebsiteCheckDuration.Name = "lblWebsiteCheckDuration";
            this.lblWebsiteCheckDuration.Size = new System.Drawing.Size(203, 13);
            this.lblWebsiteCheckDuration.TabIndex = 3;
            this.lblWebsiteCheckDuration.Text = "How often should we check the website?";
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Location = new System.Drawing.Point(177, 83);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(43, 13);
            this.lblMinutes.TabIndex = 4;
            this.lblMinutes.Text = "minutes";
            // 
            // lblMinutesWarning
            // 
            this.lblMinutesWarning.AutoSize = true;
            this.lblMinutesWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutesWarning.ForeColor = System.Drawing.Color.Red;
            this.lblMinutesWarning.Location = new System.Drawing.Point(42, 83);
            this.lblMinutesWarning.Name = "lblMinutesWarning";
            this.lblMinutesWarning.Size = new System.Drawing.Size(71, 13);
            this.lblMinutesWarning.TabIndex = 5;
            this.lblMinutesWarning.Text = "(minutes only)";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(30, 137);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(89, 42);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(277, 7);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Size = new System.Drawing.Size(499, 348);
            this.webBrowser.TabIndex = 7;
            // 
            // statusConsole
            // 
            this.statusConsole.Location = new System.Drawing.Point(12, 185);
            this.statusConsole.Multiline = true;
            this.statusConsole.Name = "statusConsole";
            this.statusConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.statusConsole.Size = new System.Drawing.Size(259, 170);
            this.statusConsole.TabIndex = 8;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(143, 138);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(89, 41);
            this.buttonStop.TabIndex = 9;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // showBrowser
            // 
            this.showBrowser.AutoSize = true;
            this.showBrowser.Checked = true;
            this.showBrowser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showBrowser.Location = new System.Drawing.Point(132, 113);
            this.showBrowser.Name = "showBrowser";
            this.showBrowser.Size = new System.Drawing.Size(94, 17);
            this.showBrowser.TabIndex = 10;
            this.showBrowser.Text = "Show Browser";
            this.showBrowser.UseVisualStyleBackColor = true;
            this.showBrowser.CheckedChanged += new System.EventHandler(this.showBrowser_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 383);
            this.Controls.Add(this.showBrowser);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.statusConsole);
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.lblMinutesWarning);
            this.Controls.Add(this.lblMinutes);
            this.Controls.Add(this.lblWebsiteCheckDuration);
            this.Controls.Add(this.WebsiteCheckDuration);
            this.Controls.Add(this.lblUrlToKeepAlive);
            this.Controls.Add(this.urlToKeepAlive);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlToKeepAlive;
        private System.Windows.Forms.Label lblUrlToKeepAlive;
        private System.Windows.Forms.TextBox WebsiteCheckDuration;
        private System.Windows.Forms.Label lblWebsiteCheckDuration;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblMinutesWarning;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TextBox statusConsole;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox showBrowser;
    }
}

