using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook.Domain
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> Find(Expression<Func<Contact, bool>> pred);
        bool Add(Contact c);
        bool Remove(Contact c);
        Contact Get(int id);
    }
}