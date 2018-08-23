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

        TextFieldParser tfp;

        public CSVImport()
        {
            InitializeComponent();

            /*cb_name1.AutoCompleteSource = AutoCompleteSource.CustomSource;
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
            cb_notes.AutoCompleteSource = AutoCompleteSource.CustomSource;*/
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
                        }

                        else
                        {
                            result.Columns.Add("Col" + i);
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
            button1.Enabled = true;
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

            LoadHeadersForCbName1();
            LoadHeadersForCbName2();
            LoadHeadersForCbFamilyName();
            LoadHeadersForCbGender();
            LoadHeadersForCbBirthDate();
            LoadHeadersForCbAddrLine1();
            LoadHeadersForCbAddrLine2();
            LoadHeadersForCbPostalCode();
            LoadHeadersForCbCity();
            LoadHeadersForCbState();
            LoadHeadersForCbCountry();
            LoadHeadersForCbPhone();
            LoadHeadersForCbMobilePhone();
            LoadHeadersForCbEmail();
            LoadHeadersForCbNotes();
        }

        private void LoadHeadersForCbName1()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_name1.DataSource = colNameList;
        }

        private void LoadHeadersForCbName2()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_name2.DataSource = colNameList;
        }

        private void LoadHeadersForCbFamilyName()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_familyname.DataSource = colNameList;
        }

        private void LoadHeadersForCbGender()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_gender.DataSource = colNameList;
        }

        private void LoadHeadersForCbBirthDate()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_birthdate.DataSource = colNameList;
        }

        private void LoadHeadersForCbAddrLine1()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_addrline1.DataSource = colNameList;
        }

        private void LoadHeadersForCbAddrLine2()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_addrline2.DataSource = colNameList;
        }

        private void LoadHeadersForCbPostalCode()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_postalcode.DataSource = colNameList;
        }

        private void LoadHeadersForCbCity()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_city.DataSource = colNameList;
        }

        private void LoadHeadersForCbState()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_state.DataSource = colNameList;
        }

        private void LoadHeadersForCbCountry()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_country.DataSource = colNameList;
        }

        private void LoadHeadersForCbPhone()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_phone.DataSource = colNameList;
        }

        private void LoadHeadersForCbMobilePhone()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_mobile.DataSource = colNameList;
        }

        private void LoadHeadersForCbEmail()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_email.DataSource = colNameList;
        }

        private void LoadHeadersForCbNotes()
        {
            List<string> colNameList = new List<string>();
            foreach (DataGridViewColumn col in resultData.Columns)
            {
                colNameList.Add(col.Name);
            }
            cb_notes.DataSource = colNameList;
        }
    }
}
