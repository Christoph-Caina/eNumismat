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

            xConf.Load(Globals.AppDataPath + @"\config.xml");

            XmlNodeList aNodes;
            XmlNode root = xConf.DocumentElement;

            aNodes = root.SelectNodes("descendant::configuration/group[@name='Database']/parameter");

            foreach (XmlNode aNode in aNodes)
            {
                //Do Work :)
                //MessageBox.Show(aNode.InnerText);
            }
        }

        //=====================================================================================================================================================================
        public void UpdateXmlConf(string GroupName, string ParamName, string ParamValue)
        {
            xConf = new XmlDocument();

            xConf.Load(Globals.AppDataPath + @"\config.xml");

            XmlNodeList aNodes;
            XmlNode root = xConf.DocumentElement;

            aNodes = root.SelectNodes("descendant::configuration/group[@name='Database']/parameter");

            foreach (XmlNode aNode in aNodes)
            {
                if (aNode.Attributes["name"].Value == ParamName)
                {
                    aNode.InnerText = ParamValue;
                }
            }

            XmlNode Conf = xConf.DocumentElement;
            Conf.SelectNodes("descendant::configuration");

            foreach (XmlNode _Conf in Conf)
            {
                _Conf.Attributes["LastModified"].Value = DateTime.Now.ToString(@"yyyy/MM/dd HH:mm:ss:fff", CultureInfo.InvariantCulture);
            }

            try
            {
                xConf.Save(Globals.AppDataPath + @"\config.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
