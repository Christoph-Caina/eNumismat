using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Net;
using System.IO;
using System.ComponentModel;
using System.Data;

namespace eNumismat
{
    public partial class SettingsDialog : Form
    {
        ConfigHandler cfgHandler = new ConfigHandler();
        LogHandler logHandler = new LogHandler();
        Dictionary<string, string> ConfigParam = new Dictionary<string, string>();

        // The thread inside which the download happens
        private Thread thrDownload;
        // The stream of data retrieved from the web server
        private Stream strResponse;
        // The stream of data that we write to the harddrive
        private Stream strLocal;
        // The request to the web server for file information
        private HttpWebRequest webRequest;
        // The response from the web server containing information about the file
        private HttpWebResponse webResponse;
        // The progress of the download in percentage
        private static int PercentProgress;
        // The delegate which we will call from the thread to update the form
        private delegate void UpdateProgessCallback(Int64 BytesRead, Int64 TotalBytes);



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

            if (Globals.UseAutoFillOnCities == true)
            {
                cb_AutoFillCities.Checked = true;
            }
            else
            {
                cb_AutoFillCities.Checked = false;
            }

            if (Globals.UseAutoFillOnStates == true)
            {
                cb_AutoFillFedStates.Checked = true;
            }
            else
            {
                cb_AutoFillFedStates.Checked = false;
            }

            if (Globals.ValidateNames == true)
            {
                cb_ValidateNames.Checked = true;
            }
            else
            {
                cb_ValidateNames.Checked = false;
            }

            if (Globals.ValidateEmail == true)
            {
                cb_ValidateEmail.Checked = true;
            }
            else
            {
                cb_ValidateEmail.Checked = false;
            }

            if (Globals.ValidateAddressData == true)
            {
                cb_ValidateAddress.Checked = true;
            }
            else
            {
                cb_ValidateAddress.Checked = false;
            }
        }

        //=====================================================================================================================================================================
        private void Button1_Click(object sender, EventArgs e)
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

            if (ConfigParam.ContainsKey("UseAutoFillOnCities"))
            {
                ConfigParam["UseAutoFillOnCities"] = cb_AutoFillCities.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("UseAutoFillOnCities", cb_AutoFillCities.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("UseAutoFillOnFederalStates"))
            {
                ConfigParam["UseAutoFillOnFederalStates"] = cb_AutoFillFedStates.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("UseAutoFillOnFederalStates", cb_AutoFillFedStates.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("ValidateNames"))
            {
                ConfigParam["ValidateNames"] = cb_ValidateNames.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("ValidateNames", cb_ValidateNames.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("ValidateEmail"))
            {
                ConfigParam["ValidateEmail"] = cb_ValidateEmail.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("ValidateEmail", cb_ValidateEmail.Checked.ToString());
            }

            if (ConfigParam.ContainsKey("ValidateAddressData"))
            {
                ConfigParam["ValidateAddressData"] = cb_ValidateAddress.Checked.ToString();
            }
            else
            {
                ConfigParam.Add("ValidateAddressData", cb_ValidateAddress.Checked.ToString());
            }


            foreach (KeyValuePair<string, string> kv in ConfigParam)
            {
                cfgHandler.UpdateXmlConf(kv.Key, kv.Value);
            }

            Hide();
        }

        public string plzData = Path.Combine(Globals.AppDataPath, @"plz.csv");

        private void Btn_DownloadImoportValidationData_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += DownloadCompleted;

                try
                {
                    webClient.DownloadFileAsync(new Uri("https://caina.de/software/data/plz.csv"), plzData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Define, what we should do with the downloaded csv file
            DataImport import = new DataImport();
            import.FromFile(plzData);
        }
    }
}
