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
using System.Data.SQLite;

namespace eNumismat
{
    public partial class CSVImport : Form
    {
        public string CsvFile { get; set; }

        readonly string _DBFile = Path.Combine(Globals.DBFilePath, Globals.DBFile);

        public string GetDBFile()
        {
            return _DBFile;
        }

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

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Import Data into Database
            // Step1 - Check for Duplicate NAME1 and FAMILYNAME
            // If record is available, do what???

            // Handle impor with less columns than expected in the database

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + GetDBFile()))
            {
                dbConnection.Open();
                string SQL = null;

                
                using (var transaction = dbConnection.BeginTransaction())
                {
                    for (int i = 0; i < resultData.Rows.Count - 1; i++)
                    {
                        SQL = @"INSERT INTO `contacts` " +
                            "(`name1`, `name2`, `familyname`, `gender`, `birthdate`, `addrline1`, `addrline2`, `postalcode`, `city`, `state`, `country`, `phone`, `mobile`, `email`, `notes`)" +
                            " VALUES " +
                            "(@ContactName1, @ContactName2, @ContactFamilyName, @ContactGender, @ContactBirthdate, @ContactAddrLine1, @ContactAddrLine2, @ContactPostalCode, @ContactCity, @ContactState, @ContactCountry, @ContactPhone, @ContactMobile, @ContactMail, @ContactNotes); ";

                        using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                        {
                            // each ComboBox needs to be checked, if the selectedItem is NULL or EMPTY
                            // if YES - we need to insert NULL as value.
                            // Currently, the CELL ID will be set to NULL; which is not Possible.
                            // We can onyl take the resultDataValue, if we already have a CELL ID
                            command.Parameters.AddWithValue("@ContactName1", resultData.Rows[i].Cells[cb_name1.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactName2", resultData.Rows[i].Cells[cb_name2.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactFamilyName", resultData.Rows[i].Cells[cb_familyname.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactGender", resultData.Rows[i].Cells[cb_gender.Text.ToString()].Value);

                            command.Parameters.AddWithValue("@ContactBirthdate", resultData.Rows[i].Cells[cb_birthdate.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactAddrLine1", resultData.Rows[i].Cells[cb_addrline1.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactAddrLine2", resultData.Rows[i].Cells[cb_addrline2.Text.ToString()].Value);

                            command.Parameters.AddWithValue("@ContactPostalCode", resultData.Rows[i].Cells[cb_postalcode.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactCity", resultData.Rows[i].Cells[cb_city.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactState", resultData.Rows[i].Cells[cb_state.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactCountry", resultData.Rows[i].Cells[cb_country.Text.ToString()].Value);

                            command.Parameters.AddWithValue("@ContactPhone", resultData.Rows[i].Cells[cb_phone.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactMobile", resultData.Rows[i].Cells[cb_mobile.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactMail", resultData.Rows[i].Cells[cb_email.Text.ToString()].Value);
                            command.Parameters.AddWithValue("@ContactNotes", resultData.Rows[i].Cells[cb_notes.Text.ToString()].Value);

                            try
                            {
                                command.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                //dbConnection.Close();
                                //dbConnection.Dispose();
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                    transaction.Commit();
                }

                dbConnection.Close();
                dbConnection.Dispose();

                MessageBox.Show("Import finished");
                Hide();
            }
        }
    }
}
