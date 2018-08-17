using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
//using Outlook = Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        private List<TreeNode> _unselectableNodes = new List<TreeNode>();
        
        int ContactID = 0;

        DBActions dbAction = new DBActions();
        ResourceManager res_man;

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();

            res_man = new ResourceManager(Assembly.GetCallingAssembly().EntryPoint.DeclaringType.Namespace.ToString() + "." + CultureInfo.CurrentUICulture.ThreeLetterISOLanguageName, Assembly.GetExecutingAssembly());

            adressenToolStripMenuItem.Text = res_man.GetString("_addrBook");
            neuToolStripMenuItem.Text = res_man.GetString("_newContact");

            tabPage1.Text = res_man.GetString("_addr_tab_contactDetails");
            tabPage2.Text = res_man.GetString("_addr_tab_swaps");

            label1.Text = res_man.GetString("_addr_Name") + ":";
            label2.Text = res_man.GetString("_addr_SureName") + ":";
            label3.Text = res_man.GetString("_addr_gender") + ":";
            label4.Text = res_man.GetString("_addr_birthdate") + ":";
            label5.Text = res_man.GetString("_addr_street") + " / " + res_man.GetString("_addr_hnumber") + ":";
            label6.Text = res_man.GetString("_addr_zipCode") + ":";
            label7.Text = res_man.GetString("_addr_city") + ":";
            label8.Text = res_man.GetString("_addr_country") + ":";
            label9.Text = res_man.GetString("_addr_phone") + ":";
            label10.Text = res_man.GetString("_addr_mobile") + ":";
            label11.Text = res_man.GetString("_addr_mail") + ":";
            label12.Text = res_man.GetString("_addr_notes") + ":";

            label13.Text = res_man.GetString("_addr_mail") + ":";
            label14.Text = res_man.GetString("_addr_street") + " / " + res_man.GetString("_addr_hnumber") + ":";
            label15.Text = res_man.GetString("_addr_birthdate") + ":";
            label16.Text = res_man.GetString("_addr_mobile") + ":";
            label17.Text = res_man.GetString("_addr_zipCode") + " / " + res_man.GetString("_addr_city") + ":";
            label18.Text = res_man.GetString("_addr_phone") + ":";
            label19.Text = res_man.GetString("_addr_country") + ":";
            label20.Text = res_man.GetString("_addr_notes") + ":";
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            GenerateAdrBookForm();
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
                LoadContactMain("view", ContactName, ContactId);
            }
            else if (ContactCounter > 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " Kontakte vorhanden";
                LoadContactMain("view", ContactName, ContactId);
            }

            LoadTreeViewParents();
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

            if (ContactName == null && ContactId == 0)
            {
                _ContactDetails = dbAction.GetContacts("details");
            }
            else if (ContactName != null && ContactId == 0)
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
            
            while(i < DataTableCounter)
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

                if(Type == "edit" && ContactDetails.Count != 0)
                {
                    ContactID = Convert.ToInt32(ContactDetails[0]);

                    tb_name.Text = ContactDetails[1];
                    tb_surename.Text = ContactDetails[2];
                    cb_gender.Text = ContactDetails[3];
                    dtp_birthdate.Text = ContactDetails[4];
                    tb_street.Text = ContactDetails[5];
                    tb_zipcode.Text = ContactDetails[6];
                    tb_city.Text = ContactDetails[7];
                    tb_country.Text = ContactDetails[8];
                    tb_phone.Text = ContactDetails[9];
                    tb_mobile.Text = ContactDetails[10];
                    tb_mail.Text = ContactDetails[11];
                    rtb_notes.Text = ContactDetails[12];
                }
                else
                {
                    tb_name.Text = null;
                    tb_surename.Text = null;
                    cb_gender.Text = null;
                    dtp_birthdate.Text = DateTime.Now.ToString();
                    tb_street.Text = null;
                    tb_zipcode.Text = null;
                    tb_city.Text = null;
                    tb_country.Text = null;
                    tb_phone.Text = null;
                    tb_mobile.Text = null;
                    tb_mail.Text = null;
                    rtb_notes.Text = null;
                }

                Btn_CreateContact.Enabled = false;
                Btn_DeleteContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;

            }
            else if (Type == "view")
            {
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);
                PanelShowContactDetails.Dock = DockStyle.Fill;

                if (ContactDetails.Count != 0)
                {
                    ContactID = Convert.ToInt32(ContactDetails[0]);

                    label_name.Text = ContactDetails[1];
                    label_surename.Text = ContactDetails[2];
                    label_birthdate.Text = ContactDetails[4];
                    label_street.Text = ContactDetails[5];
                    label_zip.Text = ContactDetails[6];
                    label_city.Text = ContactDetails[7];
                    label_country.Text = ContactDetails[8];
                    label_phone.Text = ContactDetails[9];
                    label_mobile.Text = ContactDetails[10];
                    label_mail.Text = ContactDetails[11];
                    rtb_notesDisplay.Text = ContactDetails[12];

                    if (ContactDetails[3] == "male")
                    {
                        pb_gender.BackgroundImage = Properties.Resources.male;
                    }
                    else if (ContactDetails[3] == "female")
                    {
                        pb_gender.BackgroundImage = Properties.Resources.female;
                    }   
                }
                Btn_CreateContact.Enabled = true;
                Btn_UpdateContact.Enabled = true;
                Btn_DeleteContact.Enabled = true;
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

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void Btn_UpdateContact_Click(object sender, EventArgs e)
        {
            LoadContactMain("edit", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {
            if (dbAction.DeleteContact(null, ContactID))
            {
                GenerateAdrBookForm();
            }
        }

        //=====================================================================================================================================================================
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            List<string> DBContactDetails = new List<string>
            {
                tb_name.Text,
                tb_surename.Text,
                cb_gender.Text,
                dtp_birthdate.Text,
                tb_street.Text,
                tb_zipcode.Text,
                tb_city.Text,
                tb_country.Text,
                tb_phone.Text,
                tb_mobile.Text,
                tb_mail.Text,
                rtb_notes.Text
            };

            string[] names = { tb_name.Text, tb_surename.Text };

            if (ValidateTextInputs() == true)
            {
                if (dbAction.CreateOrUpdateContact(DBContactDetails, ContactID))
                {
                    GenerateAdrBookForm(names, ContactID);
                }
            }
        }

        //=====================================================================================================================================================================
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            LoadContactMain("view", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void TbName_TextChanged(object sender, EventArgs e)
        {
            tb_name.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private void TbSurename_TextChanged(object sender, EventArgs e)
        {
            tb_surename.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private bool ValidateTextInputs()
        {
            if (String.IsNullOrEmpty(tb_name.Text))
            {
                MessageBox.Show("Der Name darf nicht leer sein!");
                tb_name.BackColor = Color.MistyRose;
                tb_name.Select();
                return false;
            }

            if (String.IsNullOrEmpty(tb_surename.Text))
            {
                MessageBox.Show("Der Vorname darf nicht leer sein!");
                tb_surename.BackColor = Color.MistyRose;
                tb_surename.Select();
                return false;
            }
            return true;
        }

        //
        //=====================================================================================================================================================================
        //=====================================================================================================================================================================
        //

        // Outlook-Test
        //=====================================================================================================================================================================
        /*private void MicrosoftOutlookToolStripMenuItem_Click(object sender, EventArgs e)
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
        }*/
    }
}
