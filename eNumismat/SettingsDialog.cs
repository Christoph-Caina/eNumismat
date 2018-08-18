using System;
using System.Windows.Forms;

namespace eNumismat
{
    public partial class SettingsDialog : Form
    {
        ConfigHandler cfgHandler = new ConfigHandler();
        LogHandler logHandler = new LogHandler();

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
            label2.Text = Globals.DBFile;
            label4.Text = Globals.DBFilePath;

            if (Globals.BackupDBOnAppClose == true)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }

            if (Globals.CompressDBBeforeBackup == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }

            if (Globals.MinimizeToTray == true)
            {
                checkBox3.Checked = true;
            }
            else
            {
                checkBox3.Checked = false;
            }

            //needs to implement:
            // --> write config changes when settings are changed
        }
    }
}
