using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

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
        AddressBook_ adrBook;
        SwapMonitor swapList;
        FileBackup fBackup;

        public string[] args = Environment.GetCommandLineArgs();

        //=====================================================================================================================================================================
        public Form1()
        {
            InitializeComponent();

            //localization
            
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
            DisplayLanguage();
            CheckIfDBFileExists();
            UpdateStatusText();
        }

        //=====================================================================================================================================================================
        private void DisplayLanguage(string method = null, string culture = null)
        {
            if (method == "set" && culture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                Controls.Clear();
                InitializeComponent();

                // Write UICulture to XMLConf
                Globals.UICulture = culture;
                cfgHandler.UpdateXmlConf("UICulture", culture);
            }

            // Set Application Language
            if (Globals.UICulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Globals.UICulture);
                this.Controls.Clear();
                this.InitializeComponent();
            }

            if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "de")
            {
                deutschToolStripMenuItem.Checked = true;
                englischToolStripMenuItem.Checked = false;
                französischToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = false;
                toolStripStatusLabel2.Image = Properties.Resources.DE_Germany_Flag_icon;
            }
            else if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "en")
            {
                deutschToolStripMenuItem.Checked = false;
                englischToolStripMenuItem.Checked = true;
                französischToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = false;
                toolStripStatusLabel2.Image = Properties.Resources.US_United_States_Flag_icon;
            }
            else if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "fr")
            {
                deutschToolStripMenuItem.Checked = false;
                englischToolStripMenuItem.Checked = false;
                französischToolStripMenuItem.Checked = true;
                españolToolStripMenuItem.Checked = false;
                toolStripStatusLabel2.Image = Properties.Resources.FR_France_Flag_icon;
            }
            else if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "es")
            {
                deutschToolStripMenuItem.Checked = false;
                englischToolStripMenuItem.Checked = false;
                französischToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = true;
                toolStripStatusLabel2.Image = Properties.Resources.ES_Spain_Flag_icon;
            }
            else
            {
                deutschToolStripMenuItem.Checked = false;
                englischToolStripMenuItem.Checked = false;
                französischToolStripMenuItem.Checked = false;
                españolToolStripMenuItem.Checked = false;
                toolStripStatusLabel2.Image = null;
            }

            toolStripStatusLabel2.Text = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            CheckIfDBFileExists();
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
            adrBook = new AddressBook_();
            adrBook.Show();
        }

        //=====================================================================================================================================================================
        private void AddressbookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adrBook = new AddressBook_();
            adrBook.Show();
        }

        //=====================================================================================================================================================================
        private void TauschmonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            swapList = new SwapMonitor();
            swapList.Show();
        }

        //=====================================================================================================================================================================
        private void SwapMonitorToolStripMenuItem_Click(object sender, EventArgs e)
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
            Close();
        }

        //=====================================================================================================================================================================
        private void BeendenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //=====================================================================================================================================================================
        private void DatenbankSichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunDBBackup();
        }

        //=====================================================================================================================================================================
        private void DatenbankSichernToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RunDBBackup();
        }

        //=====================================================================================================================================================================
        private void DatenbankKomprimierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunDBCompression();
        }

        //=====================================================================================================================================================================
        private void CompressDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunDBCompression();
        }

        //=====================================================================================================================================================================
        private void Form1_Close(object sender, FormClosingEventArgs e)
        {
            if (Globals.BackupDBOnAppClose == true)
            {
                RunDBBackup();
            }
        }

        //=====================================================================================================================================================================
        private void RunDBCompression()
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
        private void RunDBBackup()
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
        private void ÜberENumismatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        //=====================================================================================================================================================================
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Globals.MinimizeToTray == true)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    WindowState = FormWindowState.Minimized;
                }
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

        //=====================================================================================================================================================================
        private void DeutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "de-DE");
        }

        //=====================================================================================================================================================================
        private void EnglischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "en-US");
        }

        //=====================================================================================================================================================================
        private void FranzösischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "fr-FR");
        }

        //=====================================================================================================================================================================
        private void EspañolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "es-ES");
        }
    }
}
