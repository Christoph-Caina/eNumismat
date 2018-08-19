using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace eNumismat
{
    public partial class About : Form
    {
        ResourceManager res_man;

        public About()
        {
            InitializeComponent();

            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());
        }

        private void About_Load(object sender, EventArgs e)
        {

        }
    }
}
