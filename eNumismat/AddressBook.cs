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

        public int ContactID = 0;
        public string[] ContactNames = null;
        public string WindowMode = null;

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
                WindowMode = "create";

                Btn_Cancel.Enabled = false;
            }

            else if (ContactsCount == 1)
            {
                toolStripStatusLabel1.Text = ContactsCount.ToString() + " Kontakt vorhanden";
                WindowMode = "show";

                Btn_Cancel.Enabled = true;
            }

            else
            {
                toolStripStatusLabel1.Text = ContactsCount.ToString() + " Kontakte vorhanden";
                WindowMode = "show";

                Btn_Cancel.Enabled = true;
            }


            if (WindowMode == "show")
            {
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);

                PanelShowContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = true;
                Btn_CreateContact.Enabled = true;

                LoadTreeViewParents();
            }

            else if (WindowMode == "update")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);

                PanelEditContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = false;
                Btn_CreateContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;

                LoadTreeViewParents();
            }

            else if (WindowMode == "create")
            {
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);

                PanelEditContactDetails.Dock = DockStyle.Fill;

                treeView1.Enabled = false;
                Btn_CreateContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;
            }

            GetContact();
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
            ContactNames = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");

            Btn_DeleteContact.Enabled = true;
            Btn_UpdateContact.Enabled = true;

            GetContact(ContactNames);
        }

        //=====================================================================================================================================================================
        private void GetContact(string[] contact = null)
        {
            
        }

        //=====================================================================================================================================================================
        private void SetContact()
        {
            List<string> ContactDetails = new List<string>();

            ContactDetails.Add(tb_name.Text);
            ContactDetails.Add(tb_surename.Text);
            ContactDetails.Add(cb_gender.Text);
            ContactDetails.Add(dtp_birthdate.Text);
            ContactDetails.Add(tb_street.Text);
            ContactDetails.Add(tb_zipcode.Text);
            ContactDetails.Add(tb_city.Text);
            ContactDetails.Add(tb_country.Text);
            ContactDetails.Add(tb_phone.Text);
            ContactDetails.Add(tb_mobile.Text);
            ContactDetails.Add(tb_mail.Text);
            ContactDetails.Add(rtb_notes.Text);

            if (WindowMode == "create")
            {

                //MessageBox.Show("INSERT INTO");
                if (dbAction.CreateOrUpdateContact(ContactDetails))
                {
                    GetContactsCount();
                }
            }

            else if (WindowMode == "update")
            {
                //MessageBox.Show("UPDATE");
                if (dbAction.CreateOrUpdateContact(ContactDetails, ContactID))
                {
                    GetContactsCount();
                }
            }
            WindowsMode = "show";
        }

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {

        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {
            
        }

        //=====================================================================================================================================================================
        private void Btn_EditContact_Click(object sender, EventArgs e)
        {
            
        }

        //=====================================================================================================================================================================
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            
        }

        //=====================================================================================================================================================================
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            SetContact();
        }

        //=====================================================================================================================================================================
        private void AddressBook_FormClosed(object sender, FormClosedEventArgs e)
        {
            WindowMode = null;
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
