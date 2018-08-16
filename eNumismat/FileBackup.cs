using System;
using System.Data.SQLite;

namespace eNumismat
{
    class FileBackup
    {
        public bool RunBackup()
        {
            using (var source = new SQLiteConnection("Data Source=" + Globals.FileBrowserInitDir + @"\" + Globals.DBFile))
            {
                using (var destination = new SQLiteConnection("Data Source=" + Globals.AppDataPath + @"\DBBackUps\" + DateTime.Now.ToString("yyyy_MM_dd-HH:mm") + ".encBack"))
                {
                    try
                    {
                        source.Open();
                        destination.Open();
                        source.BackupDatabase(destination, "main", "main", -1, null, 0);
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }

                    return true;
                }
            }
            return true;
        }
    }
} 