using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        DBActions dbAction;

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            GetContactsCount();
        }

        //=====================================================================================================================================================================
        private void AddressBook_Show(object sender, EventArgs e)
        {
            DrawForm();
        }

        //=====================================================================================================================================================================
        private void GetContactsCount()
        {
            dbAction = new DBActions();

            treeView1.Nodes.Clear();

            int ContactCounter = dbAction.ContactsCount();

            if (ContactCounter == 0)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";

                if (String.IsNullOrEmpty(Globals.AddressBookFormMode))
                {
                    Globals.AddressBookFormMode = "create";
                }
            }
            else if (ContactCounter == 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakt vorhanden";
                LoadTreeViewParents();

                if (String.IsNullOrEmpty(Globals.AddressBookFormMode))
                {
                    Globals.AddressBookFormMode = "show";
                }

                //GetContact();
                //BuildFrm("view");
            }
            else
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                LoadTreeViewParents();

                if (String.IsNullOrEmpty(Globals.AddressBookFormMode))
                {
                    Globals.AddressBookFormMode = "show";
                }

                //GetContact();
                //BuildFrm("view");
            }

            DrawForm();

            //MessageBox.Show(Globals.AddressBookFormMode);
        }

        //=====================================================================================================================================================================
        private void DrawForm()
        {
            if (Globals.AddressBookFormMode == "create")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);
                PanelEditContactDetails.Dock = DockStyle.Fill;
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);
                PanelEditContactDetails.Dock = DockStyle.Fill;

                GetContact();
            }

            else if (Globals.AddressBookFormMode == "show")
            {
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);
                PanelShowContactDetails.Dock = DockStyle.Fill;

                GetContact();
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
            string[] names = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");

            Btn_DeleteContact.Enabled = true;
            Btn_EditContact.Enabled = true;

            GetContact(names);
        }

        //=====================================================================================================================================================================
        private void GetContact(string[] contact = null)
        {
            if (Globals.AddressBookFormMode == "show")
            {
                foreach (DataRow drContactDetails in dbAction.GetContacts("details", null, contact).Rows)
                {
                    label_name.Text = drContactDetails[1].ToString();
                    label_surename.Text = drContactDetails[2].ToString();
                }
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                foreach (DataRow drContactDetails in dbAction.GetContacts("details", null, contact).Rows)
                {
                    // FILL TEXTBOX WITH VALUES...
                    SetContact();
                }
            }
        }

        //=====================================================================================================================================================================
        private void SetContact()
        {
            if (Globals.AddressBookFormMode == "create")
            {
                // SET BUTTON SAVE = INSERT INTO
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                // SET BUTTON SAVE = UPDATE
            }

            Globals.AddressBookFormMode = "show";
        }

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

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            Globals.AddressBookFormMode = "create";
            GetContactsCount();
        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {

        }

        //=====================================================================================================================================================================
        private void Btn_EditContact_Click(object sender, EventArgs e)
        {

        }
    }
}
