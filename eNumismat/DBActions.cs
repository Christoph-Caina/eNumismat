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

                switch(content)
                {
                    case "parents":
                        SQL = "SELECT count(name), substr(name, 1, 1) FROM contacts GROUP by substr(name, 1, 1)";
                        break;

                    case "childs":
                        SQL = "SELECT name, surename, gender FROM contacts WHERE name LIKE '" + FirstLetter + "%' ORDER BY surename ASC";
                        break;

                    case "details":

                        if (contactname == null && contactId == 0)
                        {
                            SQL = "SELECT * FROM contacts ORDER BY name, surename LIMIT 1";
                        }
                        else if (contactname != null && contactId == 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = '" + contactname[0] + "' AND `surename` = '" + contactname[1] + "' LIMIT 1";
                        }
                        else if (contactname == null && contactId != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE id = '" + contactId + "'";
                        }
                        else if (contactname != null && contactId != 0)
                        {
                            SQL = "SELECT * FROM contacts WHERE `name` = '" + contactname[0] + "' AND `surename` = '" + contactname[1] + "' AND `id` = '" + contactId + "' LIMIT 1";
                        }

                        break;
                }

                //MessageBox.Show(SQL);

                using (SQLiteDataAdapter daContacts = new SQLiteDataAdapter(SQL, dbConnection))
                {
                    daContacts.Fill(Contacts);

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
                            "('"+ contactDetails[0] + "', '" + contactDetails[1] + "', '" + contactDetails[2] + "', '" + contactDetails[3] + "', '" + contactDetails[4] + "', '" + contactDetails[5] + "', '" + contactDetails[6] + "', '" + contactDetails[7] + "', '" + contactDetails[8] + "', '" + contactDetails[9] + "', '" + contactDetails[10] + "', '" + contactDetails[11] + "');";
                    }
                    else
                    {
                        SQL = "UPDATE `contacts`" +
                            "SET" +
                            " `name` = '" + contactDetails[0] + "', `surename` = '" + contactDetails[1] + "', `gender` = '" + contactDetails[2] + "', `birthdate` = '" + contactDetails[3] + "', `street` = '" + contactDetails[4] + "', `zipcode` = '" + contactDetails[5] + "', `city` = '" + contactDetails[6] + "', `country` = '" + contactDetails[7] + "', `phone` = '" + contactDetails[8] + "', `mobile` = '" + contactDetails[9] + "', `email` = '" + contactDetails[10] + "', `notes` = '" + contactDetails[11] + "' WHERE `id` = " + ID + " ;";

                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
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
        public bool DeleteContact(string[] names = null, int id = 0)
        {
            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
                {
                    dbConnection.Open();
                    string SQL = null;

                    if (names == null && id == 0)
                    {
                        MessageBox.Show("Can't delete \"nothing\"");

                        return false;
                    }
                    else if (names != null && id == 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = '" + names[0] + "' AND `surename` = '" + names[1] + "'";
                    }
                    else if (names == null && id != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE id = " + id + "";
                    }
                    else if (names != null && id != 0)
                    {
                        SQL = "DELETE FROM contacts WHERE `name` = '" + names[0] + "' AND `surename` = '" + names[1] + "' AND `id` = " + id + "";
                    }

                    using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
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

                if (content == "parents")
                {
                    SQL =
                        "SELECT contacts.name, contacts.surename FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id GROUP BY contacts.name, contacts.surename";
                }
                else if (content == "childs")
                {
                    SQL =
                        "SELECT swaplist.date, swaplist.swapstatus, swaplist.tracking_code_out FROM swaplist LEFT JOIN contacts ON contacts.id = swaplist.contacts_id WHERE contacts.name = '" + contactname[0] + "' AND contacts.surename = '" + contactname[1] + "'";
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