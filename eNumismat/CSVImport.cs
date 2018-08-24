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
        List<string> ColumnHeaders = new List<string>();

        readonly string _DBFile = Path.Combine(Globals.DBFilePath, Globals.DBFile);

        public string GetDBFile()
        {
            return _DBFile;
        }

        TextFieldParser tfp;

        public CSVImport()
        {
            InitializeComponent();

            /*using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + GetDBFile()))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    //return _rowCounter;
                }
                string SQL =
                    "PRAGMA table_info (`contacts`)";
                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    try
                    {
                        SQLiteDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader.GetString(1) != "id")
                            {
                                ColumnHeaders.Add(reader.GetString(1));
                            }

                            //MessageBox.Show(reader.GetString(1));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }*/
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

        private void NewDataTable(string fileName, char delimiters, bool firstRowContainsFieldNames = true)
        {            
            using (tfp)
            {
                tfp.SetDelimiters(delimiters.ToString());

                // Get Some Column Names
                GetColumnNamesFromDB();

                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();

                    for (int i = 0; i < fields.Count(); i++)
                    {
                        resultData.Columns.Add("Col_" + i.ToString(), "UserData_" + i.ToString());

                        ComboBox comboBoxHeaderCell;

                        int ColumnCounter = resultData.Columns.Count;

                        //for (int i2 = 0; i2 < ColumnCounter; i2++)
                        //{
                            comboBoxHeaderCell = new ComboBox();
                            comboBoxHeaderCell.Name = "Col_" + i.ToString();
                            comboBoxHeaderCell.DropDownStyle = ComboBoxStyle.DropDownList;
                            comboBoxHeaderCell.Visible = true;

                            foreach (string Item in ColumnHeaders)
                            {
                                comboBoxHeaderCell.Items.Add(Item);
                                comboBoxHeaderCell.Text = Item;
                            }

                            resultData.Controls.Add(comboBoxHeaderCell);
                            comboBoxHeaderCell.Location = this.resultData.GetCellDisplayRectangle(i, -1, true).Location;
                            comboBoxHeaderCell.Size = this.resultData.Columns[i].HeaderCell.Size;
                            comboBoxHeaderCell.SelectedIndexChanged += new EventHandler(comboBoxHeaderCell_SelectedIndexChanged);
                        //}
                    }
                    // If first line is data then add it
                    if (!firstRowContainsFieldNames)
                        resultData.Rows.Add(fields);
                }

                // Get Remaining Rows
                while (!tfp.EndOfData)
                    resultData.Rows.Add(tfp.ReadFields());
            }
            //return result;
            // Do Something
        }

        private void comboBoxHeaderCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (base.ActiveControl != null)
            {
                resultData.Columns[base.ActiveControl.Name.ToString()].HeaderCell.Value = base.ActiveControl.Text;
                base.ActiveControl.Visible = false;
            }
        }

        private void resultData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //resultData.Controls["Col_" + e.ColumnIndex].Visible = true;
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

        private void GetColumnNamesFromDB()
        {
            string GetDBFile = Path.Combine(@"C: \Users\Christoph.Caina\Documents", @"NewDatabaseStructure.enc");

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + GetDBFile))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                { }
                string SQL =
                    "PRAGMA table_info (`contacts`)";
                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    try
                    {
                        SQLiteDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader.GetString(1) != "id")
                            {
                                ColumnHeaders.Add(reader.GetString(1));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
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

            //resultData.DataSource = 
            NewDataTable(CsvFile, delimiter, cb_HasHeader.Checked);

            

            /*
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
            */
        }

        /*private void LoadHeadersForCbName1()
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
        }*/

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
                            // check, if cb Text value is empty or not.
                            // if it is NULL or EMPTY, we need to set the whole value to NULL
                            if (!string.IsNullOrEmpty(cb_name1.Text))
                            {
                                command.Parameters.AddWithValue("@ContactName1", resultData.Rows[i].Cells[cb_name1.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactName1", "--");
                            }

                            if (!string.IsNullOrEmpty(cb_name2.Text))
                            {
                                command.Parameters.AddWithValue("@ContactName2", resultData.Rows[i].Cells[cb_name2.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactName2", null);
                            }

                            if (!string.IsNullOrEmpty(cb_familyname.Text))
                            {
                                command.Parameters.AddWithValue("@ContactFamilyName", resultData.Rows[i].Cells[cb_familyname.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactFamilyName", "--");
                            }

                            if (!string.IsNullOrEmpty(cb_gender.Text))
                            {
                                command.Parameters.AddWithValue("@ContactGender", resultData.Rows[i].Cells[cb_gender.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactGender", null);
                            }

                            if (!string.IsNullOrEmpty(cb_birthdate.Text))
                            {
                                if (!string.IsNullOrEmpty(resultData.Rows[i].Cells[cb_birthdate.Text.ToString()].Value.ToString()))
                                {
                                    command.Parameters.AddWithValue("@ContactBirthdate", Convert.ToDateTime(resultData.Rows[i].Cells[cb_birthdate.Text.ToString()].Value).ToString("yyyy-MM-dd"));
                                }
                                else
                                {
                                    command.Parameters.AddWithValue("@ContactBirthdate", null);
                                }
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactBirthdate", null);
                            }
                            
                            if (!string.IsNullOrEmpty(cb_addrline1.Text))
                            {
                                command.Parameters.AddWithValue("@ContactAddrLine1", resultData.Rows[i].Cells[cb_addrline1.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactAddrLine1", null);
                            }

                            if (!string.IsNullOrEmpty(cb_addrline2.Text))
                            {
                                command.Parameters.AddWithValue("@ContactAddrLine2", resultData.Rows[i].Cells[cb_addrline2.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactAddrLine2", null);
                            }

                            if(!string.IsNullOrEmpty(cb_postalcode.Text))
                            {
                                command.Parameters.AddWithValue("@ContactPostalCode", resultData.Rows[i].Cells[cb_postalcode.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactPostalCode", null);
                            }

                            if (!string.IsNullOrEmpty(cb_city.Text))
                            {
                                command.Parameters.AddWithValue("@ContactCity", resultData.Rows[i].Cells[cb_city.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactCity", null);
                            }

                            if (!string.IsNullOrEmpty(cb_state.Text))
                            {
                                command.Parameters.AddWithValue("@ContactState", resultData.Rows[i].Cells[cb_state.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactState", null);
                            }

                            if (!string.IsNullOrEmpty(cb_country.Text))
                            {
                                command.Parameters.AddWithValue("@ContactCountry", resultData.Rows[i].Cells[cb_country.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactCountry", null);
                            }

                            if (!string.IsNullOrEmpty(cb_phone.Text))
                            {
                                command.Parameters.AddWithValue("@ContactPhone", resultData.Rows[i].Cells[cb_phone.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactPhone", null);
                            }

                            if (!string.IsNullOrEmpty(cb_mobile.Text))
                            {
                                command.Parameters.AddWithValue("@ContactMobile", resultData.Rows[i].Cells[cb_mobile.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactMobile", null);
                            }

                            if (!string.IsNullOrEmpty(cb_email.Text))
                            {
                                command.Parameters.AddWithValue("@ContactMail", resultData.Rows[i].Cells[cb_email.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactMail", null);
                            }

                            if (!string.IsNullOrEmpty(cb_notes.Text))
                            {
                                command.Parameters.AddWithValue("@ContactNotes", resultData.Rows[i].Cells[cb_notes.Text.ToString()].Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@ContactNotes", null);
                            }

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
