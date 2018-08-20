using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;


namespace eNumismat
{
    public partial class SettingsDialog : Form
    {
        ConfigHandler cfgHandler = new ConfigHandler();
        LogHandler logHandler = new LogHandler();
        Dictionary<string, string> ConfigParam = new Dictionary<string, string>();

        //=====================================================================================================================================================================
        public SettingsDialog()
        {
            InitializeComponent();

            // First of all, Read the Configuration
            cfgHandler.ReadXmlConf();
        }

        //=====================================================================================================================================================================
        private void SettingsDialog_Load(object sender, EventArgs e)
        {
            if (Globals.UICulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Globals.UICulture);
                Controls.Clear();
                InitializeComponent();
            }

            string[] languages = { "de-DE", "en-US", "fr-FR" };
            cb_languageSelection.Items.AddRange(languages);
            cb_languageSelection.SelectedText = Globals.UICulture;

            // load current settings from GLOBAL VARS
            label2.Text = Globals.DBFile;
            label4.Text = Globals.DBFilePath;

            if (Globals.BackupDBOnAppClose == true)
            {
                cb_DbBackUpOnAppExit.Checked = true;
            }
            else
            {
                cb_DbBackUpOnAppExit.Checked = false;
            }

            if (Globals.CompressDBBeforeBackup == true)
            {
                cb_DbCompressionBeforeBackup.Checked = true;
            }
            else
            {
                cb_DbCompressionBeforeBackup.Checked = false;
            }

            if (Globals.MinimizeToTray == true)
            {
                cb_MinimizeToTray.Checked = true;
            }
            else
            {
                cb_MinimizeToTray.Checked = false;
            }
        }

        //=====================================================================================================================================================================
        private void button1_Click(object sender, EventArgs e)
        {
            if (ConfigParam.ContainsKey("MinimizeToTray"))
            {
                ConfigParam["MinimizeToTray"] = cb_MinimizeToTray.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("MinimizeToTray", cb_MinimizeToTray.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("DbBackupOnAppExit"))
            {
                ConfigParam["DbBackupOnAppExit"] = cb_DbBackUpOnAppExit.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("DbBackupOnAppExit", cb_DbBackUpOnAppExit.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("DbCompressionBeforeBackup"))
            {
                ConfigParam["DbCompressionBeforeBackup"] = cb_DbCompressionBeforeBackup.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("DbCompressionBeforeBackup", cb_DbCompressionBeforeBackup.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("MinimizeToTray"))
            {
                ConfigParam["MinimizeToTray"] = cb_MinimizeToTray.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("MinimizeToTray", cb_MinimizeToTray.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("UICulture"))
            {
                ConfigParam["UICulture"] = cb_languageSelection.Text;
            }
            else
            {
                ConfigParam.Add("UICulture", cb_languageSelection.Text);
            }

            foreach (KeyValuePair<string, string> kv in ConfigParam)
            {
                cfgHandler.UpdateXmlConf(kv.Key, kv.Value);
            }

            this.Hide();
        }

        //=====================================================================================================================================================================
        private void cb_MinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //=====================================================================================================================================================================
        private void cb_DbBackUpOnAppExit_CheckedChanged(object sender, EventArgs e)
        {

        }

        //=====================================================================================================================================================================
        private void cb_DbCompressionBeforeBackup_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
