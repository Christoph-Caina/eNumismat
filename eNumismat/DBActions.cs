using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;


namespace eNumismat
{
    class DBActions
    {
        public bool CreateNew()
        {
            // Include SQLite and Create Database File (DBFile)
            // Create empty DB File with all Tables, and some Data...

            try
            {
                using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + Globals.DBFile))
                {
                    dbConnection.Open();

                    string _sqlStatement = Properties.Resources.CreateTables.ToString();

                    MessageBox.Show(_sqlStatement);

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
                            //dLog.Write("[8]", ex.Message);
                            //MessageBox.Show(ex.Message);
                            dbConnection.Close();
                            dbConnection.Dispose();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //dLog.Write("[8]", ex.Message);
                //MessageBox.Show(ex.Message);

                return false;
            }
        }
    }
}
