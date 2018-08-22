using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace eNumismat
{
    class DataImport
    {
        List<string> ZIP = new List<string>();
        List<string> CITY = new List<string>();
        List<string> FEDERALSTATE = new List<string>();
        List<string> COUNTRY = new List<string>();

        public void FromFile(string filePath)
        {
            StreamReader sr = new StreamReader(File.OpenRead(filePath));

            while (!sr.EndOfStream)
            {
                string Line = sr.ReadLine();
                string[] values = Line.Split(';');

                ZIP.Add(values[1].ToString());
                CITY.Add(values[0].ToString());
                FEDERALSTATE.Add(values[2].ToString());
                //COUNTRY.Add(values[3].ToString());
            }

            ImportIntoDatabase();
            //do some work here
        }

        private void ImportIntoDatabase()
        {
            foreach(string value in ZIP)
            {
                // Remove Duplicates and insert into PLZ Table
            }

            foreach(string value in CITY)
            {
                // Remove Duplicates and insert into CITY Table
            }

            foreach(string value in FEDERALSTATE)
            {
                // Remove Duplicates and insert into FEDERALSTATES Table
            }

            // -> create connections between the values by reading the file Line By Line and compare with Data in the Database
        }
    }
}
