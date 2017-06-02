using ContactBook.Domain;

namespace ContactBook.UI.WPFApp.Model
{
    public class AddressModel : NotifyErrors
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

        public string Line1
        {
            get { return _address.Line1; }
            set
            {
                string prop = "Line1";
                string msg = $"Address line 1 must be less than {Address.Line1MaxLength} characters.";
                _address.Line1 = value;
                ChangeError(() => _address.ValidLine1(), prop, msg);
            }
        }

        public string Line2
        {
            get { return _address.Line2; }
            set
            {
                string prop = "Line2";
                string msg = $"Address line 2 must be less than {Address.Line2MaxLength} characters.";
                _address.Line2 = value;
                ChangeError(() => _address.ValidLine2(), prop, msg);
            }
        }

        public Address ToDomainAddress()
        {
            return _address;
        }
    }
}
