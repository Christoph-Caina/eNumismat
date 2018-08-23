using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Ude;

namespace eNumismat
{
    public partial class CSVImport : Form
    {
        public string CsvFile { get; set; }
        List<string> Headers = new List<string>();

        TextFieldParser tfp;

        public CSVImport()
        {
            InitializeComponent();

            cb_name1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_name2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_familyname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_gender.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_birthdate.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_addrline1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_addrline2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_postalcode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_city.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_state.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_country.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_phone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_mobile.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_email.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cb_notes.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void CSVImport_Load(object sender, EventArgs e)
        {

            using (FileStream fs = File.OpenRead(CsvFile))
            {
                CharsetDetector cdet = new CharsetDetector();
                cdet.Feed(fs);
                cdet.DataEnd();
                if (cdet.Charset != null)
                {
                    tfp = new TextFieldParser(CsvFile, Encoding.GetEncoding(cdet.Charset));
                }

                else
                {
                    tfp = new TextFieldParser(CsvFile, Encoding.ASCII);
                }
            }
        }

        private DataTable NewDataTable(string fileName, char delimiters, bool firstRowContainsFieldNames = true)
        {
            DataTable result = new DataTable();

            using (tfp)
            {
                tfp.SetDelimiters(delimiters.ToString());

                // Get Some Column Names
                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();

                    for (int i = 0; i < fields.Count(); i++)
                    {
                        if (firstRowContainsFieldNames)
                        {
                            result.Columns.Add(fields[i]);
                            Headers.Add(fields[i]);
                        }

                        else
                        {
                            result.Columns.Add("Col" + i);
                            Headers.Add("Col" + i);
                        }
                    }

                    // If first line is data then add it
                    if (!firstRowContainsFieldNames)
                        result.Rows.Add(fields);
                }

                // Get Remaining Rows
                while (!tfp.EndOfData)
                    result.Rows.Add(tfp.ReadFields());
            }
            return result;
            // Do Something
        }

        private void cb_separator_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char delimiter = (char)0;

            if (cb_separator.SelectedItem.ToString() == ", (comma)")
            {
                delimiter = ',';
            }
            else if (cb_separator.SelectedItem.ToString() == "; (semicolon)")
            {
                delimiter = ';';
            }
            else if (cb_separator.SelectedItem.ToString() == "\t (tabulator)")
            {
                delimiter = '\t';
            }

            resultData.DataSource = NewDataTable(CsvFile, delimiter, cb_HasHeader.Checked);

            cb_name1.SelectedItem = Headers[0];
            cb_name1.DataSource = Headers;

            cb_name2.SelectedItem = Headers[0];
            cb_name1.DataSource = Headers;

            cb_familyname.SelectedItem = Headers[0];
            cb_familyname.DataSource = Headers;

            cb_gender.SelectedItem = Headers[0];
            cb_gender.DataSource = Headers;

            cb_birthdate.SelectedItem = Headers[0];
            cb_birthdate.DataSource = Headers;

            cb_addrline1.SelectedItem = Headers[0];
            cb_addrline1.DataSource = Headers;

            cb_addrline2.SelectedItem = Headers[0];
            cb_addrline2.DataSource = Headers;

            cb_postalcode.SelectedItem = Headers[0];
            cb_postalcode.DataSource = Headers;

            cb_city.SelectedItem = Headers[0];
            cb_city.DataSource = Headers;

            cb_state.SelectedItem = Headers[0];
            cb_state.DataSource = Headers;

            cb_country.SelectedItem = Headers[0];
            cb_country.DataSource = Headers;

            cb_phone.SelectedItem = Headers[0];
            cb_phone.DataSource = Headers;

            cb_mobile.SelectedItem = Headers[0];
            cb_mobile.DataSource = Headers;

            cb_email.SelectedItem = Headers[0];
            cb_email.DataSource = Headers;

            cb_notes.SelectedItem = Headers[0];
            cb_notes.DataSource = Headers;
        }
    }
}
