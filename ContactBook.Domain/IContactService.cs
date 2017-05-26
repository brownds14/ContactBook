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
        void DeleteAddress(Address a);
        void DeleteEmail(Email e);
        void DeleteGroup(Group g);
        void DeletePhone(Phone p);
    }
}