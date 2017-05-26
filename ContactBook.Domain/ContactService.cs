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

        public void DeleteAddress(Address a)
        {
            _unit.Addresses.Remove(a);
        }

        public void DeleteEmail(Email e)
        {
            _unit.Emails.Remove(e);
        }

        public void DeleteGroup(Group g)
        {
            _unit.Groups.Remove(g);
        }

        public void DeletePhone(Phone p)
        {
            _unit.Phones.Remove(p);
        }

        public IEnumerable<Contact> Find(Expression<Func<Contact, bool>> pred)
        {
            return _unit.Contacts.Find(pred);
        }

        public Contact Get(int id)
        {
            return _unit.Contacts.Get(id);
        }

        public IEnumerable<Contact> GetAll()
        {
            return _unit.Contacts.GetAll();
        }

        public void Reload(Contact c)
        {
            _unit.Contacts.Reload(c);
        }

        public bool Remove(Contact c)
        {
            _unit.Contacts.Remove(c);
            _unit.Complete();
            return true;
        }

        public void Update(Contact c)
        {
            _unit.Contacts.Update(c);
            _unit.Complete();
        }
    }
}
