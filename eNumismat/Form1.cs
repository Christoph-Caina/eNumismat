using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace eNumismat
{
    public partial class Form1 : Form
    {
        ConfigHandler cfgHandler; //= new ConfigHandler();
        LogHandler logHandler; //= new LogHandler();
        DBActions dbAction; //= new DBActions();
        SaveFileDialog saveFile;
        OpenFileDialog openFile;
        FolderBrowserDialog folderBrowser;
        AddressBook adrBook;
        SwapMonitor swapList;

        public string[] args = Environment.GetCommandLineArgs();

        //=============================================================================================================
        public Form1()
        {
            InitializeComponent();

            cfgHandler = new ConfigHandler();
            logHandler = new LogHandler();

            Globals.LogLevel = "WARN";

            // Check if LogLevel DEBUG is set with CommandLineArgs
            if (args.Count() > 1)
            {
                foreach (string arg in args)
                {
                    if (arg.ToUpper() == "DEBUG")
                    {
                        Globals.LogLevel = "DEBUG";
                    }
                }
            }

            // Check, if a Config File exists
            // We need a default AppDataPath, if no Config File exists...
            if (!File.Exists(Globals.AppDataPath + @"\config.xml"))
            {
                // if Config does not exist: Create Config
                if(cfgHandler.CreateDefaultConf())
                {
                    // if Config could be created: Read Config
                    cfgHandler.ReadXmlConf();
                }
                else
                {
                 // ErrorLogging   
                }
            }
            else
            {
                // if Config Exist: Read Conf.File
                cfgHandler.ReadXmlConf();
            }
        }  

        // Default Event Functions Load, Show, Close
        //=============================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //=============================================================================================================
        private void Form1_Show(object sender, EventArgs e)
        {

        }

        //=============================================================================================================
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {

        }

        //=============================================================================================================
        private void EinstellungenBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Settings Dialog
            SettingsDialog settings = new SettingsDialog();
            settings.ShowDialog();
        }

        //=============================================================================================================
        private void NeueDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "*.enc"; // enc = eNumismatCollection
            saveFile.AddExtension = true;
            // Only, if no other path is specified in the Config
            saveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            saveFile.Filter = "eNumismatCollection (*.enc) | *.enc";

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFile.FileName);
                Globals.DBFile = saveFile.FileName;

                dbAction = new DBActions();
                dbAction.CreateNew();
            }
            else
            { }
        }

        //=============================================================================================================
        private void adressbuchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            adrBook = new AddressBook();
            adrBook.Show();
        }

        //=============================================================================================================
        private void tauschmonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swapList = new SwapMonitor();
            swapList.Show();
        }
    }
}
