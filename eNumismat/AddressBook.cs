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
            Globals.AddressBookFormMode = null;
            //Btn_Cancel.Enabled = false;
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            GetContactsCount();
        }

        //=====================================================================================================================================================================
        private void AddressBook_Show(object sender, EventArgs e)
        {
            GetContactsCount();
        }

        //=====================================================================================================================================================================
        private void GetContactsCount()
        {
            dbAction = new DBActions();
            int ContactCounter = dbAction.ContactsCount();
            DrawForm(ContactCounter);
        }

        //=====================================================================================================================================================================
        private void DrawForm(int ContactsCount)
        {
            if (ContactsCount == 0)
            {
                toolStripStatusLabel1.Text = ContactsCount.ToString() + " Kontakte vorhanden";
                Globals.AddressBookFormMode = "create";

                Btn_Cancel.Enabled = false;
            }

            else if (ContactsCount == 1)
            {
                toolStripStatusLabel1.Text = ContactsCount.ToString() + " Kontakt vorhanden";
                Globals.AddressBookFormMode = "show";

                Btn_Cancel.Enabled = true;
            }

            else
            {
                toolStripStatusLabel1.Text = ContactsCount.ToString() + " Kontakte vorhanden";
                Globals.AddressBookFormMode = "show";

                Btn_Cancel.Enabled = true;
            }


            if (Globals.AddressBookFormMode == "show")
            {
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);

                PanelShowContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = true;
                Btn_CreateContact.Enabled = true;

                LoadTreeViewParents();
                GetContact();
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);

                PanelEditContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = false;
                Btn_CreateContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;

                LoadTreeViewParents();
            }

            else if (Globals.AddressBookFormMode == "create")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);

                PanelEditContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = false;
                Btn_CreateContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;
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
            Btn_UpdateContact.Enabled = true;

            GetContact(names);
        }

        //=====================================================================================================================================================================
        private void GetContact(string[] contact = null)
        {
            if (Globals.AddressBookFormMode == "show")
            {
                foreach (DataRow drContactDetails in dbAction.GetContacts("details", null, contact).Rows)
                {
                    label_ID.Text = drContactDetails[0].ToString();
                    label_name.Text = drContactDetails[1].ToString();
                    label_surename.Text = drContactDetails[2].ToString();

                }
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                foreach (DataRow drContactDetails in dbAction.GetContacts("details", null, contact).Rows)
                {
                    tb_name.Text = drContactDetails[1].ToString();
                    tb_surename.Text = drContactDetails[2].ToString();
                    cb_gender.Text = drContactDetails[3].ToString();

                    if (String.IsNullOrEmpty(drContactDetails[4].ToString()))
                    {
                        dtp_birthdate.Text = DateTime.Now.ToString("dd.MM.yyyy");
                    }
                    else
                    {
                        dtp_birthdate.Text = drContactDetails[4].ToString();
                    }
                }
            }
        }

        //=====================================================================================================================================================================
        private void SetContact()
        {
            if (Globals.AddressBookFormMode == "create")
            {
                MessageBox.Show("INSERT INTO");
                /*if (dbAction.CreateContact())
                {
					ID of shown CONTACT
                    GetContactsCount();
                }*/
            }

            else if (Globals.AddressBookFormMode == "update")
            {
                MessageBox.Show("UPDATE");
                /*if (dbAction.UpdateContact())
                {
					ID of shown CONTACT
                    GetContactsCount();
                }*/
            }

            Globals.AddressBookFormMode = "show";
        }

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            // DO Work
        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {
            // DO Work
        }

        //=====================================================================================================================================================================
        private void Btn_EditContact_Click(object sender, EventArgs e)
        {
            // DO Work
        }

        //=====================================================================================================================================================================
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            // DO Work
        }

        //=====================================================================================================================================================================
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SetContact();
        }

        //=====================================================================================================================================================================
        private void AddressBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            Globals.AddressBookFormMode = null;
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
    }
}
