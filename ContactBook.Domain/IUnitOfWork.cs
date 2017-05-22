using System;

namespace ContactBook.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        IContactRepository Contacts { get; }
        IEmailRepository Emails { get; }
        IGroupRepository Groups { get; }
        IPhoneRepository Phones { get; }
        void Complete();
    }
}
