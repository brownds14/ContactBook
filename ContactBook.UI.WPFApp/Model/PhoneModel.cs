using ContactBook.Domain;
using GalaSoft.MvvmLight;
using System;

namespace ContactBook.UI.WPFApp.Model
{
    public class PhoneModel : ObservableObject
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
