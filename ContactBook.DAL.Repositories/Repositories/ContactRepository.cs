using ContactBook.Domain;

namespace ContactBook.DAL.Repositories
{
    public class ContactRepository : Repository<ContactBook.Domain.Contact>, IContactRepository
    {
        public ContactRepository(ContactsContext context)
            : base(context)
        {
        }
    }
}