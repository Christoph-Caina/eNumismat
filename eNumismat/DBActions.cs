using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Collections.Generic;


namespace eNumismat
{
    class DBActions
    {
        //=====================================================================================================================================================================
        public bool CreateNew()
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
                {
                    dbConnection.Open();

                    string _sqlStatement = Properties.Resources.SQL.ToString();

                    using (SQLiteCommand command = new SQLiteCommand(_sqlStatement, dbConnection))
                    {
                        try
                        {
                            command.ExecuteNonQuery();
                            dbConnection.Close();
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
        public int ContactsCount()
        {
            int _rowCounter = 0;

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
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
                        return _rowCounter;
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        public DataTable GetContacts(string content, string FirstLetter = null, string[] contactname = null, int contactId = 0)
        {
            DataTable Contacts = new DataTable();

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
            {
                dbConnection.Open();

                string SQL = null;
                

                switch (content)
                {
                    case "parents": 
                        SQL = "SELECT count(name), substr(name, 1, 1) FROM contacts GROUP by substr(name, 1, 1)";
                        //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                        break;

                    case "childs":
                        SQL = "SELECT name, surename, gender FROM contacts WHERE name LIKE @FirstLetter% ORDER BY surename ASC";
                        //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                        //SQLCommand.Parameters.AddWithValue("@name", FirstLetter);
                        break;

                    case "details":

                        if (contactname == null && contactId == 0)
                        {
                            SQL = "SELECT * FROM contacts ORDER BY name, surename LIMIT 1";
                            //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                        }
                        else if (contactname != null && contactId == 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = @ContactName AND `surename` = '@ContactSureName' LIMIT 1";
                            //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                            //SQLCommand.Parameters.AddWithValue("@ContactName", contactname[0]);
                            //SQLCommand.Parameters.AddWithValue("@ContactSureName", contactname[1]);
                        }
                        else if (contactname == null && contactId != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE id = @ContactID";
                            //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                            //SQLCommand.Parameters.AddWithValue("@ContactID", contactId);
                        }
                        else if (contactname != null && contactId != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = @ContactName AND `surename` = @ContactSureName AND `id` = @ContactID LIMIT 1";
                            //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                        }

                        break;
                }

                SQLiteCommand SQLCommand = new SQLiteCommand(SQL, dbConnection);

                if (FirstLetter != null)
                {
                    SQLCommand.Parameters.AddWithValue("@FirstLetter", FirstLetter);
                }

                if (contactname != null)
                {
                    SQLCommand.Parameters.AddWithValue("@ContactName", contactname[0]);
                    SQLCommand.Parameters.AddWithValue("@ContactSureName", contactname[1]);
                }

                if (contactId != 0)
                {
                    SQLCommand.Parameters.AddWithValue("@ContactID", contactId);
                }

                MessageBox.Show(SQLCommand.CommandText);

                using (SQLiteDataAdapter daContacts = new SQLiteDataAdapter(SQLCommand))
                {
                    try
                    {
                        daContacts.Fill(Contacts);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + SQLCommand);
                    }
                    dbConnection.Close();
                    return Contacts;
                }

            }
        }

        //=====================================================================================================================================================================
        public bool CreateOrUpdateContact(List<string> contactDetails, int ID = 0)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
                {
                    dbConnection.Open();
                    string SQL = null;

                    if (ID == 0)
                    {
                        SQL = "INSERT INTO `contacts`" +
                            "(`name`, `surename`, `gender`, `birthdate`, `street`, `zipcode`, `city`, `country`, `phone`, `mobile`, `email`, `notes`)" +
                            "VALUES" +
                            "(@Name, @SureName, @Gender, @BirthDate, @Street, @ZipCode, @City, @Country, @Phone, @Mobile, @email, @Notes);";
                        //SQLCommand = new SQLiteCommand(SQL, dbConnection);

                    }
                    else
                    {
                        SQL = "UPDATE `contacts`" +
                            "SET" +
                            " `name` = @Name, `surename` = @SureName, `gender` = @Gender, `birthdate` = @BirthDate, `street` = @Street, `zipcode` = @ZipCode, `city` = @City, `country` = @Country, `phone` = @Phone, `mobile` = @Mobile, `email` = @email, `notes` = @Notes WHERE `id` = @ID ;";
                        //SQLCommand = new SQLiteCommand(SQL, dbConnection);
                            
                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@Name", contactDetails[0]);
                        command.Parameters.AddWithValue("@SureName", contactDetails[1]);
                        command.Parameters.AddWithValue("@Gender", contactDetails[2]);
                        command.Parameters.AddWithValue("@BirthDate", contactDetails[3]);
                        command.Parameters.AddWithValue("@Street", contactDetails[4]);
                        command.Parameters.AddWithValue("@ZipCode", contactDetails[5]);
                        command.Parameters.AddWithValue("@City", contactDetails[6]);
                        command.Parameters.AddWithValue("@Country", contactDetails[7]);
                        command.Parameters.AddWithValue("@Phone", contactDetails[8]);
                        command.Parameters.AddWithValue("@Mobile", contactDetails[9]);
                        command.Parameters.AddWithValue("@email", contactDetails[10]);
                        command.Parameters.AddWithValue("@Notes", contactDetails[11]);
                        command.Parameters.AddWithValue("@ID", ID);

                        try
                        {
                            command.ExecuteNonQuery();
                            dbConnection.Close();
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
        public bool DeleteContact(string[] names = null, int id = 0)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
                {
                    dbConnection.Open();
                    string SQL = null;
                    //SQLiteCommand SQLCommand = new SQLiteCommand();

                    if (names == null && id == 0)
                    {
                        MessageBox.Show("Can't delete \"nothing\"");

                        return false;
                    }
                    else if (names != null && id == 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = @Name AND `surename` = @SureName";                        
                    }
                    else if (names == null && id != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE id = @ID";
                    }
                    else if (names != null && id != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = @Name AND `surename` = @SureName AND `id` = @ID";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                    {
                        command.Parameters.AddWithValue("@Name", names[0]);
                        command.Parameters.AddWithValue("@SureName", names[1]);
                        command.Parameters.AddWithValue("@ID", id);

                        try
                        {
                            command.ExecuteNonQuery();
                            dbConnection.Close();
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
        public int SwapCount()
        {
            int _rowCounter = 0;

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
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
                        return _rowCounter;
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        public DataTable GetSwapListDetails(string content, string[] contactname = null)
        {
            DataTable SwapListDetails = new DataTable();

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
            {
                dbConnection.Open();

                string SQL = null;
                SQLiteCommand SQLCommand = new SQLiteCommand();

                if (content == "parents")
                {
                    SQL =
                        "SELECT contacts.name, contacts.surename FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id GROUP BY contacts.name, contacts.surename";
                    SQLCommand = new SQLiteCommand(SQL, dbConnection);
                }
                else if (content == "childs")
                {
                    SQL =
                        "SELECT swaplist.date, swaplist.swapstatus, swaplist.tracking_code_out FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id WHERE contacts.name = @ContactName AND contacts.surename = @ContactSureName";
                    SQLCommand = new SQLiteCommand(SQL, dbConnection);
                    SQLCommand.Parameters.AddWithValue("@ContactName", contactname[0]);
                    SQLCommand.Parameters.AddWithValue("@ContactSureName", contactname[1]);
                }

                using (SQLiteDataAdapter daSwaps = new SQLiteDataAdapter(SQL, dbConnection))
                {
                    daSwaps.Fill(SwapListDetails);

                    return SwapListDetails;
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