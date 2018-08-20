using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace eNumismat
{
    class DBActions
    {
        string _DBFile = Path.Combine(Globals.DBFilePath, Globals.DBFile);

        //=====================================================================================================================================================================
        public bool CreateNew()
        {
            string _sqlStatement = null;

            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
                {
                    dbConnection.Open();

                    _sqlStatement = Properties.Resources.Create.ToString();

                    using (SQLiteCommand command = new SQLiteCommand(_sqlStatement, dbConnection))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                            dbConnection.Close();
                            dbConnection.Dispose();

                            return false;
                        }
                    }

                    _sqlStatement = Properties.Resources.Insert.ToString();

                    using (SQLiteCommand command = new SQLiteCommand(_sqlStatement, dbConnection))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                            dbConnection.Close();
                            dbConnection.Dispose();

                            return false;
                        }
                    }
                    dbConnection.Close();
                    dbConnection.Dispose();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                return false;
            }
        }

        //=====================================================================================================================================================================
        public int ContactsCount()
        {
            int _rowCounter = 0;

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    return _rowCounter;
                }

                string SQL =
                    "SELECT COUNT (*) FROM `contacts`";

                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    try
                    {
                        _rowCounter = Convert.ToInt32(command.ExecuteScalar());
                        dbConnection.Close();
                        dbConnection.Dispose();

                        return _rowCounter;
                    }
                    catch (Exception ex)
                    {
                        dbConnection.Close();
                        dbConnection.Dispose();

                        return _rowCounter;
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        public DataTable GetContacts(string content, string FirstLetter = null, string[] contactDetails = null, int ID = 0)
        {
            
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
            {
                dbConnection.Open();
                
                string SQL = null;

                switch (content)
                {                    
                    case "parents":
                        SQL = "SELECT count(name), substr(name, 1, 1) FROM contacts GROUP by substr(name, 1, 1)";
                        break;

                    case "childs":
                        SQL = "SELECT name, surename, gender FROM contacts WHERE name LIKE @FirstLEtter ORDER BY surename ASC";
                        break;

                    case "details":

                        if (contactDetails == null && ID == 0)
                        {
                            SQL = "SELECT * FROM contacts ORDER BY name, surename LIMIT 1";
                        }
                        else if (contactDetails != null && ID == 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = @ContactName AND `surename` = @ContactSureName LIMIT 1";
                        }
                        else if (contactDetails == null && ID != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE id = '" + ID + "'";
                        }
                        else if (contactDetails != null && ID != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = @ContactName AND `surename` = @ContactSureName AND `id` = @ContactID LIMIT 1";
                        }
                        break;
                }

                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    if (FirstLetter != null)
                    {
                        command.Parameters.AddWithValue("@FirstLetter", FirstLetter + "%");
                    }

                    if (contactDetails != null)
                    {
                        command.Parameters.AddWithValue("@ContactName", contactDetails[0]);
                        command.Parameters.AddWithValue("@ContactSureName", contactDetails[1]);
                    }

                    if (ID != 0)
                    {
                        command.Parameters.AddWithValue("@ContactID", ID);
                    }

                    using (SQLiteDataAdapter daContacts = new SQLiteDataAdapter(command))
                    { 
                        DataTable Contacts = new DataTable();

                        try
                        {
                            daContacts.Fill(Contacts);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        dbConnection.Close();
                        dbConnection.Dispose();

                        return Contacts;
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        public bool CreateOrUpdateContact(List<string> contactDetails, int ID = 0)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
                {
                    dbConnection.Open();
                    string SQL = null;

                    if (ID == 0)
                    {
                        SQL = "INSERT INTO `contacts`" +
                            "(`name`, `surename`, `gender`, `birthdate`, `street`, `zipcode`, `city`, `country`, `phone`, `mobile`, `email`, `notes`)" +
                            "VALUES" +
                            "(@ContactName, @ContactSureName, @ContactGender, @ContactBirthdate, @ContactStreet, @ContactZipCode, @ContactCity, @ContactCountry, @ContactPhone, @ContactMobile, @ContactMail, @ContactNotes);";
                    }
                    else
                    {
                        SQL = "UPDATE `contacts`" +
                            "SET" +
                            " `name` = @ContactName, `surename` = @ContactSureName, `gender` = @ContactGender, `birthdate` = @ContactBirthdate, `street` = @ContactStreet, `zipcode` = @ContactZipCode, `city` = @ContactCity, `country` = @ContactCountry, `phone` = @ContactPhone, `mobile` = @ContactMobile, `email` = @ContactMail, `notes` = @ContactNotes WHERE `id` = @ContactID ;";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@ContactName", contactDetails[0]);
                        command.Parameters.AddWithValue("@ContactSureName", contactDetails[1]);
                        command.Parameters.AddWithValue("@ContactGender", contactDetails[2]);
                        command.Parameters.AddWithValue("@ContactBirthdate", contactDetails[3]);
                        command.Parameters.AddWithValue("@ContactStreet", contactDetails[4]);
                        command.Parameters.AddWithValue("@ContactZipCode", contactDetails[5]);
                        command.Parameters.AddWithValue("@ContactCity", contactDetails[6]);
                        command.Parameters.AddWithValue("@ContactCountry", contactDetails[7]);
                        command.Parameters.AddWithValue("@ContactPhone", contactDetails[8]);
                        command.Parameters.AddWithValue("@ContactMobile", contactDetails[9]);
                        command.Parameters.AddWithValue("@ContactMail", contactDetails[10]);
                        command.Parameters.AddWithValue("@ContactNotes", contactDetails[11]);
                        command.Parameters.AddWithValue("@ContactID", ID);

                        try
                        {
                            command.ExecuteNonQuery();
                            dbConnection.Close();
                            dbConnection.Dispose();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            dbConnection.Close();
                            dbConnection.Dispose();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //=====================================================================================================================================================================
        public bool DeleteContact(string[] contactDetails = null, int ID = 0)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
                {
                    dbConnection.Open();
                    string SQL = null;

                    if (contactDetails == null && ID == 0)
                    {
                        MessageBox.Show("Can't delete \"nothing\"");

                        return false;
                    }
                    else if (contactDetails != null && ID == 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = @ContactName AND `surename` = @ContactSureName";
                    }
                    else if (contactDetails == null && ID != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE id = @ContactID";
                    }
                    else if (contactDetails != null && ID != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = @ContactName AND `surename` = @ContactSureName AND `id` = @ContactID";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                    {
                        if (contactDetails != null)
                        {
                            command.Parameters.AddWithValue("@ContactName", contactDetails[0]);
                            command.Parameters.AddWithValue("@ContactSureName", contactDetails[1]);
                        }
                        if (ID != 0)
                        {
                            command.Parameters.AddWithValue("@ContactID", ID);
                        }

                        try
                        {
                            command.ExecuteNonQuery();
                            dbConnection.Close();
                            dbConnection.Dispose();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            dbConnection.Close();
                            dbConnection.Dispose();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        //=====================================================================================================================================================================
        public int SwapCount()
        {
            int _rowCounter = 0;

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    return _rowCounter;
                }

                string SQL =
                    "SELECT COUNT (*) FROM `swaplist`";

                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    try
                    {
                        _rowCounter = Convert.ToInt32(command.ExecuteScalar());
                        dbConnection.Close();
                        dbConnection.Dispose();

                        return _rowCounter;
                    }
                    catch (Exception ex)
                    {
                        dbConnection.Close();
                        dbConnection.Dispose();

                        return _rowCounter;
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        public DataTable GetSwapListDetails(string content, string[] ContactDetails = null)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + _DBFile))
            {
                dbConnection.Open();

                string SQL = null;

                if (content == "parents")
                {
                    SQL =
                        "SELECT contacts.name, contacts.surename FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id GROUP BY contacts.name, contacts.surename";
                }
                else if (content == "childs")
                {
                    SQL =
                        "SELECT swaplist.date, swaplist.swapstatus, swaplist.tracking_code_out FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id WHERE contacts.name = @ContactName AND contacts.surename = @ContactSureName";
                }
                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    command.Parameters.AddWithValue("@ContactName", ContactDetails[0]);
                    command.Parameters.AddWithValue("@ContactSureName", ContactDetails[1]);
                    
                    using (SQLiteDataAdapter daSwaps = new SQLiteDataAdapter(command))
                    {
                        DataTable SwapListDetails = new DataTable();

                        daSwaps.Fill(SwapListDetails);

                        dbConnection.Close();
                        dbConnection.Dispose();

                        return SwapListDetails;
                    }
                }
            }
        }

        /*public List<string> GetAutoFill()
        {
            string AutoCompleteDBFile = Path.Combine(Globals.AppDataPath, @"AutoComplete.db");

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + AutoCompleteDBFile))
            {
                //  string connstr = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename =\"D:dbusers.mdf\"; Integrated Security = True";
                //  SQLiteConnection conn = new SQLiteConnection(connstr);

                string[] restrictions = new string[4] { null, null, "addnewitem", null };
                dbConnection.Open();
                var columnList = dbConnection.GetSchema("Columns", restrictions).AsEnumerable().Select(s => s.Field<String>("Column_Name")).ToList();
                return columnList;
            }
        }*/


        
        // GET DATA FROM AUTOCOMPLETE DB...
        public DataTable GetAutoComplete(string table)
        {
            string AutoCompleteDBFile = Path.Combine(Globals.AppDataPath, @"AutoComplete.db");

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + AutoCompleteDBFile))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                { }

                string SQL = "SELECT * FROM `" + table +"`";

                using (SQLiteCommand cmd = new SQLiteCommand(SQL, dbConnection))
                {
                    MessageBox.Show(table);

                    using (SQLiteDataAdapter daAutoComplete = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dtAutoFill = new DataTable();

                        daAutoComplete.Fill(dtAutoFill);

                        return dtAutoFill;
                    }
                }
            }
        }
    }
}


/*
 * COIN Übersicht
 * 
 *  SELECT coins.name, coins.year, coins.mint_sign, mint_types.name, qualities.short, coin_status.name FROM coins LEFT JOIN mint_types ON mint_types.id = coins.mint_type_id LEFT JOIN qualities ON qualities.id = coins.quality_id LEFT JOIN coin_status ON coin_status.id = coins.status_id
 * 
 * 
 */