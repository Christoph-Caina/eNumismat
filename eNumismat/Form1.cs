using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace eNumismat
{
    public partial class Form1 : Form
    {
        ResourceManager res_man;

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
        public string language = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        //=====================================================================================================================================================================
        public Form1()
        {
            InitializeComponent();

            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName, Assembly.GetExecutingAssembly());

            string lang = CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName;

            MessageBox.Show(lang);

            if (lang == "deu" || lang == "ger")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_germany;
            }
            else if (lang == "eng")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_usa;
            }
            else if (lang == "fra" || lang == "fre")
            {
                toolStripStatusLabel2.Image = Properties.Resources.flag_france;
            }

            //localization
            dateiToolStripMenuItem.Text = res_man.GetString("_file");
            neueDatenbankToolStripMenuItem.Text = res_man.GetString("_createNewDataBase");
            datenbankÖffnenToolStripMenuItem.Text = res_man.GetString("_openExistingDataBase");
            datenbankSichernToolStripMenuItem.Text = res_man.GetString("_backupDataBase");
            datenbankKomprimierenToolStripMenuItem.Text = res_man.GetString("_compressDataBase");
            beendenToolStripMenuItem.Text = res_man.GetString("_exitApplication");

            einstellungenToolStripMenuItem.Text = res_man.GetString("_settings");
            einstellungenBearbeitenToolStripMenuItem.Text = res_man.GetString("_editSettings");
            spracheÄndernToolStripMenuItem.Text = res_man.GetString("_changeLanguage");
            deutschToolStripMenuItem.Text = res_man.GetString("_langGerman");
            englischToolStripMenuItem.Text = res_man.GetString("_langEnglish");
            französischToolStripMenuItem.Text = res_man.GetString("_langFrench");

            ExtrasToolStripMenuItem.Text = res_man.GetString("_extras");
            AdressbuchToolStripMenuItem.Text = res_man.GetString("_addrBook");
            TauschmonitorToolStripMenuItem.Text = res_man.GetString("_swapMonitor");


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
            cfgHandler.UpdateXmlConf("Database", "LastDBFile", FileData[0]);
            cfgHandler.UpdateXmlConf("Database", "LastDBFilePath", FileData[1]);
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

        //=====================================================================================================================================================================
        private void DatenbankSichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBackup = new FileBackup();

            fBackup.RunBackup();
        }

        //=====================================================================================================================================================================
        private void datenbankKomprimierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fBackup = new FileBackup();

            fBackup.CompactDatabase();
        }

        //=====================================================================================================================================================================
        private void überENumismatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
