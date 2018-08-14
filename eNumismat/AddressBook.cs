﻿using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        private List<TreeNode> _unselectableNodes = new List<TreeNode>();

        DBActions dbAction = new DBActions();

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            GenerateAdrBookForm();

            LoadTreeViewParents();
        }

        //=====================================================================================================================================================================
        private void GenerateAdrBookForm(string[] ContactName = null, int ContactId = 0)
        {
            int ContactCounter = GetContactsCount();

            if (ContactCounter == 0)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                LoadContactMain("new");
            }
            else if (ContactCounter == 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakt vorhanden";
                LoadContactMain("view");
            }
            else if (ContactCounter > 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                LoadContactMain("view");
            }
        }

        //=====================================================================================================================================================================
        private int GetContactsCount()
        {
            return dbAction.ContactsCount();
        }

        //=====================================================================================================================================================================
        private void LoadContactMain(string Type, string[] ContactName = null, int ContactId = 0)
        {
            DataTable _ContactDetails = new DataTable();
            List<string> ContactDetails = new List<string>();

            if (ContactName != null && ContactId == 0)
            {
                _ContactDetails = dbAction.GetContacts("details", null, ContactName);
            }
            else if (ContactName == null && ContactId != 0)
            {
                _ContactDetails = dbAction.GetContacts("details", null, null, ContactId);
            }
            else if (ContactName != null && ContactId != 0)
            {
                _ContactDetails = dbAction.GetContacts("details", null, ContactName, ContactId);
            }

            int DataTableCounter = _ContactDetails.Columns.Count;
            int i = 0;
            MessageBox.Show(DataTableCounter.ToString());

            while(i <= DataTableCounter)
            {
                foreach (DataRow drDetails in _ContactDetails.Rows)
                {
                    ContactDetails.Add(drDetails[i].ToString());
                }

                i++;
            }

            if (Type == "new" || Type == "edit")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);
                PanelEditContactDetails.Dock = DockStyle.Fill;

                if(Type == "edit")
                {
                    

                }
            }
            else if (Type == "view")
            {
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);
                PanelShowContactDetails.Dock = DockStyle.Fill;

                
            }
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewParents()
        {
            treeView1.Nodes.Clear();
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

                int ImageIndex;

                switch (drChilds[2])
                {
                    case "male":
                        ImageIndex = 1;
                        break;

                    case "female":
                        ImageIndex = 2;
                        break;

                    default:
                        ImageIndex = 3;
                        break;
                }

                childs = parentNode.Nodes.Add(null, ChildNode, ImageIndex, ImageIndex);
            }
        }

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
            string[] names = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");
            LoadContactMain("view", names);
        }


        //
        //=====================================================================================================================================================================
        //=====================================================================================================================================================================
        //

        // Outlook-Test
        //=====================================================================================================================================================================
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
