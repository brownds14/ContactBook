using ContactBook.Domain;
using GalaSoft.MvvmLight;

namespace ContactBook.UI.WPFApp.Model
{
    public class AddressModel : ObservableObject
    {
        private Address _address;

        public AddressModel()
            : this(new Address())
        {
        }

        public AddressModel(Address address)
        {
            _address = address;
        }

        public int Id
        {
            get { return _address.Id; }
            set
            {
                _address.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string Line1
        {
            get { return _address.Line1; }
            set
            {
                _address.Line1 = value;
                RaisePropertyChanged("Line1");
            }
        }

        public string Line2
        {
            get { return _address.Line2; }
            set
            {
                _address.Line2 = value;
                RaisePropertyChanged("Line2");
            }
        }

        public Address ToDomainAddress()
        {
            return _address;
        }
    }
}
