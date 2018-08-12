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
            //using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + globals.DbFile))
            //{
                //dbConnection.Open();

                //string SQL =
                    //"SELECT substr(name, 1, 1) FROM contacts GROUP by substr(name, 1, 1)";

                //using (SQLiteDataAdapter daParents = new SQLiteDataAdapter(SQL, dbConnection))
                //{
                    //DataTable dtParents = new DataTable();

                    //daParents.Fill(dtParents);

                    //TreeNode parentNode = null;

                    //foreach (DataRow drParents in dtParents.Rows)
                    //{
                        // Parent Nodes in TreeView
                        //parentNode = treeView1.Nodes.Add(drParents[0].ToString());
                        //LoadTreeViewChilds(parentNode);

                        //_unselectableNodes.Add(parentNode);
                    //}
                    //treeView1.ExpandAll();
                //}
                //dbConnection.Close();
            //}
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewChilds(TreeNode parentNode)
        {
            //using (SQLiteConnection dbConnection = new SQLiteConnection("Data Source=" + globals.DbFile))
            //{
                //dbConnection.Open();

                //string Nodes = parentNode.ToString().Remove(0, 10);

                //string SQL =
                    //"SELECT name, surename FROM contacts WHERE name LIKE '" + Nodes + "%'";

                //using (SQLiteDataAdapter daChilds = new SQLiteDataAdapter(SQL, dbConnection))
                //{
                    //DataTable dtChilds = new DataTable();

                    //daChilds.Fill(dtChilds);

                    //TreeNode childNode;

                    //foreach (DataRow drChilds in dtChilds.Rows)
                    //{
                        //string ChildNode = drChilds[0] + ", " + drChilds[1];
                        //childNode = parentNode.Nodes.Add(ChildNode);
                    //}
                //}
                //dbConnection.Close();
            //}
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

        //=============================================================================================================
        private void OutlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Outlook.MAPIFolder fldContacts =
            (Outlook.MAPIFolder)outlookObj.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts);

            foreach (Microsoft.Office.Interop.Outlook._ContactItem contactItem in fldContacts.Items)
            {
                contact = new MyContact();

                contact.FirstName = (contactItem.FirstName == null) ? string.Empty :

                                               contactItem.FirstName;

                contact.LastName = (contactItem.LastName == null) ? string.Empty :

                                              contactItem.LastName;

                contact.EmailAddress = contactItem.Email1Address;

                contact.Phone = contactItem.Business2TelephoneNumber;

                contact.Address = contactItem.BusinessAddress;

                contacts.Add(contact);

            }
            */
        }
    }
}
