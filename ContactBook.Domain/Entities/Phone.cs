using System.Text.RegularExpressions;

namespace ContactBook.Domain
{
    public enum PhoneType
    {
        Home,
        Work,
        Mobile,
        Other
    }

    public class Phone
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int NumberMaxLength = 10;
        private static readonly string _phoneRegex = "^[0-9]+$";
        private static Regex _reg = new Regex(_phoneRegex);

        public Phone()
        {
            Id = -1;
            Number = string.Empty;
            Type = PhoneType.Mobile;
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }

        public virtual Contact Contact { get; set; }

        public bool IsValidPhone()
        {
            return ValidNumberLength() && ValidPhoneNumber();
        }

        public bool ValidNumberLength()
        {
            return Number.Length <= NumberMaxLength;
        }

        public bool ValidPhoneNumber()
        {
            return _reg.IsMatch(Number);
        }
    }
}
