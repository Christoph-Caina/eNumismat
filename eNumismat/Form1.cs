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

            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());

            //localization
            dateiToolStripMenuItem.Text = res_man.GetString("_file");
            neueDatenbankToolStripMenuItem.Text = res_man.GetString("_createNewDataBase");
            datenbankÖffnenToolStripMenuItem.Text = res_man.GetString("_openExistingDataBase");
            datenbankSichernToolStripMenuItem.Text = res_man.GetString("_backupDataBase");
            datenbankKomprimierenToolStripMenuItem.Text = res_man.GetString("_compressDataBase");
            beendenToolStripMenuItem.Text = res_man.GetString("_exitApplication");


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
                //if(File.Exists(Globals.FileBrowserInitDir + "\\" + Globals.DBFile))
                //{
                    ExtrasToolStripMenuItem.Enabled = true;
                    AdressbuchToolStripMenuItem.Enabled = true;
                    TauschmonitorToolStripMenuItem.Enabled = true;
                    toolStripStatusLabel1.Image = Properties.Resources.connect;
                    toolStripStatusLabel1.Text = Globals.DBFile;
                //}
                //else
                //{
                //    ErrorDialog ErrDiag = new ErrorDialog();
                //    ErrDiag.DialogTitle = "ERROR";
                //    ErrDiag.ErrText =
                //        "Error: The file " +
                //        Globals.DBFile +
                //        " does not exist in the given Directory!" +
                //        Environment.NewLine +
                //        Globals.FileBrowserInitDir +
                //        Environment.NewLine +
                //        Environment.NewLine +
                //        "Would you like to open another File, or do you want to create a new one?";
                //    ErrDiag.Btn1_Text = "Open other File";
                //    ErrDiag.Btn2_Text = "Create New File";
                //    ErrDiag.Btn3_Text = "Cancel";
                //
                 //   ErrDiag.ShowDialog();
                //}
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
                // Only, if no other path is specified in the Config
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments),
                Filter = "eNumismatCollection File(*.enc) | *.enc"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(saveFile.FileName);

                string[] FileData = { Path.GetFileName(saveFile.FileName), Path.GetDirectoryName(saveFile.FileName) };

                //MessageBox.Show(FileData[0]);

                WriteDBFileToConf(FileData);

                //Globals.DBFile = saveFile.;
                //EnableOrDisableMenueItems();

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
                string[] FileData = { Path.GetFileName(openFile.FileName), Path.GetDirectoryName(openFile.FileName) };

                WriteDBFileToConf(FileData);
            }
        }

        //=====================================================================================================================================================================
        private void WriteDBFileToConf(string[] FileData)
        {
            cfgHandler.UpdateXmlConf("Database", "LastDBFile", FileData[0]);
            cfgHandler.UpdateXmlConf("Database", "LastDBFilePath", FileData[1]);

            //Globals.DBFile = FileData[1] + "\\" + FileData[0];
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
