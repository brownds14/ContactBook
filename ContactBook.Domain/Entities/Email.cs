using System.Text.RegularExpressions;

namespace ContactBook.Domain
{
    public class Email
    {      
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int EmailAddrMaxLength = 100;
        private static readonly string _emailRegex = @"^\w+@\w+\.\w+$";
        private static Regex _reg = new Regex(_emailRegex);

        public Email()
        {
            Id = -1;
            EmailAddr = string.Empty;
            Contact = null;
        }

        public int Id { get; set; }
        public string EmailAddr { get; set; }

        public virtual Contact Contact { get; set; }

        #region Validation
        public bool IsValidEmail()
        {
            return ValidEmailAddrLength() && ValidEmailAddr();
        }

        public bool ValidEmailAddrLength()
        {
            return EmailAddr.Length <= EmailAddrMaxLength;
        }

        public bool ValidEmailAddr()
        {
            return _reg.IsMatch(EmailAddr);
        }
        #endregion
    }
}
