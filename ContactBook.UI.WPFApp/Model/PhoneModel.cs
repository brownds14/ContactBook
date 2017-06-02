using ContactBook.Domain;
using System;

namespace ContactBook.UI.WPFApp.Model
{
    public class PhoneModel : NotifyErrors
    {
        private Phone _phone;
        private static string[] _typeList = Enum.GetNames(typeof(PhoneType));

        public PhoneModel()
            : this(new Phone())
        {
        }

        public PhoneModel(Phone p)
        {
            _phone = p;
        }

        public string Number
        {
            get { return _phone.Number; }
            set
            {
                string prop = "Number";
                string msg = $"Phone number must be less than {Phone.NumberMaxLength} characters.";
                string msg2 = "Phone number must consist of only numbers 0-9.";
                _phone.Number = value;
                ChangeError(() => _phone.ValidNumberLength(), prop, msg);
                ChangeError(() => _phone.ValidPhoneNumber(), prop, msg2);
            }
        }

        public int Type
        {
            get { return (int)_phone.Type; }
            set
            {
                _phone.Type = (PhoneType)value;
                RaisePropertyChanged("Type");
            }
        }

        public string[] TypeList
        {
            get { return _typeList; }
        }

        public Phone ToDomainPhone()
        {
            return _phone;
        }
    }
}
