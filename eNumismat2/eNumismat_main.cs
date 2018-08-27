using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eNumismat2
{
    public partial class E_Numismat_main : Form
    {
        bool MinimizeToTray = true;

        public E_Numismat_main()
        {
            InitializeComponent();
            TrayIcon.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //kryptonDateTimePicker1.Value
        }

        private void DisplayLanguage(string method, string culture)
        {
            // Do Work for language Selection >> use Classes/Languages.cs ?
        }

        private void Tray(string method)
        {
            if (method == "resize")
            {
                if (MinimizeToTray == true)
                {
                    if (WindowState == FormWindowState.Minimized)
                    {
                        Show();
                        WindowState = FormWindowState.Normal;
                    }
                    else if (WindowState == FormWindowState.Normal)
                    {
                        Hide();
                        WindowState = FormWindowState.Minimized;
                    }
                }
            }
            else if (method == "minimize")
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    Hide();
                    WindowState = FormWindowState.Minimized;
                }
            }

            
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "en-US");
        }

        private void GermanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "de-DE");
        }

        private void FrenshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "fr-FR");
        }

        private void SpanishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "es-ES");
        }

        private void PortugueseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "pt-PT");
        }

        private void RussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "ru-RU");
        }

        private void PolishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayLanguage("set", "po-PO");
        }

        private void NewDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void OpenDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BackupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CompressDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddressBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eNumismat_addressBook_main adrBook = new eNumismat_addressBook_main();
            adrBook.Show();
        }

        private void ExchangeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void E_Numismat_main_Resize(object sender, EventArgs e)
        {
            Tray("minimize");
        }

        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Tray("resize");
        }

        private void kryptonRibbonGroupButton1_Click(object sender, EventArgs e)
        {
            eNumismat_addressBook_main adrBook = new eNumismat_addressBook_main();
            adrBook.Show();
        }
    }
}
