using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace eNumismat
{
    class Localization
    {
        ResourceManager res_man;

        private void localization()
        {
            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());

            //localization

            /*
            dateiToolStripMenuItem.Text = res_man.GetString("_file");
            frm1.neueDatenbankToolStripMenuItem.Text = res_man.GetString("_createNewDataBase");
            frm1.datenbankÖffnenToolStripMenuItem.Text = res_man.GetString("_openExistingDataBase");
            datenbankSichernToolStripMenuItem.Text = res_man.GetString("_backupDataBase");
            datenbankKomprimierenToolStripMenuItem.Text = res_man.GetString("_compressDataBase");
            beendenToolStripMenuItem.Text = res_man.GetString("_exitApplication");
            */
        }
    }
}
