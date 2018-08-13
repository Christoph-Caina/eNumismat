using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNumismat
{
    public partial class DocBrowser : Form
    {
        public DocBrowser()
        {
            InitializeComponent();
        }

        private void DocBrowser_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Properties.Resources.Unicode_Currencies);
        }
    }
}
