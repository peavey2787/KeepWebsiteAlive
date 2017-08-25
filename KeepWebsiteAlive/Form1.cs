using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using GetHTMLSource;

namespace KeepWebsiteAlive
{
    public partial class Form1 : Form
    {
        #region Form Variables
        System.Timers.Timer timer = new System.Timers.Timer();
        GetWebsiteSource webSource = new GetWebsiteSource();
        Task<string> tskGetHTML;
        private int lastBrowserWidth = 499;
        private int minFormWidth = 300;
        #endregion

        #region Form Open/Close
        public Form1()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            InitializeComponent();

            try // Loading the user's last input
            {
                urlToKeepAlive.Text = Properties.Settings.Default.lastUrl;
                WebsiteCheckDuration.Text = Properties.Settings.Default.lastMins;
            }
            catch { }
            MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopStayingAlive();

            // Save the user's input settings 
            Properties.Settings.Default.lastUrl = urlToKeepAlive.Text;
            Properties.Settings.Default.lastMins = WebsiteCheckDuration.Text;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Button Clicks (Start/Stop)
        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartStayingAlive();

            // Disable start and enable stop button
            buttonStart.Text = "Running";
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopStayingAlive();

            // Enable start button
            buttonStart.Text = "Start";
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
        #endregion

        #region Core Engine - Start/Stop/Check Website
        private void StartStayingAlive()
        {
            int checkedDuration = 0;
            Uri checkedUrl;

            // Make sure only whole #'s are in the minutes textbox
            if (!int.TryParse(WebsiteCheckDuration.Text, out checkedDuration))
            {
                MessageBox.Show("Only enter whole numbers in the minutes section!");
                return;
            }

            // Make sure only valid websites are in the url textbox
            if (!Uri.TryCreate(urlToKeepAlive.Text, UriKind.Absolute, out checkedUrl)
                && (checkedUrl.Scheme == Uri.UriSchemeHttp || checkedUrl.Scheme == Uri.UriSchemeHttps))
            {
                MessageBox.Show("Only enter valid URL's! (aka http://somewebsite.com or https://www.somewebsite.net etc.");
                return;
            }

            // Enable timer and set URL
            webSource.websiteURL = checkedUrl;
            timer.Interval = checkedDuration * 60000;
            tskGetHTML = webSource.HTML;
            timer.Enabled = true;
            UpdateStatus("Keeping " + checkedUrl + " Alive!");
            CheckWebsite();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckWebsite(); // Re-check the website
        }
        private async void CheckWebsite()
        {
            UpdateStatus("Loading Website in Browser...");
            try
            {
                webBrowser.DocumentText = await tskGetHTML;
                UpdateStatus("Website Loaded.");
            }
            catch (Exception exception)
            {
                UpdateStatus("ERROR!Website was NOT Loaded!");
                UpdateStatus(exception.Message);
            }
        }

        private void StopStayingAlive()
        {
            // Stop timer and reset everything back to normal
            try { tskGetHTML.Dispose(); }
            catch { }
            timer.Enabled = false;
            UpdateStatus("Checking Stopped!");
        }

        private void UpdateStatus(string message)
        {
            if (statusConsole.InvokeRequired)
            {
                statusConsole.Invoke((Action)delegate
                {
                    statusConsole.Text += Environment.NewLine + message;
                });
            }
            else
                statusConsole.Text += Environment.NewLine + message;
        }
        #endregion

        #region Resize Form to Show/Hide Web Browser
        private void showBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (showBrowser.Checked)
            {
                webBrowser.Show();
                this.Width += lastBrowserWidth;
            }
            else
            {
                webBrowser.Hide();
                lastBrowserWidth = webBrowser.Width;
                this.Width = Width - lastBrowserWidth;
            }
        }

        private void webBrowser_Resize(object sender, EventArgs e)
        {
            if (showBrowser.Checked)
                lastBrowserWidth = webBrowser.Width;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (!showBrowser.Checked)
                Width = minFormWidth;
            else if (Width <= minFormWidth + 300)
                Width = minFormWidth + 300;
        }
        #endregion
    }
}
