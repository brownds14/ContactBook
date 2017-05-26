using ContactBook.Domain;
using GalaSoft.MvvmLight;

namespace ContactBook.UI.WPFApp.Model
{
    public class EmailModel : ObservableObject
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

        public int Id
        {
            get { return _email.Id; }
            set
            {
                _email.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string EmailAddr
        {
            get { return _email.EmailAddr; }
            set
            {
                _email.EmailAddr = value;
                RaisePropertyChanged("EmailAddr");
            }
        }

        public Email ToDomainEmail()
        {
            return _email;
        }
    }
}
