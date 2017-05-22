using ContactBook.Domain;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

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
            IsEditing = false;
        }

        public void CancelContactChanges()
        {

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