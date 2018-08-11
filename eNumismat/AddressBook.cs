using System;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace eNumismat
{
    public partial class AddressBook : Form
    {
        //=============================================================================================================
        public AddressBook()
        {
            InitializeComponent();
        }

        //=============================================================================================================
        private void AddressBook_Load(object sender, EventArgs e)
        {

        }


        // Outlook-Test
        //=============================================================================================================
        private void microsoftOutlookToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
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
