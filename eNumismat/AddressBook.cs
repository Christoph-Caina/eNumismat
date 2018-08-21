using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
//using Outlook = Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Threading;
using System.Globalization;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        private List<TreeNode> _unselectableNodes = new List<TreeNode>();
        private List<string> AutoFillCities = new List<string>();
        private List<string> AutoFillFederalStates = new List<string>();

        int ContactID = 0;

        DBActions dbAction = new DBActions();

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();

            // Get AutoFill Data for Federal States
            // Only if Parameter is set to true
            //if (Globals.UseAutoFillOnFederalStates == true)
            //{
            //    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("FEDERALSTATES").Rows)
            //    {
            //        AutoFillFederalStates.Add(AutoFillItems[1].ToString());
            //    }
            //    cb_bundesland.DataSource = AutoFillFederalStates;
            //}
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            // Change DisplayLanguage to user-defined language if parameter is not set to null
            if (Globals.UICulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Globals.UICulture);
                Controls.Clear();
                InitializeComponent();
            }

            // Genereate the AddressBook Form
            GenerateAdrBookForm();
        }

        //=====================================================================================================================================================================
        private void GenerateAdrBookForm(string[] ContactName = null, int ContactId = 0)
        {
            // Get Count over all Contacts in the Database and show the String in the StatusStrip
            int ContactCounter = GetContactsCount();

            if (ContactCounter == 0)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " " + GlobalStrings._contactsAvailable;
                LoadContactMain("new");
            }
            else if (ContactCounter == 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " " + GlobalStrings._contactAvailable;
                LoadContactMain("view", ContactName, ContactId);
            }
            else if (ContactCounter > 1)
            {
                toolStripStatusLabel1.Text = ContactCounter.ToString() + " " + GlobalStrings._contactsAvailable;
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
            // Load ContactData from the Database
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

            // Convert gender "male" and "female" into the translated value for the selected CultureInfo
            string ContactGender = null;

            if (ContactDetails[3] == "male" && Globals.UICulture != "en-US")
            {
                switch (Globals.UICulture)
                {
                    case "de-DE":
                        ContactGender = "männlich";
                        break;

                    case "fr-FR":
                        ContactGender = "mâle";
                        break;
                }
            }
            else if (ContactDetails[3] == "female" && Globals.UICulture != "en-US")
            {
                switch (Globals.UICulture)
                {
                    case "de-DE":
                        ContactGender = "weiblich";
                        break;

                    case "fr-FR":
                        ContactGender = "femelle";
                        break;
                }
            }
            else
            {
                ContactGender = ContactDetails[3];
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

                    cb_gender.SelectedItem = ContactGender;
                    cb_gender.Text = ContactGender;

                    // Birthdate should always be displayed in the current date/time format settings f.e. 1980/01/01 or 01.01.80 or 1.Jan.80
                    // And: if the DB value for birthday is NULL, we will display 01.01.1900 since the datetimepicker needs a valid date time value and can't be null.
                    if (!string.IsNullOrEmpty(ContactDetails[4]))
                    {
                        dtp_birthdate.Value = Convert.ToDateTime(ContactDetails[4]);
                    }
                    else
                    {
                        dtp_birthdate.Text = Convert.ToDateTime("01.01.1900").ToString("d");
                    }

                    tb_street.Text = ContactDetails[5];
                    tb_zipcode.Text = ContactDetails[6];
                    
                    // if AutoFill for cities is set to true, load the data into the Items List
                    //if(AutoFillCities.Contains(ContactDetails[7]))
                    //{
                        
                    //}

                    cb_city.SelectedItem = ContactDetails[7];
                    cb_city.Text = ContactDetails[7];

                    // if AutoFill for FederalStates is set to true, load the data into the Item List
                    //if (AutoFillFederalStates.Contains(ContactDetails[8]))
                    //{
                        
                    //}
                    cb_bundesland.SelectedItem = ContactDetails[8];
                    cb_bundesland.Text = ContactDetails[8];

                    tb_country.Text = ContactDetails[9];
                    tb_phone.Text = ContactDetails[10];
                    tb_mobile.Text = ContactDetails[11];
                    tb_mail.Text = ContactDetails[12];
                    rtb_notes.Text = ContactDetails[13];
                }
                else
                {
                    tb_name.Text = null;
                    tb_surename.Text = null;
                    cb_gender.Text = null;
                    // the initial Value for the DTP should be 01.01.1900 since it can't be null - and we don't want to use the "current" date for the default birthday date :)
                    dtp_birthdate.Text = Convert.ToDateTime("01.01.1900").ToString("d");
                    tb_street.Text = null;
                    tb_zipcode.Text = null;
                    cb_city.Text = null;
                    cb_bundesland.Text = null;
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

                    if (!string.IsNullOrEmpty(ContactDetails[4]))
                    {
                        // Convert the Birthday value into the DateTime Format the System is using
                        label_birthdate.Text = Convert.ToDateTime(ContactDetails[4]).ToString("d");
                    }
                    else
                    {
                        label_birthdate.Text = null;
                    }

                    label_street.Text = ContactDetails[5];
                    label_zip.Text = ContactDetails[6];
                    label_city.Text = ContactDetails[7];
                    label_region.Text = ContactDetails[8];
                    label_country.Text = ContactDetails[9];
                    label_phone.Text = ContactDetails[10];
                    label_mobile.Text = ContactDetails[11];
                    label_mail.Text = ContactDetails[12];
                    rtb_notesDisplay.Text = ContactDetails[13];

                    // Load the Image depending on the gender
                    if (ContactDetails[3] == "male")
                    {
                        pb_gender.BackgroundImage = Properties.Resources.male;
                    }
                    else if (ContactDetails[3] == "female")
                    {
                        pb_gender.BackgroundImage = Properties.Resources.female;
                    }  
                    else
                    {
                        pb_gender.BackgroundImage = null;
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

            // load the Parent Nodes from the DB and count the Items in this node:
            // C [2] -> 2 Contacts, Name starts with "C"
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

            // Select the child nodes -> Load our Contacts List
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
            // Parent Node can't be selectable
            if (_unselectableNodes.Contains(e.Node))
            {
                e.Cancel = true;
            }
        }

        //=====================================================================================================================================================================
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // we need to know, what we want to display - so we need the selected name, surename for our db request
            string[] names = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");
            LoadContactMain("view", names);
        }

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            // New contact should be created
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // New contact should be created
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void Btn_UpdateContact_Click(object sender, EventArgs e)
        {
            // existing contact should be edited
            LoadContactMain("edit", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {
            // selected contact should be deleted
            if (dbAction.DeleteContact(null, ContactID))
            {
                GenerateAdrBookForm();
            }
        }

        //=====================================================================================================================================================================
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            string birthdate = null;
            string gender = null;

            // Convert the Birthdate value into one predefined string for the Database.
            // this will make sure, that we will always have the same format stored in our Database and it does not matter, if the user will change the DateTime Format during the runtime or later
            if(dtp_birthdate.Value.ToString("yyyy-MM-dd") != "1900-01-01")
            {
                birthdate = dtp_birthdate.Value.ToString("yyyy-MM-dd");
            }

            // We should save also the gender in one predefined string (english)
            // -> this will make sure, that we are alsways able to use the gender Items in the translated values (male -> männlich, männlich -> mâle, etc.)
            if (cb_gender.Text == "männlich" || cb_gender.SelectedItem.ToString() == "männlich" || cb_gender.Text == "mâle" || cb_gender.SelectedItem.ToString() == "mâle")
            {
                gender = "male";
            }
            else if (cb_gender.Text == "weiblich" || cb_gender.SelectedItem.ToString() == "weiblich" || cb_gender.Text == "femelle" || cb_gender.SelectedItem.ToString() == "femelle")
            {
                gender = "female";
            }
            else
            {
                gender = cb_gender.SelectedItem.ToString();
            }

            // we load all values from the formular into a List
            List<string> DBContactDetails = new List<string>
            {
                tb_name.Text,
                tb_surename.Text,
                gender,
                birthdate,
                tb_street.Text,
                tb_zipcode.Text,
                cb_city.Text,
                cb_bundesland.Text,
                tb_country.Text,
                tb_phone.Text,
                tb_mobile.Text,
                tb_mail.Text,
                rtb_notes.Text
            };

            string[] names = { tb_name.Text, tb_surename.Text };

            // now, we're checking if tb_name and tb_surename are not empty
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
            // reset and abort insertion -> show the normal contact form
            LoadContactMain("view", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void TbName_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of tb_name if the user starts input after a failed validation
            tb_name.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private void TbSurename_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of tb_surename if the user starts input after a failed validation
            tb_surename.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private bool ValidateTextInputs()
        {
            // Validate tb_name
            if (string.IsNullOrEmpty(tb_name.Text))
            {
                MessageBox.Show(GlobalStrings._addrBook_Validation_Name);
                tb_name.BackColor = Color.MistyRose;
                tb_name.Select();
                return false;
            }

            // Validate tb_surename
            if (string.IsNullOrEmpty(tb_surename.Text))
            {
                MessageBox.Show(GlobalStrings._addrBook_Validation_SureName);
                tb_surename.BackColor = Color.MistyRose;
                tb_surename.Select();
                return false;
            }

            // maybe, we need to implement more validation checks:
            // --> it is not clear, if we can continue with the masked_text_box for the ZipCode, since it does not support AutoFill / Suggestions
            // --> validate, if the typed ZipCode is valid for Germany
            // --> validate, if the ZipCode and City will match
            // --> validate, if the City and the FederalState will match
            return true;
        }

        private void cb_City_KeyPress(object sender, KeyPressEventArgs e)
        {
            AutoFillCities.Clear();
            // Get AutoFill Data for Cities
            // Only if Parameter is set to true

            if (Globals.UseAutoFillOnCities == true)
            {
                if (!string.IsNullOrEmpty(cb_city.Text))
                {
                    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("CITIES", cb_city.Text).Rows)
                    {
                        AutoFillCities.Add(AutoFillItems[0].ToString());
                    }
                    cb_city.DataSource = AutoFillCities;

                    //MessageBox.Show(cb_city.Text);
                }
            }
        }

        private void cb_City_TextChanged(object sender, EventArgs e)
        {
            
        }

        //
        //=====================================================================================================================================================================
        //=====================================================================================================================================================================
        //

        // Disabled Contact Export to Outlook.
        // right now it is not clear, how the software behaves, if no MS-Outlook is installed
        // also, it would be nice to support also other Email-clients but supporting all different types and detecting what is installed on the client system will break the scope of the software

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
