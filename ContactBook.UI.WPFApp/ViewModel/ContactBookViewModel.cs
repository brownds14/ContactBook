using ContactBook.Domain;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ContactBook.UI.WPFApp.Model;

namespace ContactBook.UI.WPFApp.ViewModel
{
    public class ContactBookViewModel : ViewModelBase
    {
        private IContactService _service;
        private ObservableCollection<ContactModel> _contactList;
        private int _selectedContactIndex;
        private ContactModel _selectedContact;
        private string _searchString;
        private string _statusString;
        private bool _isEditing;
        private ObservableCollection<string> _phoneTypes;

        private int _selectedEmailIndex;
        private int _selectedPhoneIndex;

        public ContactBookViewModel(IContactService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            _service = service;
            ContactList = new ObservableCollection<ContactModel>();
            foreach (var c in _service.GetAll())
            {
                ContactList.Add(new ContactModel(c));
            }
            SelectedContactIndex = -1;
            SelectedContact = new ContactModel();
            SearchString = string.Empty;
            StatusString = "All contacts were successfully loaded.";
            IsEditing = false;

            _phoneTypes = new ObservableCollection<string>(Enum.GetNames(typeof(PhoneType)));

            SelectedEmailIndex = -1;
            SelectedPhoneIndex = -1;

            CmdAddContact = new RelayCommand(AddContact);
            CmdRemoveContact = new RelayCommand(RemoveContact);
            CmdEditContact = new RelayCommand(EditContact);
            CmdSaveContact = new RelayCommand(SaveContact);
            CmdCancel = new RelayCommand(CancelContactChanges);

            CmdAddEmail = new RelayCommand(AddEmail);
            CmdDeleteEmail = new RelayCommand(DeleteEmail);

            CmdAddPhone = new RelayCommand(AddPhone);
            CmdDeletePhone = new RelayCommand(DeletePhone);
        }

        public void AddContact()
        {
            SelectedContactIndex = -1;
            SelectedContact = new ContactModel();
            IsEditing = true;
        }

        public void RemoveContact()
        {
            int id = _selectedContact.Id;
            Contact c = _service.Get(id);
            if (_service.Remove(c))
            {
                ContactList.Remove(SelectedContact);
                SelectedContactIndex = -1;
                StatusString = "Contact successfully removed.";
            }
            else
                StatusString = "Failed to remove contact.";
        }

        public void EditContact()
        {
            IsEditing = true;
        }

        public void SaveContact()
        {
            Contact c = _selectedContact.ToDomainContact();
            if (_selectedContact.Id < 0)
            {
                if (_service.Add(c))
                {
                    ContactList.Add(_selectedContact);
                    StatusString = "Contact successfully added.";
                }
                else
                    StatusString = "Contact failed to save. Please check the contact information for any errors.";
            }
            else
            {
                _service.Update(c);
                StatusString = "Contact successfully edited.";
            }

            IsEditing = false;
        }

        public void CancelContactChanges()
        {
            if (_selectedContact.Id < 0)
            {
                SelectedContactIndex = -1;
            }
            else
            {
                Contact c = _selectedContact.ToDomainContact();
                _service.Reload(c);
            }

            IsEditing = false;
        }

        public void AddEmail()
        {
            SelectedContact.Emails.Add(new EmailModel());
        }

        public void DeleteEmail()
        {
            if (_selectedEmailIndex >= 0)
            {
                var e = SelectedContact.Emails[_selectedEmailIndex];
                _service.DeleteEmail(e.ToDomainEmail());
                SelectedContact.Emails.Remove(e);
            }
        }

        public void AddPhone()
        {
            SelectedContact.Phones.Add(new PhoneModel());
        }

        public void DeletePhone()
        {
            if (_selectedPhoneIndex >= 0)
            {
                var p = SelectedContact.Phones[_selectedPhoneIndex];
                _service.DeletePhone(p.ToDomainPhone());
                SelectedContact.Phones.Remove(p);
            }
        }

        #region UIProperties
        public ICommand CmdAddContact { get; private set; }
        public ICommand CmdRemoveContact { get; private set; }
        public ICommand CmdEditContact { get; private set; }
        public ICommand CmdSaveContact { get; private set; }
        public ICommand CmdCancel { get; private set; }

        public ICommand CmdAddEmail { get; private set; }
        public ICommand CmdDeleteEmail { get; private set; }

        public ICommand CmdAddPhone { get; private set; }
        public ICommand CmdDeletePhone { get; private set; }

        public ObservableCollection<ContactModel> ContactList
        {
            get { return _contactList; }
            set { Set(() => ContactList, ref _contactList, value); }
        }

        public int SelectedContactIndex
        {
            get { return _selectedContactIndex; }
            set
            {
                if (Set(() => SelectedContactIndex, ref _selectedContactIndex, value))
                {
                    if (_selectedContactIndex >= 0)
                        SelectedContact = ContactList[_selectedContactIndex];
                    else
                        SelectedContact = new ContactModel(new Contact());
                }
            }
        }

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set { Set(() => SelectedContact, ref _selectedContact, value); }
        }

        public string SearchString
        {
            get { return _searchString; }
            set { Set(() => SearchString, ref _searchString, value); }
        }

        public string StatusString
        {
            get { return _statusString; }
            set { Set(() => StatusString, ref _statusString, value); }
        }

        public bool IsEditing
        {
            get { return _isEditing; }
            set { Set(() => IsEditing, ref _isEditing, value); }
        }

        public ObservableCollection<string> PhoneTypes
        {
            get { return _phoneTypes; }
        }

        public int SelectedEmailIndex
        {
            get { return _selectedEmailIndex; }
            set { Set(() => SelectedEmailIndex, ref _selectedEmailIndex, value); }
        }

        public int SelectedPhoneIndex
        {
            get { return _selectedPhoneIndex; }
            set { Set(() => SelectedPhoneIndex, ref _selectedPhoneIndex, value); }
        }
        #endregion
    }
}