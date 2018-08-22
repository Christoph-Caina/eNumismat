using System;
using System.Globalization;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.IO;

namespace eNumismat
{
    class ConfigHandler
    {
        XmlDocument xConf;
        readonly string _ConfFile = Path.Combine(Globals.AppDataPath, @"config.xml");

        public string GetConfFile()
        {
            return _ConfFile;
        }

        //=====================================================================================================================================================================
        private bool CheckIfAppDataPathExists()
        {
            if (!Directory.Exists(Globals.AppDataPath))
            {
                try
                {
                    Directory.CreateDirectory(Globals.AppDataPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        //=====================================================================================================================================================================
        public bool CreateDefaultConf()
        {
            CheckIfAppDataPathExists();

            xConf = new XmlDocument();
            XmlAttribute attr;

            XmlDeclaration docType = xConf.CreateXmlDeclaration("1.0", "UTF-8", null);
            xConf.AppendChild(docType);

            XmlNode NameSpace = xConf.CreateElement(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace);
            xConf.AppendChild(NameSpace);

            XmlNode ConfigNode = xConf.CreateElement("configuration");
            attr = xConf.CreateAttribute("CreationTimeStamp");
            attr.Value = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss:fff", CultureInfo.InvariantCulture);
            ConfigNode.Attributes.Append(attr);
            attr = xConf.CreateAttribute("LastModified");
            attr.Value = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss:fff", CultureInfo.InvariantCulture);
            ConfigNode.Attributes.Append(attr);
            NameSpace.AppendChild(ConfigNode);
            
            XmlNode ApplicationSettings = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Application";
            ApplicationSettings.Attributes.Append(attr);
            ConfigNode.AppendChild(ApplicationSettings);

            XmlNode DBConf = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Database";
            DBConf.Attributes.Append(attr);
            ApplicationSettings.AppendChild(DBConf);
            
            XmlNode BackupDBFile = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Database Backup";
            BackupDBFile.Attributes.Append(attr);
            DBConf.AppendChild(BackupDBFile);

            XmlNode BackupOnAppExit = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "DbBackupOnAppExit";
            BackupOnAppExit.Attributes.Append(attr);
            BackupOnAppExit.InnerText = "False";
            BackupDBFile.AppendChild(BackupOnAppExit);

            XmlNode CompressBeforeBackup = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "DbCompressionBeforeBackup";
            CompressBeforeBackup.Attributes.Append(attr);
            CompressBeforeBackup.InnerText = "False";
            BackupDBFile.AppendChild(CompressBeforeBackup);

            XmlNode GeneralApplicationSettings = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "GeneralSettings";
            GeneralApplicationSettings.Attributes.Append(attr);
            ApplicationSettings.AppendChild(GeneralApplicationSettings);

            XmlNode LastDBFileName = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "LastDBFile";
            LastDBFileName.Attributes.Append(attr);
            GeneralApplicationSettings.AppendChild(LastDBFileName);

            XmlNode LastDBFilePath = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "LastDBFilePath";
            LastDBFilePath.Attributes.Append(attr);
            GeneralApplicationSettings.AppendChild(LastDBFilePath);

            XmlNode MinimizeToTray = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "MinimizeToTray";
            MinimizeToTray.Attributes.Append(attr);
            MinimizeToTray.InnerText = "False";
            GeneralApplicationSettings.AppendChild(MinimizeToTray);

            XmlNode ApplicationLanguage = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "UICulture";
            ApplicationLanguage.Attributes.Append(attr);
            ApplicationLanguage.InnerText = CultureInfo.CurrentUICulture.ToString();
            GeneralApplicationSettings.AppendChild(ApplicationLanguage);

            XmlNode AddressBookSettings = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "AddressBook";
            AddressBookSettings.Attributes.Append(attr);
            ApplicationSettings.AppendChild(AddressBookSettings);

            XmlNode AutoFill = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "UseAutoFillForContacts";
            AutoFill.Attributes.Append(attr);
            AddressBookSettings.AppendChild(AutoFill);

            XmlNode AutoFillCities = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "UseAutoFillOnCities";
            AutoFillCities.Attributes.Append(attr);
            AutoFillCities.InnerText = "False";
            AutoFill.AppendChild(AutoFillCities);

            XmlNode AutoFillFederalStates = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "UseAutoFillOnFederalStates";
            AutoFillFederalStates.Attributes.Append(attr);
            AutoFillFederalStates.InnerText = "False";
            AutoFill.AppendChild(AutoFillFederalStates);

            XmlNode ValidateAddressData = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "AddressValidation";
            ValidateAddressData.Attributes.Append(attr);
            AddressBookSettings.AppendChild(ValidateAddressData);

            XmlNode ValidateNameFields = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "ValidateNames";
            ValidateNameFields.Attributes.Append(attr);
            ValidateNameFields.InnerText = "False";
            ValidateAddressData.AppendChild(ValidateNameFields);

            XmlNode ValidateEmailField = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "ValidateEmail";
            ValidateEmailField.Attributes.Append(attr);
            ValidateEmailField.InnerText = "False";
            ValidateAddressData.AppendChild(ValidateEmailField);

            XmlNode ValidateAddressFields = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "ValidateAddressData";
            ValidateAddressFields.Attributes.Append(attr);
            ValidateAddressFields.InnerText = "False";
            ValidateAddressData.AppendChild(ValidateAddressFields);

            try
            {
                xConf.Save(Globals.AppDataPath + @"\config.xml");

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Debug Handling
                return false;
            }
        }

        //=====================================================================================================================================================================
        public void ReadXmlConf()
        {
            xConf = new XmlDocument();

            xConf.Load(GetConfFile());

            XmlNodeList ConfNode;
            XmlNode root = xConf.DocumentElement;

            //Read DataBase Config 
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='GeneralSettings']/parameter");

            string DBFileName = null;
            string DBFilePath = null;
            string MinimizeToTray = null;
            string UICulture = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "LastDBFile")
                {
                    DBFileName = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "LastDBFilePath")
                {
                    DBFilePath = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "MinimizeToTray")
                {
                    MinimizeToTray = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "UICulture")
                {
                    UICulture = Conf.InnerText;
                }
            }

            Globals.DBFile = DBFileName;
            Globals.DBFilePath = DBFilePath;
            Globals.MinimizeToTray = ConvertToBool(MinimizeToTray);
            Globals.UICulture = UICulture;

            //Read DataBase Backup Config
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='Database']/group[@name='Database Backup']/parameter");

            string BackupDBonAppClose = null;
            string CompressDBbeforeBackup = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "DbBackupOnAppExit")
                {
                    BackupDBonAppClose = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "DbCompressionBeforeBackup")
                {
                    CompressDBbeforeBackup = Conf.InnerText;
                }
            }

            Globals.BackupDBOnAppClose = ConvertToBool(BackupDBonAppClose);
            Globals.CompressDBBeforeBackup = ConvertToBool(CompressDBbeforeBackup);         

            // Read AutoFill Settings
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='AddressBook']/group[@name='UseAutoFillForContacts']/parameter");

            string AutoFillCities = null;
            string AutoFillFederalStates = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "UseAutoFillOnCities")
                {
                    AutoFillCities = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "UseAutoFillOnFederalStates")
                {
                    AutoFillFederalStates = Conf.InnerText;
                }
            }

            Globals.UseAutoFillOnCities = ConvertToBool(AutoFillCities);
            Globals.UseAutoFillOnFederalStates = ConvertToBool(AutoFillFederalStates);

            // Read AutoFill Settings
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='AddressBook']/group[@name='AddressValidation']/parameter");

            string ValidateNames = null;
            string ValidateEmail = null;
            string ValidateAddressData = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "ValidateNames")
                {
                    ValidateNames = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "ValidateEmail")
                {
                    ValidateEmail = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "ValidateAddressData")
                {
                    ValidateAddressData = Conf.InnerText;
                }
            }

            Globals.ValidateNames = ConvertToBool(ValidateNames);
            Globals.ValidateEmail = ConvertToBool(ValidateEmail);
            Globals.ValidateAddressData = ConvertToBool(ValidateAddressData);
        }

        //=====================================================================================================================================================================
        public void UpdateXmlConf(string ParamName, string ParamValue)
        {
            //MessageBox.Show(ParamName + ", " + ParamValue);

            xConf = new XmlDocument();

            xConf.Load(GetConfFile());

            XmlNode xConfNode = xConf.DocumentElement;
            xConfNode.SelectNodes("descendant::configuration");

            foreach (XmlNode xConfN in xConfNode)
            {
                xConfN.Attributes["LastModified"].Value = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss:fff", CultureInfo.InvariantCulture);
            }

            XmlNodeList ConfNode = null;
            XmlNode root = xConf.DocumentElement;

            switch (ParamName)
            {
                case "LastDBFile":
                case "LastDBFilePath":
                case "MinimizeToTray":
                case "UICulture":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='GeneralSettings']/parameter");

                    break;

                case "DbBackupOnAppExit":
                case "DbCompressionBeforeBackup":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='Database']/group[@name='Database Backup']/parameter");

                    break;

                case "UseAutoFillOnCities":
                case "UseAutoFillOnFederalStates":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='AddressBook']/group[@name='UseAutoFillForContacts']/parameter");

                    break;

                case "ValidateNames":
                case "ValidateEmail":
                case "ValidateAddressData":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/group[@name='AddressBook']/group[@name='AddressValidation']/parameter");

                    break;
            }

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == ParamName)
                {
                    Conf.InnerText = ParamValue;
                }
            }

            try
            {
                xConf.Save(GetConfFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ReadXmlConf();
        }

        //=====================================================================================================================================================================
        private bool ConvertToBool(string ParamValue)
        {
            string[] BoolValues = { "true", "True" ,"1", "false", "False", "0" };

            foreach (string BValue in BoolValues)
            {
                if (ParamValue == BValue)
                {
                    return Convert.ToBoolean(ParamValue);
                }
            }
            return false;
        }
    }
}
