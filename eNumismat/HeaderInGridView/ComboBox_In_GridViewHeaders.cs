using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

// Backup 

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        List<string> ColumnHeaders = new List<string>();

        public Form1()
        {
            InitializeComponent();
            // Create 2 test columns
            //dataGridView1.Columns.Add("Column1", "Column1");
            //dataGridView1.Columns.Add("Column2", "Column2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            GetColumnNamesFromDB();

            ComboBox comboBoxHeaderCell;


            for (int i = 0; i < 13; i++)
            {
                dataGridView1.Columns.Add("dgv1IDX_" + i.ToString(), "UserData" + i.ToString());
                //}

                //for (int i = 0; i < 5; i++)
                //{
            //}

            //for (int i = 0; i < 13; i++)
            //{ 
                comboBoxHeaderCell = new ComboBox();
                comboBoxHeaderCell.Name = "dgv1IDX_" + i.ToString();
                comboBoxHeaderCell.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxHeaderCell.Visible = true;

                //for (int y = 0; y < 10; y++)
                //{

                    //for (int y = 0; y < 5; y++)
                    //{
                    foreach (string Item in ColumnHeaders)
                    {
                        comboBoxHeaderCell.Items.Add(Item);
                    }
                    //comboBoxHeaderCell.Items.Add("Item" + y.ToString());
                    //}
                //}

                dataGridView1.Controls.Add(comboBoxHeaderCell);
                comboBoxHeaderCell.Location = this.dataGridView1.GetCellDisplayRectangle(i, -1, true).Location;
                comboBoxHeaderCell.Size = this.dataGridView1.Columns[i].HeaderCell.Size;
                comboBoxHeaderCell.SelectedIndexChanged += new EventHandler(comboBoxHeaderCell_SelectedIndexChanged);


                foreach (string Item in ColumnHeaders)
                {
                    comboBoxHeaderCell.Text = Item;
                }
            }
        }

        private void comboBoxHeaderCell_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (base.ActiveControl != null)
            {
                dataGridView1.Columns[base.ActiveControl.Name.ToString()].HeaderCell.Value = base.ActiveControl.Text;
                base.ActiveControl.Visible = false;
            }
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.Controls["dgv1IDX_" + e.ColumnIndex].Visible = true;
        }

        private void GetColumnNamesFromDB()
        {
            string GetDBFile = Path.Combine(@"C: \Users\Christoph.Caina\Documents", @"NewDatabaseStructure.enc");

            using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + GetDBFile))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                { }
                string SQL =
                    "PRAGMA table_info (`contacts`)";
                using (SQLiteCommand command = new SQLiteCommand(SQL, dbConnection))
                {
                    try
                    {
                        SQLiteDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader.GetString(1) != "id")
                            {
                                ColumnHeaders.Add(reader.GetString(1));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
