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
        string ConfFile = Path.Combine(Globals.AppDataPath, @"config.xml");

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

            XmlNode DBConf = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Database";
            DBConf.Attributes.Append(attr);
            ConfigNode.AppendChild(DBConf);

            XmlNode LastDBFileName = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "LastDBFile";
            LastDBFileName.Attributes.Append(attr);
            DBConf.AppendChild(LastDBFileName);

            XmlNode LastDBFilePath = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "LastDBFilePath";
            LastDBFilePath.Attributes.Append(attr);
            DBConf.AppendChild(LastDBFilePath);

            XmlNode BackupDBFile = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Database Backup";
            BackupDBFile.Attributes.Append(attr);
            DBConf.AppendChild(BackupDBFile);

            XmlNode BackupOnAppExit = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "DbBackupOnAppExit";
            BackupOnAppExit.Attributes.Append(attr);
            BackupOnAppExit.InnerText = "false";
            BackupDBFile.AppendChild(BackupOnAppExit);

            XmlNode CompressBeforeBackup = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "DbCompressionBeforeBackup";
            CompressBeforeBackup.Attributes.Append(attr);
            CompressBeforeBackup.InnerText = "false";
            BackupDBFile.AppendChild(CompressBeforeBackup);

            XmlNode ApplicationSettings = xConf.CreateElement("group");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Application";
            ApplicationSettings.Attributes.Append(attr);
            ConfigNode.AppendChild(ApplicationSettings);

            XmlNode MinimizeToTray = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "MinimizeToTray";
            MinimizeToTray.Attributes.Append(attr);
            MinimizeToTray.InnerText = "false";
            ApplicationSettings.AppendChild(MinimizeToTray);

            XmlNode ApplicationLanguage = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "UICulture";
            ApplicationLanguage.Attributes.Append(attr);
            ApplicationLanguage.InnerText = CultureInfo.CurrentUICulture.ToString();
            ApplicationSettings.AppendChild(ApplicationLanguage);

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

            xConf.Load(ConfFile);

            XmlNodeList ConfNode;
            XmlNode root = xConf.DocumentElement;

            //Read DataBase Config 
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Database']/parameter");

            string DBFileName = null;
            string DBFilePath = null;

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
            }

            Globals.DBFile = DBFileName;
            Globals.DBFilePath = DBFilePath;

            //Read DataBase Backup Config
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Database']/group[@name='Database Backup']/parameter");

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

            // Read MinimizeToTray Config
            ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/parameter");

            string MinimizeToTray = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "MinimizeToTray")
                {
                    MinimizeToTray = Conf.InnerText;
                }
            }

            Globals.MinimizeToTray = ConvertToBool(MinimizeToTray);

            // Read Application Language
            string UICulture = null;

            foreach (XmlNode Conf in ConfNode)
            {
                if (Conf.Attributes["name"].Value == "UICulture")
                {
                    UICulture = Conf.InnerText;
                }
            }

            Globals.UICulture = UICulture;
        }

        //=====================================================================================================================================================================
        public void UpdateXmlConf(string ParamName, string ParamValue)
        {
            //MessageBox.Show(ParamName + ", " + ParamValue);

            xConf = new XmlDocument();

            xConf.Load(ConfFile);

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
                    
                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Database']/parameter");

                    break;

                case "DbBackupOnAppExit":
                case "DbCompressionBeforeBackup":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Database']/group[@name='Database Backup']/parameter");

                    break;

                case "MinimizeToTray":
                case "UICulture":

                    ConfNode = root.SelectNodes("descendant::configuration/group[@name='Application']/parameter");

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
                xConf.Save(ConfFile);
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
