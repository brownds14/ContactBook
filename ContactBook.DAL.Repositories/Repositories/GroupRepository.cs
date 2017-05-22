using ContactBook.Domain;

namespace ContactBook.DAL.Repositories
{
    public class GroupRepository : Repository<ContactBook.Domain.Group>, IGroupRepository
    {
        public GroupRepository(ContactsContext context)
            : base(context)
        {
        }
    }
}