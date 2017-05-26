using ContactBook.Domain;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Specialized;

namespace ContactBook.UI.WPFApp.Model
{
    public class ContactModel : ObservableObject
    {
        private Contact _contact;
        private ObservableCollection<Address> _addresses;
        private ObservableCollection<EmailModel> _emails;
        private ObservableCollection<GroupModel> _groups;
        private ObservableCollection<PhoneModel> _phones;

        public ContactModel()
            : this(new Contact())
        {
        }

        public ContactModel(Contact c)
        {
            _contact = c;

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

        private void Groups_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var group in e.NewItems.Cast<GroupModel>())
                    {
                        _contact.Groups.Add(group.ToDomainGroup());
                    }
                    RaisePropertyChanged("Groups");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var group in e.OldItems.Cast<GroupModel>())
                    {
                        _contact.Groups.Remove(group.ToDomainGroup());
                    }
                    RaisePropertyChanged("Groups");
                    break;
                default:
                    break;
            }
        }

        private void Phones_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var phone in e.NewItems.Cast<PhoneModel>())
                    {
                        _contact.Phones.Add(phone.ToDomainPhone());
                    }
                    RaisePropertyChanged("Phones");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var phone in e.OldItems.Cast<PhoneModel>())
                    {
                        _contact.Phones.Remove(phone.ToDomainPhone());
                    }
                    RaisePropertyChanged("Phones");
                    break;
                default:
                    break;
            }
        }

        private void Emails_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var email in e.NewItems.Cast<EmailModel>())
                    {
                        _contact.Emails.Add(email.ToDomainEmail());
                    }
                    RaisePropertyChanged("Emails");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var email in e.OldItems.Cast<EmailModel>())
                    {
                        _contact.Emails.Remove(email.ToDomainEmail());
                    }
                    RaisePropertyChanged("Emails");
                    break;
                default:
                    break;
            }
        }

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
                _contact.FirstName = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string MiddleName
        {
            get { return _contact.MiddleName; }
            set
            {
                _contact.MiddleName = value;
                RaisePropertyChanged("MiddleName");
            }
        }

        public string LastName
        {
            get { return _contact.LastName; }
            set
            {
                _contact.LastName = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Notes
        {
            get { return _contact.Notes; }
            set
            {
                _contact.Notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        //public ObservableCollection<Address> Addresses
        //{
        //    get { return  }
        //    set { Set(() => Addresses, ref _addresses, value); }
        //}

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

        public Contact ToDomainContact()
        {
            return _contact;
        }
    }
}
