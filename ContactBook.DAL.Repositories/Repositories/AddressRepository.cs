using ContactBook.Domain;

namespace ContactBook.DAL.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(ContactsContext context) 
            : base(context)
        {
        }
    }
}