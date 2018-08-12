using System;
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
                        //dLog.Write("[8]", ex.Message);
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
