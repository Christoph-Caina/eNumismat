using System;
using System.Data;
using System.Data.SQLite;


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

                    string _sqlStatement = Properties.Resources.CreateTables.ToString();

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
        //private int _rowCounter;
        //public int RowCounter
        //{
        //    get { return this._rowCounter; }
        //    set { this._rowCounter = value; }
        //}

        //=====================================================================================================================================================================
        public int CounterContacts()
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
                    //dLog.Write("[8]", ex.Message);
                    //MessageBox.Show(ex.Message);
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
        public DataTable GetContacts(string content, string FirstLetter = null)
        {
            DataTable Contacts = new DataTable();

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
            {
                dbConnection.Open();

                string SQL = null;

                if (content == "parents")
                {
                    SQL =
                        "SELECT substr(name, 1, 1) FROM contacts GROUP by substr(name, 1, 1)";
                }
                else if (content == "childs")
                {
                    SQL =
                        "SELECT name, surename, gender FROM contacts WHERE name LIKE '" + FirstLetter + "%' ORDER BY surename ASC";
                }

                using (SQLiteDataAdapter daParents = new SQLiteDataAdapter(SQL, dbConnection))
                {
                    daParents.Fill(Contacts);

                    return Contacts;
                }
            }
        }
    }
}
