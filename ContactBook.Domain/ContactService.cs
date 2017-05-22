using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ContactBook.Domain
{
    public class ContactService : IContactService
    {
        private IUnitOfWork _unit;

        public ContactService(IUnitOfWork unit)
        {
            if (unit == null)
                throw new ArgumentNullException("unit");

            _unit = unit;
        }

        public bool Add(Contact c)
        {
            if (c.IsValidContact())
            {
                _unit.Contacts.Add(c);
                _unit.Complete();
                return true;
            }
            else
                return false;
        }

        public IEnumerable<Contact> Find(Expression<Func<Contact, bool>> pred)
        {
            return _unit.Contacts.Find(pred);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _unit.Contacts.GetAll();
        }

        public bool Remove(Contact c)
        {
            _unit.Contacts.Remove(c);
            _unit.Complete();
            return true;
        }
    }
}
