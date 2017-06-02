using ContactBook.Domain;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ContactBook.UI.WPFApp.Model
{
    public class ContactModel : NotifyErrors
    {
        private Contact _contact;
        private ObservableCollection<AddressModel> _addresses;
        private ObservableCollection<EmailModel> _emails;
        private ObservableCollection<GroupModel> _groups;
        private ObservableCollection<PhoneModel> _phones;

        private delegate void CollectionFunc(object obj);

        public ContactModel()
            : this(new Contact())
        {
        }

        public ContactModel(Contact c)
        {
            _contact = c;

            Addresses = new ObservableCollection<AddressModel>();
            foreach (var e in c.Addresses)
            {
                Addresses.Add(new AddressModel(e));
            }
            Addresses.CollectionChanged += Addresses_CollectionChanged;

            Emails = new ObservableCollection<EmailModel>();
            foreach (var e in c.Emails)
            {
                Emails.Add(new EmailModel(e));
            }
            Emails.CollectionChanged += Emails_CollectionChanged;

            Groups = new ObservableCollection<GroupModel>();
            foreach (var g in c.Groups)
            {
                Groups.Add(new GroupModel(g));
            }
            Groups.CollectionChanged += Groups_CollectionChanged;

            Phones = new ObservableCollection<PhoneModel>();
            foreach (var p in c.Phones)
            {
                Phones.Add(new PhoneModel(p));
            }
            Phones.CollectionChanged += Phones_CollectionChanged;
        }

        #region CollectionChanged Methods
        private void CollectionChanged(NotifyCollectionChangedEventArgs e, string collection, CollectionFunc add, CollectionFunc remove)
        {
            bool raiseChange = false;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var x in e.NewItems)
                    {
                        add(x);
                    }
                    raiseChange = true;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var x in e.OldItems)
                    {
                        remove(x);
                    }
                    raiseChange = true;
                    break;
                default:
                    break;
            }

            if (raiseChange)
                RaisePropertyChanged(collection);
        }

        private void Addresses_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionFunc add = (x) => _contact.Addresses.Add(((AddressModel)x).ToDomainAddress());
            CollectionFunc remove = (x) => _contact.Addresses.Remove(((AddressModel)x).ToDomainAddress());
            CollectionChanged(e, "Addresses", add, remove);
        }

        private void Emails_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionFunc add = (x) => _contact.Emails.Add(((EmailModel)x).ToDomainEmail());
            CollectionFunc remove = (x) => _contact.Emails.Remove(((EmailModel)x).ToDomainEmail());
            CollectionChanged(e, "Emails", add, remove);
        }

        private void Groups_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionFunc add = (x) => _contact.Groups.Add(((GroupModel)x).ToDomainGroup());
            CollectionFunc remove = (x) => _contact.Groups.Remove(((GroupModel)x).ToDomainGroup());
            CollectionChanged(e, "Groups", add, remove);
        }

        private void Phones_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionFunc add = (x) => _contact.Phones.Add(((PhoneModel)x).ToDomainPhone());
            CollectionFunc remove = (x) => _contact.Phones.Remove(((PhoneModel)x).ToDomainPhone());
            CollectionChanged(e, "Phones", add, remove);
        }
        #endregion

        #region Wrapped Properties
        public int Id
        {
            get { return _contact.Id; }
            set
            {
                _contact.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return _contact.FirstName; }
            set
            {
                string prop = "FirstName";
                string msg = $"First name must be less than {Contact.FirstNameMaxLength} characters.";
                _contact.FirstName = value;
                ChangeError(() => _contact.ValidFirstName(), prop, msg);
            }
        }

        public string MiddleName
        {
            get { return _contact.MiddleName; }
            set
            {
                string prop = "MiddleName";
                string msg = $"Middle name must be less than {Contact.MiddleNameMaxLength} characters.";
                _contact.MiddleName = value;
                ChangeError(() => _contact.ValidMiddleName(), prop, msg);
            }
        }

        public string LastName
        {
            get { return _contact.LastName; }
            set
            {
                string prop = "LastName";
                string msg = $"Last name must be less than {Contact.LastNameMaxLength} characters.";
                ChangeError(() => _contact.ValidLastName(), prop, msg);
            }
        }

        public string Notes
        {
            get { return _contact.Notes; }
            set
            {
                string prop = "Notes";
                string msg = $"Notes must be less than {Contact.NotesMaxLength} characters.";
                _contact.Notes = value;
                ChangeError(() => _contact.ValidNotes(), prop, msg);
            }
        }

        public ObservableCollection<AddressModel> Addresses
        {
            get { return _addresses; }
            set
            {
                _addresses = value;
                RaisePropertyChanged("Addresses");
            }
        }

        public ObservableCollection<EmailModel> Emails
        {
            get { return _emails; }
            set
            {
                _emails = value;
                RaisePropertyChanged("Emails");
            }
        }

        public ObservableCollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
                RaisePropertyChanged("Groups");
            }
        }

        public ObservableCollection<PhoneModel> Phones
        {
            get { return _phones; }
            set
            {
                _phones = value;
                RaisePropertyChanged("Phones");
            }
        }
        #endregion

        public Contact ToDomainContact()
        {
            return _contact;
        }
    }
}
