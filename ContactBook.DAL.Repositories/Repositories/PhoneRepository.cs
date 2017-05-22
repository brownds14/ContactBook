using ContactBook.Domain;

namespace ContactBook.DAL.Repositories
{
    public class PhoneRepository : Repository<ContactBook.Domain.Phone>, IPhoneRepository
    {
        public PhoneRepository(ContactsContext context)
            : base(context)
        {
        }
    }
}