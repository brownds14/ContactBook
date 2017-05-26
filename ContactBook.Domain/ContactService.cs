using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

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
            ((List<Address>)c.Addresses).RemoveAll(a => a.Id == -1);
            foreach (var a in c.Addresses)
            {
                _unit.Addresses.Reload(a);
            }

            ((List<Email>)c.Emails).RemoveAll(e => e.Id == -1);
            foreach (var e in c.Emails)
            {
                _unit.Emails.Reload(e);
            }

            ((List<Group>)c.Groups).RemoveAll(g => g.Id == -1);
            foreach (var g in c.Groups)
            {
                _unit.Groups.Reload(g);
            }

            ((List<Phone>)c.Phones).RemoveAll(p => p.Id == -1);
            foreach (var p in c.Phones)
            {
                _unit.Phones.Reload(p);
            }

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
