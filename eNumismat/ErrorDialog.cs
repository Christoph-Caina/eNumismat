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
    public partial class ErrorDialog : Form
    {
        public string DialogTitle { get; set; }
        public string ErrText { get; set; }
        public string Btn1_Text { get; set; }
        public string Btn2_Text { get; set; }
        public string Btn3_Text { get; set; }
        //public Icon DialogIcon { get; set; }

        public ErrorDialog()
        {
            InitializeComponent();
        }

        private void ErrorDialog_Load(object sender, EventArgs e)
        {
            this.Text = DialogTitle;
            //this.Icon = DialogIcon;
            label1.Text = ErrText;

            button1.Text = Btn1_Text;
            button2.Text = Btn2_Text;
            button3.Text = Btn3_Text;
        }
    }
}
