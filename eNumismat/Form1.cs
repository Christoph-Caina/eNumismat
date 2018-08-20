using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace eNumismat
{
    public partial class Form1 : Form
    {
        ConfigHandler cfgHandler;
        LogHandler logHandler;
        DBActions dbAction;
        SaveFileDialog saveFile;
        OpenFileDialog openFile;
        //FolderBrowserDialog folderBrowser;
        AddressBook adrBook;
        SwapMonitor swapList;
        FileBackup fBackup;

        public string[] args = Environment.GetCommandLineArgs();


        //=====================================================================================================================================================================
        public Form1()
        {
            InitializeComponent();

            //localization
            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_germany;
            }
            else if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_usa;
            }
            else if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "fr")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_france;
            }
            toolStripStatusLabel2.Text = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

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

            TrayIcon.Visible = true;
        }

        // Default Event Functions Load, Show, Close
        //=====================================================================================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            CheckIfDBFileExists();
            //EnableOrDisableMenueItems();
            UpdateStatusText();
        }

        //=====================================================================================================================================================================
        private void UpdateStatusText()
        {
            
        }
        //=====================================================================================================================================================================
        private void CheckIfDBFileExists()
        {
            if (!String.IsNullOrEmpty(Globals.DBFile))
            {
                ExtrasToolStripMenuItem.Enabled = true;
                AdressbuchToolStripMenuItem.Enabled = true;
                TauschmonitorToolStripMenuItem.Enabled = true;
                toolStripStatusLabel1.Image = Properties.Resources.connect;
                toolStripStatusLabel1.Text = Globals.DBFile;
            }
            else
            {
                ExtrasToolStripMenuItem.Enabled = false;
                AdressbuchToolStripMenuItem.Enabled = false;
                TauschmonitorToolStripMenuItem.Enabled = false;
                toolStripStatusLabel1.Image = Properties.Resources.disconnect;
                toolStripStatusLabel1.Text = GlobalStrings._noDBconnected;
            }
        }

        //=====================================================================================================================================================================
        private void Form1_Show(object sender, EventArgs e)
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

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "eNumismatCollection File(*.enc) | *.enc"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string[] FileData = { Path.GetFileName(saveFile.FileName), Path.GetDirectoryName(saveFile.FileName) };

                Globals.DBFilePath = FileData[1];
                Globals.DBFile = FileData[0];

                dbAction = new DBActions();
                dbAction.CreateNew();

                WriteDBFileToConf(FileData);
                CheckIfDBFileExists();
            }
            else
            { }
        }

        //=====================================================================================================================================================================
        private void DatenbankOeffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile = new OpenFileDialog
            {
                DefaultExt = "*.enc", // enc = eNumismatCollection
                AddExtension = true,

                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "eNumismatCollection File (*.enc) | *.enc"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string[] FileData = { Path.GetFileName(openFile.FileName), Path.GetDirectoryName(openFile.FileName) };

                Globals.DBFilePath = FileData[1];
                Globals.DBFile = FileData[0];

                WriteDBFileToConf(FileData);
                CheckIfDBFileExists();
            }
        }

        //=====================================================================================================================================================================
        private void WriteDBFileToConf(string[] FileData)
        {
            cfgHandler.UpdateXmlConf("LastDBFile", FileData[0]);
            cfgHandler.UpdateXmlConf("LastDBFilePath", FileData[1]);
        }

        //=====================================================================================================================================================================
        private void AdressbuchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adrBook = new AddressBook();
            adrBook.Show();
        }

        //=====================================================================================================================================================================
        private void addressbookToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void swapMonitorToolStripMenuItem_Click(object sender, EventArgs e)
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

        //=====================================================================================================================================================================
        private void DatenbankSichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runDBBackup();
        }

        //=====================================================================================================================================================================
        private void datenbankSichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            runDBBackup();
        }

        //=====================================================================================================================================================================
        private void datenbankKomprimierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runDBCompression();
        }

        //=====================================================================================================================================================================
        private void compressDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runDBCompression();
        }

        //=====================================================================================================================================================================
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            if (Globals.BackupDBOnAppClose == true)
            {
                runDBBackup();
            }
        }

        //=====================================================================================================================================================================
        private void runDBCompression()
        {
            fBackup = new FileBackup();

            if(fBackup.CompactDatabase())
            {
                TrayIcon.BalloonTipTitle = GlobalStrings._dbCompress_BalloonTitle;
                TrayIcon.BalloonTipText = GlobalStrings._dbCompress_BallonText;

                TrayIcon.ShowBalloonTip(2000);
            }
        }

        //=====================================================================================================================================================================
        private void runDBBackup()
        {
            fBackup = new FileBackup();

            if (fBackup.ExcecuteBackup())
            {
                TrayIcon.BalloonTipTitle = GlobalStrings._dbBackup_BalloonTitle;
                TrayIcon.BalloonTipText = GlobalStrings._dbBackup_BallonText;

                TrayIcon.ShowBalloonTip(2000);
            }
        }

        //=====================================================================================================================================================================
        private void überENumismatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        //=====================================================================================================================================================================
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }

        //=====================================================================================================================================================================
        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
        //    DoubleClickAction();
        }

        //=====================================================================================================================================================================
        private void TryIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DoubleClickAction();
        }

        //=====================================================================================================================================================================
        private void DoubleClickAction()
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Hide();
                WindowState = FormWindowState.Minimized;
            }
        }
    }
}
