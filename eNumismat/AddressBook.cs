using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        DBActions dbAction;

        //=============================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=============================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            GetContactsCount();
        }

        //=====================================================================================================================================================================
        private void GetContactsCount()
        {
            dbAction = new DBActions();

            treeView1.Nodes.Clear();

            //dbAction.CounterContacts();
            int ContactCounter = dbAction.CounterContacts();

            if (ContactCounter == 0)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                //BuildFrm("edit");
            }
            else if (ContactCounter == 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakt vorhanden";
                LoadTreeViewParents();
                //BuildFrm("view");
            }
            else
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                LoadTreeViewParents();
                //BuildFrm("view");
            }
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewParents()
        {
            TreeNode parents = null;

            foreach (DataRow drParents in dbAction.GetContacts("parents").Rows)
            {
                parents = treeView1.Nodes.Add(drParents[1].ToString() + " [" + drParents[0] + "]");
                LoadTreeViewChilds(parents);

                _unselectableNodes.Add(parents);
            }
            treeView1.ExpandAll();
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewChilds(TreeNode parentNode)
        {
            TreeNode childs;

            string[] Nodes = parentNode.ToString().Split(' ');

            foreach (DataRow drChilds in dbAction.GetContacts("childs", Nodes[1]).Rows)
            {
                string ChildNode = drChilds[0] + ", " + drChilds[1];

                int ImageIndex = 0;
                
                switch (drChilds[2])
                {
                    case "male":
                        ImageIndex = 2;
                        break;

                    case "female":
                        ImageIndex = 1;
                        break;
                }

                childs = parentNode.Nodes.Add(null, ChildNode, ImageIndex, ImageIndex);
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
            //btn_contact_delete.Enabled = true;
            //löschenToolStripMenuItem.Enabled = true;
            //btn_contact_edit.Enabled = true;
            //bearbeitenToolStripMenuItem.Enabled = true;

            //CreateFormElements("view", treeView1.SelectedNode.ToString());
            // ACTION AFTER NODE SELECT
        }

        // Outlook-Test
        //=============================================================================================================
        private void MicrosoftOutlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Outlook._Application outlookObj = new Outlook.Application();

            Outlook.MAPIFolder fldContacts =
            (Outlook.MAPIFolder)outlookObj.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            Outlook.ContactItem newContact = (Outlook.ContactItem)fldContacts.Items.Add(Outlook.OlItemType.olContactItem);

            newContact.FirstName = "Max";
            newContact.LastName = "Mustermann";
            newContact.Email1Address = "max.mustermann@test.de";

            newContact.Save();

            // Exportiert, bzw. speichert den hinterlegten Kontakt im Outlook Adressbuch ab :)
            // Funktioniert auch, wenn Outlook geschlossen ist.
            // eine Überprüfung, ob Outlook installiert ist - und vor allem, ob es auch mit anderen Versionen von Outlook kompatibel ist, wäre Sinnvoll.
            // ggf. "outlook" als art AddIn bereitstellen?
        }
    }
}
