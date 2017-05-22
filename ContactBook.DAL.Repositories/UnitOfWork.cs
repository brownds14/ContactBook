using ContactBook.Domain;
using System;

namespace ContactBook.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactsContext _context;
        private bool _disposed = false;

        public UnitOfWork(ContactsContext context,
            IAddressRepository addresses,
            IContactRepository contacts,
            IEmailRepository emails,
            IGroupRepository groups,
            IPhoneRepository phones)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            if (addresses == null)
                throw new ArgumentNullException("addresses");
            if (contacts == null)
                throw new ArgumentNullException("contacts");
            if (emails == null)
                throw new ArgumentNullException("emails");
            if (groups == null)
                throw new ArgumentNullException("groups");
            if (phones == null)
                throw new ArgumentNullException("phones");

            _context = context;
            Addresses = addresses;
            Contacts = contacts;
            Emails = emails;
            Groups = groups;
            Phones = phones;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public IAddressRepository Addresses { get; private set; }
        public IContactRepository Contacts { get; private set; }
        public IEmailRepository Emails { get; private set; }
        public IGroupRepository Groups { get; private set; }
        public IPhoneRepository Phones { get; private set; }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
    }
}
