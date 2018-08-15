﻿using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace eNumismat
{
    public partial class Form1 : Form
    {
        ConfigHandler cfgHandler;
        LogHandler logHandler;
        DBActions dbAction;
        SaveFileDialog saveFile;
        OpenFileDialog openFile;
        FolderBrowserDialog folderBrowser;
        AddressBook adrBook;
        SwapMonitor swapList;

        public string[] args = Environment.GetCommandLineArgs();

        //=====================================================================================================================================================================
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
        //=====================================================================================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            EnableOrDisableMenueItems();
        }

        //=====================================================================================================================================================================
        private void EnableOrDisableMenueItems()
        {
            if (String.IsNullOrEmpty(Globals.DBFile))
            {
                ExtrasToolStripMenuItem.Enabled = false;
                AdressbuchToolStripMenuItem.Enabled = false;
                TauschmonitorToolStripMenuItem.Enabled = false;
            }
            else
            {
                ExtrasToolStripMenuItem.Enabled = true;
                AdressbuchToolStripMenuItem.Enabled = true;
                TauschmonitorToolStripMenuItem.Enabled = true;
            }
        }

        //=====================================================================================================================================================================
        private void Form1_Show(object sender, EventArgs e)
        {

        }

        //=====================================================================================================================================================================
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {

        }

        //=====================================================================================================================================================================
        private void EinstellungenBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Settings Dialog
            SettingsDialog settings = new SettingsDialog();
            settings.ShowDialog();
        }

        //=====================================================================================================================================================================
        private void NeueDatenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile = new SaveFileDialog
            {
                DefaultExt = "*.enc", // enc = eNumismatCollection
                AddExtension = true,
                // Only, if no other path is specified in the Config
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "eNumismatCollection File(*.enc) | *.enc"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                Globals.DBFile = saveFile.FileName;
                EnableOrDisableMenueItems();

                dbAction = new DBActions();
                dbAction.CreateNew();
            }
            else
            { }
        }

        //=====================================================================================================================================================================
        private void DatenbankOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = "*.enc", // enc = eNumismatCollection
                AddExtension = true,

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "eNumismatCollection File (*.enc) | *.enc"
            };
            openFile = openFileDialog;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Globals.DBFile = openFile.FileName;
                EnableOrDisableMenueItems();
            }
        }

        //=====================================================================================================================================================================
        private void AdressbuchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adrBook = new AddressBook();
            adrBook.Show();
        }

        //=====================================================================================================================================================================
        private void TauschmonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swapList = new SwapMonitor();
            swapList.Show();
        }

        //=====================================================================================================================================================================
        private void UnicodeTabelleFuerWaehrungssymboleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] PDF = Properties.Resources.Unicode_Currencies;

            MemoryStream ms = new MemoryStream(PDF);
            FileStream f = new FileStream("unicodecurrencies.pdf", FileMode.OpenOrCreate);

            ms.WriteTo(f);
            f.Close();
            ms.Close();

            Process.Start("unicodecurrencies.pdf");
        }

        //=====================================================================================================================================================================
        private void BeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
