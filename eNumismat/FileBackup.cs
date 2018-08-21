using System;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace eNumismat
{
    class FileBackup
    {
        //=====================================================================================================================================================================
        private bool CheckBackupDir()
        {
            if (Directory.Exists(Globals.AppDataPath + @"\DBBackUps\"))
            {
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(Globals.AppDataPath + @"\DBBackUps\");
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
        }

        //=====================================================================================================================================================================
        public bool ExcecuteBackup()
        {
            if (CheckBackupDir())
            {
                string SourceFile = Path.Combine(Globals.DBFilePath, Globals.DBFile);
                string DestFile = Path.Combine(Globals.AppDataPath, @"DBBackUps\" + DateTime.Now.ToString("yyyy_MM_dd-HHmmss") + ".encBack");

                using (var source = new SQLiteConnection("Data Source=" + SourceFile))
                {
                    using (var destination = new SQLiteConnection("Data Source=" + DestFile))
                    {
                        try
                        {
                            source.Open();

                            if (Globals.CompressDBBeforeBackup == true)
                            {
                                CompactDatabase(source);
                            }

                            destination.Open();

                            source.BackupDatabase(destination, "main", "main", -1, null, 0);

                            return true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        //=====================================================================================================================================================================
        public bool CompactDatabase(SQLiteConnection Database = null)
        {
            if (Database == null)
            {
                string SourceFile = Path.Combine(Globals.DBFilePath, Globals.DBFile);
                Database = new SQLiteConnection("DataSource=" + SourceFile);
            }

            using (SQLiteCommand cmd = Database.CreateCommand())
            {
                cmd.CommandText = "vacuum";
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
} 