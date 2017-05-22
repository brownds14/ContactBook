using ContactBook.Domain;

namespace ContactBook.DAL.Repositories
{
    public class EmailRepository : Repository<ContactBook.Domain.Email>, IEmailRepository
    {
        public EmailRepository(ContactsContext context) 
            : base(context)
        {
        }
    }
}