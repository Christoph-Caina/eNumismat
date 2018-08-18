using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Data;
using System.Text.RegularExpressions;


namespace eNumismat
{
    public partial class SettingsDialog : Form
    {
        ConfigHandler cfgHandler = new ConfigHandler();
        LogHandler logHandler = new LogHandler();
        Dictionary<string, bool> ConfigParam = new Dictionary<string, bool>();

        //=====================================================================================================================================================================
        public SettingsDialog()
        {
            InitializeComponent();

            // First of all, Read the Configuration
            cfgHandler.ReadXmlConf();

            // We need to define, what should be possible within the settings dialog.
            // Change LastDBFileName?
            // Change Default SAVE / OPEN Dialog Boxes?
            // Move Default AppDataPath?
            // Change other Parameters for the Database?
            // Change Collection Parameters - like Country, etc.?
        }

        //=====================================================================================================================================================================
        private void SettingsDialog_Load(object sender, EventArgs e)
        {
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
                ConfigParam["MinimizeToTray"] = cb_MinimizeToTray.Checked;
            }
            else
            {
                ConfigParam.Add("MinimizeToTray", cb_MinimizeToTray.Checked);
            }

            if (ConfigParam.ContainsKey("DbBackupOnAppExit"))
            {
                ConfigParam["DbBackupOnAppExit"] = cb_DbBackUpOnAppExit.Checked;
            }
            else
            {
                ConfigParam.Add("DbBackupOnAppExit", cb_DbBackUpOnAppExit.Checked);
            }

            if (ConfigParam.ContainsKey("DbCompressionBeforeBackup"))
            {
                ConfigParam["DbCompressionBeforeBackup"] = cb_DbCompressionBeforeBackup.Checked;
            }
            else
            {
                ConfigParam.Add("DbCompressionBeforeBackup", cb_DbCompressionBeforeBackup.Checked);
            }

            foreach (KeyValuePair<string, bool> kv in ConfigParam)
            {
                cfgHandler.UpdateXmlConf(kv.Key, kv.Value.ToString());
                //MessageBox.Show(kv.Key + Environment.NewLine + kv.Value.ToString());

                

            }
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
