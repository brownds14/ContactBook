using ContactBook.Domain;
using GalaSoft.MvvmLight;

namespace ContactBook.UI.WPFApp.Model
{
    public class PhoneModel : ObservableObject
    {
        private Phone _phone;

        public PhoneModel()
            : this(new Phone())
        {
        }

        public PhoneModel(Phone p)
        {
            _phone = p;
        }

        public int Id
        {
            get { return _phone.Id; }
            set
            {
                _phone.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Number
        {
            get { return _phone.Number; }
            set
            {
                _phone.Number = value;
                RaisePropertyChanged("Number");
            }
        }

        public PhoneType Type
        {
            get { return _phone.Type; }
            set
            {
                _phone.Type = value;
                RaisePropertyChanged("Type");
            }
        }

        public Phone ToDomainPhone()
        {
            return _phone;
        }
    }
}
