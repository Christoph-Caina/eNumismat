using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

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
            if (Globals.UICulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Globals.UICulture);
                this.Controls.Clear();
                this.InitializeComponent();
            }

            GetSwapCount();
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
            }
            else if (SwapCounter == 1)
            {
                toolStripStatusLabel1.Text = SwapCounter.ToString() + " Swap vorhanden";
                LoadTreeViewParents();
            }
            else
            {
                toolStripStatusLabel1.Text = SwapCounter.ToString() + " Swaps vorhanden";
                LoadTreeViewParents();
            }
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewParents()
        {
            TreeNode parents = null;

            foreach (DataRow drParents in dbAction.GetSwapListDetails("parents").Rows)
            {
                parents = treeView1.Nodes.Add(drParents[0].ToString() + ", " + drParents[1]);
                LoadTreeViewChilds(parents);

                _unselectableNodes.Add(parents);
            }
            treeView1.ExpandAll();
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewChilds(TreeNode parentNode)
        {
            TreeNode childs;
           
            string[] names = Regex.Split(parentNode.ToString().Remove(0, 10), ", ");

            int i = 0;
            foreach (DataRow drChilds in dbAction.GetSwapListDetails("childs", names).Rows)
            {
                MessageBox.Show(drChilds[i].ToString());

                i++;

                string ChildNode = drChilds[0].ToString() + ", " + drChilds[1] + ", " + drChilds[2];

            childs = parentNode.Nodes.Add(ChildNode);
            }
        }

        //=====================================================================================================================================================================
        private List<TreeNode> _unselectableNodes = new List<TreeNode>();

        //=====================================================================================================================================================================
        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_unselectableNodes.Contains(e.Node))
            {
                e.Cancel = true;
            }
        }

        //=====================================================================================================================================================================
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
