using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
//using Outlook = Microsoft.Office.Interop.Outlook;
using System.Drawing;
using System.Threading;
using System.Globalization;
using Jitbit.Utils;
using System.Diagnostics;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        private List<TreeNode> _unselectableNodes = new List<TreeNode>();
        List<string> AutoFillCities = new List<string>();
        List<string> AutoFillStates = new List<string>();
        List<string> AutoFillPostalCodes = new List<string>();
        List<string> AutoFillCountries = new List<string>();

        int ContactID = 0;

        DBActions dbAction = new DBActions();

        //=====================================================================================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=====================================================================================================================================================================
        private void AddressBook__Load(object sender, EventArgs e)
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

            Globals.UseAutoFillOnCities = true;
            Globals.UseAutoFillOnStates = true;
            Globals.UseAutoFillOnPostalCodes = true;
            Globals.UseAutoFillOnCountries = true;

            // ... for Cities
            

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
            LoadTreeViewAlphabet();
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

 // Bis hier hin kommt die Ausführung des Codes nach SELECT

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
            [1]  => Name 1                 
            [2]  => Name 2                  
            [3]  => SureName                
            [4]  => Gender                 
            [5]  => BirthDate            
            [6]  => Address Line 1        
            [7]  => Address Line 2      
            [8]  => Postal Code        
            [9]  => City
            [10] => State                   
            [11] => Country   
            [12] => Phone                   
            [13] => Mobile                  
            [14] => Email                   
            [15] => Notes
            */

                
            // in this part, we define, what our Form will show.
            // if the Form-Type (we are setting this var sometimes) is NEW or EDIT, we should display the INPUT form
            if (Type == "new" || Type == "edit")
            {

                if (Globals.UseAutoFillOnCities == true)
                {
                    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("city", cb_City.Text).Rows)
                    {
                        AutoFillCities.Add(AutoFillItems[0].ToString());
                    }

                    foreach (string item in AutoFillCities)
                    {
                        cb_City.AutoCompleteCustomSource.Add(item);
                    }
                    cb_City.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                // ... for Federal States
                if (Globals.UseAutoFillOnStates == true)
                {
                    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("state", cb_State.Text).Rows)
                    {
                        AutoFillStates.Add(AutoFillItems[0].ToString());
                    }

                    foreach (string item in AutoFillStates)
                    {
                        cb_State.AutoCompleteCustomSource.Add(item);
                    }
                    cb_State.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                if (Globals.UseAutoFillOnPostalCodes == true)
                {
                    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("postalcode", tb_PostalCode.Text).Rows)
                    {
                        AutoFillPostalCodes.Add(AutoFillItems[0].ToString());
                    }

                    foreach (string item in AutoFillPostalCodes)
                    {
                        tb_PostalCode.AutoCompleteCustomSource.Add(item);
                    }
                    tb_PostalCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

                if (Globals.UseAutoFillOnCountries == true)
                {
                    foreach (DataRow AutoFillItems in dbAction.GetAutoComplete("country", cb_Country.Text).Rows)
                    {
                        AutoFillCountries.Add(AutoFillItems[0].ToString());
                    }

                    foreach (string item in AutoFillCountries)
                    {
                        cb_Country.AutoCompleteCustomSource.Add(item);
                    }
                    cb_Country.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }

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
                    tb_Name1.Text = ContactDetails[1];
                    tb_Name2.Text = ContactDetails[2];
                    tb_FamilyName.Text = ContactDetails[3];

                    // initiate a new String for the GENDER value
                    string ContactGender = null;

                    // in our Database, we only want to store the Gender as male or female.
                    // in the form, we want to use localized strings - so, we need to translate the values from the DB...
                    if (ContactDetails[4] == "male" && Globals.UICulture != "en-US")
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
                    else if (ContactDetails[4] == "female" && Globals.UICulture != "en-US")
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
                        ContactGender = ContactDetails[4];
                    }

                    cb_Gender.SelectedItem = ContactGender; // [4]
                    cb_Gender.Text = ContactGender;

                    // Here, we need to do a bit of Workaround for the DateTimePicker, since it does not allow NULL Values.
                    // But sometimes, we haven't any Dates for the Birthdate.
                    // So, we need to show a Date, which will be 01.01.1900
                    // also, we want to support localized Date / Time format options...
                    if (!string.IsNullOrEmpty(ContactDetails[5]))
                    {
                        // we convert the Value from the Database into DateTime Format.
                        // the Database Value should always be yyyy-mm-dd in the Database
                        dtp_BirthDate.Value = Convert.ToDateTime(ContactDetails[5]);
                    }
                    else
                    {
                        // if we don't have any date in our Database, show 01.01.1900 in the Current used Cultural Format.
                        dtp_BirthDate.Text = Convert.ToDateTime("01.01.1900").ToString("d");
                    }

                    // Fill up Street and Zip Code Information
                    tb_AddrLine1.Text = ContactDetails[6];
                    tb_AddrLine2.Text = ContactDetails[7];
                    tb_PostalCode.Text = ContactDetails[8];

                    // I think, here we need to do some changes... I haven't figured out any issue yet, but it could be possible, I think...
                    if (AutoFillCities.Contains(ContactDetails[9]))
                    {
                        cb_City.SelectedItem = ContactDetails[9];
                    }
                    cb_City.Text = ContactDetails[9];

                    // I think, here we need to do some changes... I haven't figured out any issue yet, but it could be possible, I think...
                    if (AutoFillStates.Contains(ContactDetails[10]))
                    {
                        cb_State.SelectedItem = ContactDetails[10];
                    }
                    cb_State.Text = ContactDetails[10];

                    if (AutoFillCountries.Contains(ContactDetails[11]))
                    {
                        cb_Country.SelectedItem = ContactDetails[11];
                    }
                    cb_Country.Text = ContactDetails[11];

                    tb_Phone.Text = ContactDetails[12];
                    tb_Mobile.Text = ContactDetails[13];
                    tb_Mail.Text = ContactDetails[14];
                    rtb_Notes.Text = ContactDetails[15];
                }

                // if we are not in "EDIT" mode, then we want to CREATE a new Contact.
                // In this case, we want to clear all cached TXT in the Form.
                // if we don't set the Text values to NULL here, we always show the Text which was last entered (during the runtime)
                else
                {
                    tb_Name1.Text = null;
                    tb_Name2.Text = null;
                    tb_FamilyName.Text = null;

                    cb_Gender.Text = null;
                    
                    // again, we need to set the default date to 01.01.1900 - this will be interpreted as NULL when we save the data
                    dtp_BirthDate.Text = Convert.ToDateTime("01.01.1900").ToString("d");

                    tb_AddrLine1.Text = null;
                    tb_AddrLine2.Text = null;
                    tb_PostalCode.Text = null;

                    cb_City.Text = null;
                    cb_State.Text = null;
                    cb_Country.Text = null;

                    tb_Phone.Text = null;
                    tb_Mobile.Text = null;
                    tb_Mail.Text = null;
                    rtb_Notes.Text = null;
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

                    lb_Name1.Text = ContactDetails[1];
                    lb_Name2.Text = ContactDetails[2];
                    lb_FamilyName.Text = ContactDetails[3];

                    // we want to show a nice little graphic for the sex of our Contact
                    if (ContactDetails[4] == "male")
                    {
                        pb_Gender.BackgroundImage = Properties.Resources.male;
                    }
                    else if (ContactDetails[4] == "female")
                    {
                        pb_Gender.BackgroundImage = Properties.Resources.female;
                    }
                    else
                    {
                        // but if we don't have a gender set, we don't want to show any icon :)
                        pb_Gender.BackgroundImage = null;
                    }

                    // if the Date in our Database isn't NULL we need to change the String Format to the Systems current Culture
                    // f.e. 2018-09-12 will be -> 2018/09/12 or 12.09.2018
                    if (!string.IsNullOrEmpty(ContactDetails[5]))
                    {
                        lb_BirthDate.Text = Convert.ToDateTime(ContactDetails[5]).ToString("d");
                    }
                    else
                    {
                        // if the DB Value is NULL, we don't want to show anything
                        lb_BirthDate.Text = null;
                    }

                    lb_AddrLine1.Text = ContactDetails[6];
                    lb_AddrLine2.Text = ContactDetails[7];
                    lb_PostalCode.Text = ContactDetails[8];
                    lb_City.Text = ContactDetails[9];
                    lb_State.Text = ContactDetails[10];
                    lb_Country.Text = ContactDetails[11];

                    lb_Phone.Text = ContactDetails[12];
                    lb_MobilePhone.Text = ContactDetails[13];
                    lb_Mail.Text = ContactDetails[14];

                    rtb_NotesDisplay.Text = ContactDetails[15];
                }

                // also, we can now enable our Editor-Buttons
                Btn_CreateContact.Enabled = true;
                Btn_UpdateContact.Enabled = true;
                Btn_DeleteContact.Enabled = true;
            }
        }

        //=====================================================================================================================================================================
        /*private void LoadTreeViewCountries()
        {
            treeView1.Nodes.Clear();
            TreeNode Country = null;

            if (Globals.ShowContactsCountryAsRoot == true)
            {
                foreach (DataRow drRoot in dbAction.GetContacts("root").Rows)
                {
                    Country = treeView1.Nodes.Add(drRoot[1].ToString());

                    LoadTreeViewAlphabet(Country);

                    _unselectableNodes.Add(Country);
                }
            }
            else
            {
                LoadTreeViewAlphabet();
            }
        }*/

        //=====================================================================================================================================================================
        private void LoadTreeViewAlphabet(TreeNode RootNode = null)
        {
            treeView1.Nodes.Clear();
            TreeNode alphabet = null;

            foreach (DataRow drParents in dbAction.GetContacts("alphabet").Rows)
            {
                // This should be the First letter of the name and how many entries we have in our DB.
                // f.e. we have 5 Contacts - the name of three of them starting with an A and two with a C, then we will show A [3], C [2]
                alphabet = treeView1.Nodes.Add(drParents[1].ToString() + " [" + drParents[0] + "]");

                // If this is done, we load the Child Nodes (Each contact)
                LoadTreeViewChilds(alphabet);

                // and we want to make the parent nodes unselectable -> because this will cause issues with our Detail and Edit Page
                _unselectableNodes.Add(alphabet);
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

                //MessageBox.Show(drChilds.ToString());
                
                // we only want to Display Name and Surename
                string ChildNode = drChilds[1] + ", " + drChilds[2];
                
                // and the Sexual image (female, male, nothing)
                int ImageIndex;

                switch (drChilds[3])
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
                childs.Tag = drChilds[0];
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
            // for fixing https://github.com/Christoph-Caina/eNumismat/issues/72 we need to give the contact ID when the Contact will be selected.
            // we are using the "TAG" option for the Node to do this.
            // see LoadContactMain(..., ..., selectedNode.Tag)
            string[] names = Regex.Split(treeView1.SelectedNode.ToString().Remove(0, 10), ", ");


            // Load the Form in View Mode with the selected Names
            LoadContactMain("view", names, Convert.ToInt32(treeView1.SelectedNode.Tag));
        }

        //=====================================================================================================================================================================
        private void Btn_CreateContact_Click(object sender, EventArgs e)
        {
            // If Editor Button "Create" was pressed, show the Editor in Creation mode
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
            if (dtp_BirthDate.Value.ToString("yyyy-MM-dd") != "1900-01-01")
            {
                // if it is not 1900-01-01 then we want to save the value
                birthdate = dtp_BirthDate.Value.ToString("yyyy-MM-dd");
            }

            // we don't need to handle the ELSE, because the var was already initialized with NULL

            // we are showing localized and translated strings for GENDER male and female.
            // in our Database, we only want to save the english values.
            switch (cb_Gender.Text)
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
                    gender = cb_Gender.Text;
                    break;
            }

            // we load everything into a LIST which will be given to our DBActions file.
            List<string> DBContactDetails = new List<string>
            {
                tb_Name1.Text,              // 01
                tb_Name2.Text,              // 02
                tb_FamilyName.Text,         // 03 
                gender,                     // 04
                birthdate,                  // 05
                tb_AddrLine1.Text,          // 06
                tb_AddrLine2.Text,          // 07
                tb_PostalCode.Text,         // 08
                cb_City.Text,               // 09
                cb_State.Text,              // 10
                cb_Country.Text,            // 11
                tb_Phone.Text,              // 12
                tb_Mobile.Text,             // 13
                tb_Mail.Text,               // 14
                rtb_Notes.Text              // 15
            };

            // before we can save the Values, we want to do some Validations.
            // We need to check, if the Name and SureName isn't empty...
            if (ValidateTextInputs() == true)
            {
                // names needed to be in a seperate string array, because we want to display the created or edited contact after inserting the values into the Database.
                string[] names = { tb_FamilyName.Text, tb_Name1.Text };

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

        // Reset TB Color:
        //=====================================================================================================================================================================
        private void TbName_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of the Textbox, after it was showing an Invalid input
            tb_Name1.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private void TbSurename_TextChanged(object sender, EventArgs e)
        {
            // reset the BackColor of the Textbox, after it was showing an Invalid input
            tb_FamilyName.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private void TbEmail_TextChanged(object sender, EventArgs e)
        {
            tb_Mail.BackColor = Color.White;
        }

        //=====================================================================================================================================================================
        private bool ValidateTextInputs()
        {
            // the Validation itself will be done in a new Class -> there, we can do different validations and also we can validate the input from other forms...
            InputValidation validate = new InputValidation();

            // but what should we do, if we have invalid input?
            // first, we need to check, if the fields are empty -> only the names are really important, since we need this information to show anything.
            // The Database should also not acceppt NULL values for NAME and SURENAME
            
            // Name1 and Surename can't be empty.
            // So we can't check if the ValidateNames Parameter is set or not.
            // if this parameter is set to true, we can do some other validation checks.
            // f.e. Name1, Name2 and Name3 should not be the same
            // also, a Name should not contain numbers, f.e
            // I need to do a checklist, what validations we can use and which one not
            
            //if (Globals.ValidateNames == true)
            //{
                if (validate.ValidateData(tb_Name1.Text, "IsNullOrEmpty"))
                {
                    MessageBox.Show(GlobalStrings._addrBook_Validation_NameEmpty);
                    tb_Name1.BackColor = Color.MistyRose;
                    tb_Name1.Select();
                    return false;
                }

                if (validate.ValidateData(tb_FamilyName.Text, "IsNullOrEmpty"))
                {
                    MessageBox.Show(GlobalStrings._addrBook_Validation_SureNameEmpty);
                    tb_FamilyName.BackColor = Color.MistyRose;
                    tb_FamilyName.Select();
                    return false;
                }
            //}

            if (Globals.ValidateEmail == true)
            {
                if (validate.ValidateData(tb_Mail.Text, "IsNullOrEmpty"))
                {
                    MessageBox.Show(GlobalStrings._addrBook_Validation_EmailEmpty);
                    tb_Mail.BackColor = Color.MistyRose;
                    tb_Mail.Select();
                    return false;
                }
                else
                {
                    if (!validate.ValidateData(tb_Mail.Text, "ValidEmail"))
                    {

                        MessageBox.Show(GlobalStrings._addrBook_Validation_Email);
                        tb_Mail.BackColor = Color.MistyRose;
                        tb_Mail.Select();
                        return false;
                    }
                }
            }
            return true;
        }

        private void ImportCsvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = Globals.DBFilePath,
                DefaultExt = "*.csv",
                Filter = "Comma Separated Values(*.csv) | *.csv"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                CSVImport ImportDialog = new CSVImport();
                ImportDialog.CsvFile = ofd.FileName;
                ImportDialog.Show();
            }
        }

        private void ExportCsvFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Working on it... :)");
            /*SaveFileDialog sfd = new SaveFileDialog
            {
                InitialDirectory = Globals.DBFilePath,
                DefaultExt = "*.csv",
                Filter = "Comma Separated Values (*.csv) | *.csv",
                AddExtension = true
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                CsvExport csvExport = new CsvExport();
                

            }*/
        }

        private void btn_email_Click(object sender, EventArgs e)
        {
            Process.Start(@"mailto:" + lb_Mail.Text);
        }
    }
}

