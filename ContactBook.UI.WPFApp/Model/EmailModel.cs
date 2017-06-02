using ContactBook.Domain;

namespace ContactBook.UI.WPFApp.Model
{
    public class EmailModel : NotifyErrors
    {
        private Email _email;

        public EmailModel()
            : this(new Email())
        {
        }

        public EmailModel(Email e)
        {
            _email = e;
        }

        public string EmailAddr
        {
            get { return _email.EmailAddr; }
            set
            {
                string prop = "EmailAddr";
                string msg = $"Email address must be less than {Email.EmailAddrMaxLength} characters.";
                string msg2 = "Email does not appear to be a valid format.";
                _email.EmailAddr = value;

                ChangeError(() => _email.ValidEmailAddrLength(), prop, msg);
                ChangeError(() => _email.ValidEmailAddr(), prop, msg2);
            }
        }

        public Email ToDomainEmail()
        {
            return _email;
        }
    }
}
