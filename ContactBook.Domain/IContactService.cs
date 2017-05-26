using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ContactBook.Domain
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll();
        IEnumerable<Contact> Find(Expression<Func<Contact, bool>> pred);
        bool Add(Contact c);
        bool Remove(Contact c);
        Contact Get(int id);
        void Update(Contact c);
        void Reload(Contact c);
        void DeleteEmail(Email e);
        void DeletePhone(Phone p);
    }
}