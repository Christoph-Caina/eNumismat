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
        List<string> AutoFillCities = new List<string>();
        List<string> AutoFillFederalStates = new List<string>();

        int ContactID = 0;

        DBActions dbAction = new DBActions();

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=====================================================================================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {
            // Check, if the User has set another Culture / Language for the form.
            // if yes, use the userSettings instead of the System default Culture
            if (Globals.UICulture != null)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(Globals.UICulture);
                Controls.Clear();
                InitializeComponent();
            }

            // If the Setting for Using AutoFill is set to true, here we are getting the Data...

            // ... for Cities
            if (Globals.UseAutoFillOnCities == true)
            {
                foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("CITIES", cb_city.Text).Rows)
                {
                    AutoFillCities.Add(AutoFillItems[0].ToString());
                }

                foreach (string item in AutoFillCities)
                {
                    cb_city.AutoCompleteCustomSource.Add(item);
                }

                cb_city.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            // ... for Federal States
            if (Globals.UseAutoFillOnFederalStates == true)
            {
                foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("FEDERALSTATES", cb_bundesland.Text).Rows)
                {
                    AutoFillFederalStates.Add(AutoFillItems[0].ToString());
                }

                foreach (string item in AutoFillFederalStates)
                {
                    cb_bundesland.AutoCompleteCustomSource.Add(item);
                }
                cb_bundesland.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }

            // ... for Zip-Codes
            // (Masked Text Box does not support AutoComplete / Suggestions -> maybe, we need to change the control or create our own Control.

            // Generate our AddressBook form
            GenerateAdrBookForm();
        }

        //=====================================================================================================================================================================
        private void GenerateAdrBookForm(string[] ContactName = null, int ContactId = 0)
        {
            // Get the Amount of Contacts in our Database -> This Information will be shown in the StatusLabel
            // depending, if we have any contacts in our DB or not, we also decide, what form we need to display.
            // 0 Contacts -> we're showing an empty input Form, because we don't need to display empty labels.
            // > 0 Contacts, then we are displaying the Contact Details.
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

            // also, we need to fill our TreeView
            // the parent Nodes first
            LoadTreeViewParents();
        }

        //=====================================================================================================================================================================
        private int GetContactsCount()
        {
            // calling the Counter Select in the DBAction file
            return dbAction.ContactsCount();
        }

        //=====================================================================================================================================================================
        private void LoadContactMain(string Type, string[] ContactName = null, int ContactId = 0)
        {
            // We're collecting the Data, decide what Select we need to perform on the Database etc.
            DataTable _ContactDetails = new DataTable();
           

            // If we don't have anything in our Database
            if (ContactName == null && ContactId == 0)
            {
                // we can only perform a select without a where clause -> this will show the first entry in the Database in alphabetical Order
                _ContactDetails = dbAction.GetContacts("details");
            }
            // if we have a Contact Name, but no ContactId
            else if (ContactName != null && ContactId == 0)
            {
                // we can perform a select with the Name -> this will show the details of the selected contact (selected by names)
                _ContactDetails = dbAction.GetContacts("details", null, ContactName);
            }
            // if we have no Contact Name, but the ContactId
            else if (ContactName == null && ContactId != 0)
            {
                // we will run the select with the ID
                _ContactDetails = dbAction.GetContacts("details", null, null, ContactId);
            }
            // if we have both, 
            else if (ContactName != null && ContactId != 0)
            {
                // we can run the select with name and id -> which is not needed, but should still be covered
                _ContactDetails = dbAction.GetContacts("details", null, ContactName, ContactId);
            }

            // now, we need to know, how many Columns we've got back.
            // We need this to fill the Query Data into a List
            int DataTableCounter = _ContactDetails.Columns.Count;
            int i = 0;

            // this is our List with all the Contact Details in it
            List<string> ContactDetails = new List<string>();

            // we're filling our list - each column will get a new Entry in the list
            while (i < DataTableCounter)
            {
                foreach (DataRow drDetails in _ContactDetails.Rows)
                {
                    ContactDetails.Add(drDetails[i].ToString());
                }

                i++;
            }

            // There is still an issue in this code:
            // We fill the List by counting the columns of our DB query, but then, after filling up the List, we don't know the size - and we don't really know, which position will be which value.
            // so this is "static" code, and maybe we need to change it to be more dynamically?

            /*
            [0]  => ID
            [1]  => Name
            [2]  => SureName
            [3]  => Gender
            [4]  => Birthdate
            [5]  => Street
            [6]  => ZipCode
            [7]  => City
            [8]  => FederalState
            [9]  => Country
            [10] => Phone
            [11] => Mobile
            [12] => Email
            [13] => Notes
            */

            // initiate a new String for the GENDER value
            string ContactGender = null;
            
            // in our Database, we only want to store the Gender as male or female.
            // in the form, we want to use localized strings - so, we need to translate the values from the DB...
            if (ContactDetails[3] == "male" && Globals.UICulture != "en-US")
            {
                switch (Globals.UICulture)
                {
                    case "de-DE":
                        ContactGender = "männlich";
                        break;

                    case "fr-FR":
                        ContactGender = "malé";
                        break;

                    case "es-ES":
                        ContactGender = "masculino";
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

                    case "es-ES":
                        ContactGender = "hembra";
                        break;
                }
            }
            else
            {
                // if the culture is set to en, we don't need to translate the value, and we can just use it :)
                ContactGender = ContactDetails[3];
            }

            // in this part, we define, what our Form will show.
            // if the Form-Type (we are setting this var sometimes) is NEW or EDIT, we should display the INPUT form
            if (Type == "new" || Type == "edit")
            {
                // remove the "Show Details" Panel and Add the Editor Panel
                splitContainer1.Panel2.Controls.Remove(PanelShowContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelEditContactDetails);
                PanelEditContactDetails.Dock = DockStyle.Fill;

                // also, if we have the Type EDIT, we need to prefill our input controls with the Data, we already have
                if (Type == "edit" && ContactDetails.Count != 0)
                {
                    // we know the ID from the selected Contact
                    ContactID = Convert.ToInt32(ContactDetails[0]);

                    // We know the Name and Surename
                    tb_name.Text = ContactDetails[1];
                    tb_surename.Text = ContactDetails[2];

                    // We can display the localized Gender and Preselect the value
                    cb_gender.SelectedItem = ContactGender;
                    cb_gender.Text = ContactGender;

                    // Here, we need to do a bit of Workaround for the DateTimePicker, since it does not allow NULL Values.
                    // But sometimes, we haven't any Dates for the Birthdate.
                    // So, we need to show a Date, which will be 01.01.1900
                    // also, we want to support localized Date / Time format options...
                    if (!string.IsNullOrEmpty(ContactDetails[4]))
                    {
                        // we convert the Value from the Database into DateTime Format.
                        // the Database Value should always be yyyy-mm-dd in the Database
                        dtp_birthdate.Value = Convert.ToDateTime(ContactDetails[4]);
                    }
                    else
                    {
                        // if we don't have any date in our Database, show 01.01.1900 in the Current used Cultural Format.
                        dtp_birthdate.Text = Convert.ToDateTime("01.01.1900").ToString("d");
                    }

                    // Fill up Street and Zip Code Information
                    tb_street.Text = ContactDetails[5];
                    tb_zipcode.Text = ContactDetails[6];

                    // I think, here we need to do some changes... I haven't figured out any issue yet, but it could be possible, I think...
                    if (AutoFillCities.Contains(ContactDetails[7]))
                    {
                        cb_city.SelectedItem = ContactDetails[7];
                        cb_city.Text = ContactDetails[7];
                    }

                    // I think, here we need to do some changes... I haven't figured out any issue yet, but it could be possible, I think...
                    if (AutoFillFederalStates.Contains(ContactDetails[8]))
                    {
                        cb_bundesland.SelectedItem = ContactDetails[8];
                        cb_bundesland.Text = ContactDetails[8];
                    }

                    // Do the same as above for country, phone, mobile, mail and notes.
                    tb_country.Text = ContactDetails[9];
                    tb_phone.Text = ContactDetails[10];
                    tb_mobile.Text = ContactDetails[11];
                    tb_mail.Text = ContactDetails[12];
                    rtb_notes.Text = ContactDetails[13];
                }
                // if we are not in "EDIT" mode, then we want to CREATE a new Contact.
                // In this case, we want to clear all cached TXT in the Form.
                // if we don't set the Text values to NULL here, we always show the Text which was last entered (during the runtime)
                else
                {
                    tb_name.Text = null;
                    tb_surename.Text = null;
                    cb_gender.Text = null;
                    // again, we need to set the default date to 01.01.1900 - this will be interpreted as NULL when we save the data
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

                // If we are already showing our Editors Form, we don't need to activate the Editor Buttons.
                Btn_CreateContact.Enabled = false;
                Btn_DeleteContact.Enabled = false;
                Btn_UpdateContact.Enabled = false;

            }
            // now, we're handling our VIEW form...
            else if (Type == "view")
            {
                // remove the Editor Form and show the Details View
                splitContainer1.Panel2.Controls.Remove(PanelEditContactDetails);
                splitContainer1.Panel2.Controls.Add(PanelShowContactDetails);
                PanelShowContactDetails.Dock = DockStyle.Fill;

                if (ContactDetails.Count != 0)
                {
                    ContactID = Convert.ToInt32(ContactDetails[0]);

                    label_name.Text = ContactDetails[1];
                    label_surename.Text = ContactDetails[2];

                    // if the Date in our Database isn't NULL we need to change the String Format to the Systems current Culture
                    // f.e. 2018-09-12 will be -> 2018/09/12 or 12.09.2018
                    if (!string.IsNullOrEmpty(ContactDetails[4]))
                    {
                        label_birthdate.Text = Convert.ToDateTime(ContactDetails[4]).ToString("d");
                    }
                    else
                    {
                        // if the DB Value is NULL, we don't want to show anything
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

                    // we want to show a nice little graphic for the sex of our Contact
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
                        // but if we don't have a gender set, we don't want to show any icon :)
                        pb_gender.BackgroundImage = null;
                    }
                }
                // also, we can now enable our Editor-Buttons
                Btn_CreateContact.Enabled = true;
                Btn_UpdateContact.Enabled = true;
                Btn_DeleteContact.Enabled = true;
            }
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewParents()
        {
            // when we load the TreeNode, we need to "reset" it first.
            // if we don't do this, we will duplicate all entries every time when we call this function again.
            // so, after each EDIT or CREATION all Nodes will be duplicated.
            treeView1.Nodes.Clear();
            TreeNode parents = null;

            // With the results from our first select, we will create the parent nodes.
            foreach (DataRow drParents in dbAction.GetContacts("parents").Rows)
            {
                // This should be the First letter of the name and how many entries we have in our DB.
                // f.e. we have 5 Contacts - the name of three of them starting with an A and two with a C, then we will show A [3], C [2]
                parents = treeView1.Nodes.Add(drParents[1].ToString() + " [" + drParents[0] + "]");

                // If this is done, we load the Child Nodes (Each contact)
                LoadTreeViewChilds(parents);

                // and we want to make the parent nodes unselectable -> because this will cause issues with our Detail and Edit Page
                _unselectableNodes.Add(parents);
            }
            treeView1.ExpandAll();
        }

        //=====================================================================================================================================================================
        private void LoadTreeViewChilds(TreeNode parentNode)
        {
            TreeNode childs;

            // From the Parent Node, we want to remove the counting.
            // For this, we need to split the Value into two strings -> String1 => C String2 [2] (using the example from above)
            string[] Nodes = parentNode.ToString().Split(' ');

            // now, we have the first letter of our Contacts Name and we can do a db query which will result all contacts, starting with this letter
            foreach (DataRow drChilds in dbAction.GetContacts("childs", Nodes[1]).Rows)
            {
                // we only want to Display Name and Surename
                string ChildNode = drChilds[0] + ", " + drChilds[1];

                // and the Sexual image (female, male, nothing)
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
            // if a contact Node was selected, we need the Name for getting the Details:
            // this will be done by splitting the Node Value into a string array.
            // The Contact will be shown as Name, Surename -> String1 => Name, String2 => surename
            string[] names = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");
            
            // Load the Form in View Mode with the selected Names
            LoadContactMain("view", names);
        }

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            // If Editor Button "Create" was pressed, show the Editor in Creation mode
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void NeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if the user has used the Toolstrip Menu Item "New", do the same as BTN NEW is doing
            ContactID = 0;
            LoadContactMain("new");
        }

        //=====================================================================================================================================================================
        private void Btn_UpdateContact_Click(object sender, EventArgs e)
        {
            // If the Editor Button "Edit" was pressed, show the Editor in Edit mode
            LoadContactMain("edit", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void Btn_DeleteContact_Click(object sender, EventArgs e)
        {
            // If the Delete Button was pressed, delete the selected Contact.
            if (dbAction.DeleteContact(null, ContactID))
            {
                GenerateAdrBookForm();
            }
        }

        //=====================================================================================================================================================================
        private void Btn_Save_Click(object sender, EventArgs e)
        {
            // in Editor Mode, Button Save Pressed:
            // initiate new strings for gender and birthday with null, because we need to do some actions with the strings we are receiving from the form...
            string birthdate = null;
            string gender = null;

            // first, we need to transfer the value from the DateTimePicker into the format we need for our Database.
            // This is yyyy-mm-dd independend from the local settings of the user.
            // Then, we need to check, if the Date is NOT 1900-01-01
            if (dtp_birthdate.Value.ToString("yyyy-MM-dd") != "1900-01-01")
            {
                // if it is not 1900-01-01 then we want to save the value
                birthdate = dtp_birthdate.Value.ToString("yyyy-MM-dd");
            }
            // we don't need to handle the ELSE, because the var was already initialized with NULL
            
            // we are showing localized and translated strings for GENDER male and female.
            // in our Database, we only want to save the english values.
            switch(cb_gender.Text)
            {
                case "hembra":
                case "weiblich":
                case "femelle":
                    gender = "female";
                    break;

                case "masculino":
                case "männlich":
                case "mâle":
                    gender = "male";
                    break;

                default:
                    gender = cb_gender.Text;
                    break;
            }

            // we load everything into a LIST which will be given to our DBActions file.
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

            // before we can save the Values, we want to do some Validations.
            // We need to check, if the Name and SureName isn't empty...
            if (ValidateTextInputs() == true)
            {
                // names needed to be in a seperate string array, because we want to display the created or edited contact after inserting the values into the Database.
                string[] names = { tb_name.Text, tb_surename.Text };

                // If the Validation is OK, we can save everything.
                if (dbAction.CreateOrUpdateContact(DBContactDetails, ContactID))
                {
                    GenerateAdrBookForm(names, ContactID);
                }
            }
        }

        //=====================================================================================================================================================================
        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            // cancel our input and load the details page
            LoadContactMain("view", null, ContactID);
        }

        //=====================================================================================================================================================================
        private void TbName_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of the Textbox, after it was showing an Invalid input
            tb_name.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private void TbSurename_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of the Textbox, after it was showing an Invalid input
            tb_surename.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private bool ValidateTextInputs()
        {
            // the Validation itself will be done in a new Class -> there, we can do different validations and also we can validate the input from other forms...
            InputValidation validate = new InputValidation();

            // but what should we do, if we have invalid input?
            // first, we need to check, if the fields are empty -> only the names are really important, since we need this information to show anything.
            // The Database should also not acceppt NULL values for NAME and SURENAME
            if (validate.ValidateData(tb_name.Text, "IsNullOrEmpty"))
            {
                // show a MessageBox with the warning if the field is empty
                MessageBox.Show(GlobalStrings._addrBook_Validation_Name);
                // change the BackColor of the field for visual feedback
                tb_name.BackColor = Color.MistyRose;
                // set the cursor directly into the field
                tb_name.Select();
                return false;
            }

            // the same than above, for other fields...
            if (validate.ValidateData(tb_surename.Text, "IsNullOrEmpty"))
            {
                MessageBox.Show(GlobalStrings._addrBook_Validation_SureName);
                tb_surename.BackColor = Color.MistyRose;
                tb_surename.Select();
                return false;
            }

            //MessageBox.Show(validate.ValidateData(tb_mail.Text, "ValidEmail").ToString());

            if (!string.IsNullOrEmpty(tb_mail.Text))
            {
                if (!validate.ValidateData(tb_mail.Text, "ValidEmail"))
                {

                    MessageBox.Show(GlobalStrings._addrBook_Validation_Email);
                    tb_mail.BackColor = Color.MistyRose;
                    tb_mail.Select();
                    return false;
                }
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
