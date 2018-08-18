using System;
using System.Collections.Generic;
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
            attr.Value = "Backup Database on Application Close";
            BackupOnAppExit.Attributes.Append(attr);
            BackupOnAppExit.InnerText = "true";
            BackupDBFile.AppendChild(BackupOnAppExit);

            XmlNode CompressBeforeBackup = xConf.CreateElement("parameter");
            attr = xConf.CreateAttribute("name");
            attr.Value = "Compress Database before Backup";
            CompressBeforeBackup.Attributes.Append(attr);
            CompressBeforeBackup.InnerText = "true";
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
            MinimizeToTray.InnerText = "true";
            ApplicationSettings.AppendChild(MinimizeToTray);

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
                if (Conf.Attributes["name"].Value == "Backup Database on Application Close")
                {
                    BackupDBonAppClose = Conf.InnerText;
                }

                if (Conf.Attributes["name"].Value == "Compress Database before Backup")
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
        }

        //=====================================================================================================================================================================
        public void UpdateXmlConf(string GroupName, string ParamName, string ParamValue)
        {
            xConf = new XmlDocument();

            xConf.Load(ConfFile);

            XmlNode xConfNode = xConf.DocumentElement;
            xConfNode.SelectNodes("descendant::configuration");

            foreach (XmlNode xConfN in xConfNode)
            {
                xConfN.Attributes["LastModified"].Value = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss:fff", CultureInfo.InvariantCulture);
            }

            XmlNodeList DBConfNode;
            XmlNode root = xConf.DocumentElement;

            DBConfNode = root.SelectNodes("descendant::configuration/group[@name='Database']/parameter");

            foreach (XmlNode DBConf in DBConfNode)
            {
                if (DBConf.Attributes["name"].Value == ParamName)
                {
                    DBConf.InnerText = ParamValue;
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

        }

        private bool ConvertToBool(string ParamValue)
        {
            string[] BoolValues = { "true", "1", "false", "0" };

            foreach (string BValue in BoolValues)
            {
                if (ParamValue == BValue)
                {
                    return Convert.ToBoolean(ParamValue);
                }
                //return null;
            }
            return false;
        }
    }
}
