using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        }
    }
}
