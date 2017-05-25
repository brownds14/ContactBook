using ContactBook.Domain;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Collections.Specialized;

namespace ContactBook.UI.WPFApp.ViewModel
{
    public class ContactBookViewModel : ViewModelBase
    {
        private IContactService _service;
        private ObservableCollection<Contact> _contactList;
        private int _selectedContactIndex;
        private Contact _selectedContact;
        private string _searchString;
        private string _statusString;
        private bool _isEditing;

        public ContactBookViewModel(IContactService service)
        {
            if (service == null)
                throw new ArgumentNullException("service");

            _service = service;
            ContactList = new ObservableCollection<Contact>(_service.GetAll());
            SelectedContactIndex = -1;
            SelectedContact = new Contact();
            SearchString = string.Empty;
            StatusString = "All contacts were successfully loaded.";
            IsEditing = false;

            CmdAddContact = new RelayCommand(AddContact);
            CmdRemoveContact = new RelayCommand(RemoveContact);
            CmdEditContact = new RelayCommand(EditContact);
            CmdSaveContact = new RelayCommand(SaveContact);
            CmdCancel = new RelayCommand(CancelContactChanges);
        }

        public void AddContact()
        {
            SelectedContactIndex = -1;
            SelectedContact = new Contact();
            IsEditing = true;
        }

        public void RemoveContact()
        {
            if (_service.Remove(_selectedContact))
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
            if (_selectedContact.Id < 0)
            {
                if (_service.Add(_selectedContact))
                {
                    ContactList.Add(_selectedContact);
                    StatusString = "Contact successfully added.";
                }
                else
                    StatusString = "Contact failed to save. Please check the contact information for any errors.";
            }
            else
            {
                _service.Update(_selectedContact);
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
                _service.Reload(_selectedContact);
                int index = _selectedContactIndex;
                var list = _contactList;
                ContactList = null;
                ContactList = list;
                SelectedContactIndex = index;
            }

            IsEditing = false;
        }

        #region UIProperties
        public ICommand CmdAddContact { get; private set; }
        public ICommand CmdRemoveContact { get; private set; }
        public ICommand CmdEditContact { get; private set; }
        public ICommand CmdSaveContact { get; private set; }
        public ICommand CmdCancel { get; private set; }

        public ObservableCollection<Contact> ContactList
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
                        SelectedContact = new Contact();
                }
            }
        }

        public Contact SelectedContact
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
        #endregion
    }
}