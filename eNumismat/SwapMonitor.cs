using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace eNumismat
{
    public partial class SwapMonitor : Form
    {
        DBActions dbAction;

        //=====================================================================================================================================================================
        public SwapMonitor()
        {
            InitializeComponent();
        }

        //=====================================================================================================================================================================
        private void SwapMonitor_Load(object sender, EventArgs e)
        {
            GetSwapCount();
            // Get all Swaps from SwapList...
            // TreeView:
                // Show: Contact
                    // Swap #
        }

        //=====================================================================================================================================================================
        private void GetSwapCount()
        {
            dbAction = new DBActions();

            treeView1.Nodes.Clear();

            int SwapCounter = dbAction.SwapCount();

            if (SwapCounter == 0)
            {
                toolStripStatusLabel1.Text = SwapCounter.ToString() + " Swaps vorhanden";
                //BuildFrm("edit");
            }
            else if (SwapCounter == 1)
            {
                toolStripStatusLabel1.Text = SwapCounter.ToString() + " Swap vorhanden";
                LoadTreeViewParents();
                //BuildFrm("view");
            }
            else
            {
                toolStripStatusLabel1.Text = SwapCounter.ToString() + " Swaps vorhanden";
                LoadTreeViewParents();
                //BuildFrm("view");
            }
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewParents()
        {
            TreeNode parents = null;

            int i = 0;
            foreach (DataRow drParents in dbAction.GetSwapListDetails("parents").Rows)
            {
                //MessageBox.Show(drParents[i].ToString());

                //i++;
                parents = treeView1.Nodes.Add(drParents[0].ToString() + ", " + drParents[1]);
                LoadTreeViewChilds(parents);

                //_unselectableNodes.Add(parents);
            }
            treeView1.ExpandAll();
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewChilds(TreeNode parentNode)
        {
            TreeNode childs;

            //MessageBox.Show(parentNode.ToString());

            string[] names = Regex.Split(parentNode.ToString().Remove(0, 10), ", ");
            //string[] Nodes = parentNode.ToString().Split(' ');

            int i = 0;
            foreach (DataRow drChilds in dbAction.GetSwapListDetails("childs", names).Rows)
            {
                MessageBox.Show(drChilds[i].ToString());

                i++;

                string ChildNode = drChilds[0].ToString() + ", " + drChilds[1] + ", " + drChilds[2];

            childs = parentNode.Nodes.Add(ChildNode);
            }
        }
    }
}
