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
        System.Timers.Timer timer = new System.Timers.Timer();
        GetWebsiteSource webSource = new GetWebsiteSource();

        public Form1()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            InitializeComponent();

            try // Loading the user's last input
            {
                urlToKeepAlive.Text = Properties.Settings.Default.lastUrl.ToString();
                WebsiteCheckDuration.Text = Properties.Settings.Default.lastMins.ToString();
            }
            catch { }
        }

        private async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Re-check the website and let the user know whats going on
            statusConsole.Invoke((Action)delegate 
            {
                statusConsole.Text += Environment.NewLine +"Checking Website....";
                statusConsole.Text += Environment.NewLine + "Loading Website in Browser...";
            });

            webBrowser.DocumentText = await webSource.HTML;

            statusConsole.Invoke((Action)delegate
            {
                statusConsole.Text += Environment.NewLine + "Website Loaded.";
            });
        }

        private async void buttonStart_Click(object sender, EventArgs e)
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
                && (checkedUrl.Scheme == Uri.UriSchemeHttp || checkedUrl.Scheme == Uri.UriSchemeHttps) )
            {
                MessageBox.Show("Only enter valid URL's! (aka http://somewebsite.com or https://www.somewebsite.net etc.");
                return;
            }

            // Enable timer and set URL
            timer.Interval = checkedDuration * 60000;
            timer.Enabled = true;
            webSource.websiteURL = checkedUrl;
           
            // Inform user via status console
            buttonStart.Text = "Running";
            buttonStart.Enabled = false;
            statusConsole.Text += "Keeping Website at " + checkedUrl + " Alive!";
            statusConsole.Text += Environment.NewLine + "Loading Website in Browser...";
            webBrowser.DocumentText = await webSource.HTML;
            statusConsole.Text += Environment.NewLine + "Website Loaded.";
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            // Stop timer and reset everything back to normal
            timer.Enabled = false;
            statusConsole.Text = "Checking Stopped!";
            buttonStart.Text = "Start";
            buttonStart.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Save the user's input settings 
            Properties.Settings.Default.lastUrl = webSource.websiteURL.ToString();
            Properties.Settings.Default.lastMins = WebsiteCheckDuration.Text.ToString();
            Properties.Settings.Default.Save();
        }

        private void showBrowser_CheckedChanged(object sender, EventArgs e)
        {
            if (!showBrowser.Checked)
            {
                webBrowser.Hide();
                this.Width -= 499;
            }
            else
            {
                webBrowser.Show();
                this.Width += 499;
            }
        }
    }
}
