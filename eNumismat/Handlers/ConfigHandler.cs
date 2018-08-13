using System;
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

            XmlNode docType = xConf.CreateXmlDeclaration("1.0", "UTF-8", null);
            xConf.AppendChild(docType);

            XmlNode NameSpace = xConf.CreateElement(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace);
            xConf.AppendChild(NameSpace);

            XmlNode ConfigNode = xConf.CreateElement("configuration");
            NameSpace.AppendChild(ConfigNode);

            XmlNode DBConf = xConf.CreateElement("DataBase");
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

        }

        //=====================================================================================================================================================================
        public void UpdateXmlConf()
        {

        }
    }
}
