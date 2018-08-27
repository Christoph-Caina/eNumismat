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
        public E_Numismat_main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DisplayLanguage(string method, string culture)
        {

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

        }

        private void ExchangeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
