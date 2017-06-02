using System.Collections.Generic;

namespace ContactBook.Domain
{
    public class Contact
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int FirstNameMaxLength = 100;
        public static readonly int MiddleNameMaxLength = 100;
        public static readonly int LastNameMaxLength = 100;
        public static readonly int NotesMaxLength = 2500;

        public Contact()
        {
            Id = -1;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            LastName = string.Empty;
            Notes = string.Empty;

            Addresses = new List<Address>();
            Emails = new List<Email>();
            Groups = new List<Group>();
            Phones = new List<Phone>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }

        #region Validation
        public bool IsValidContact()
        {
            bool valid = true;
            valid =  ValidFirstName() && 
                ValidMiddleName() &&
                ValidLastName() &&
                ValidNotes();

            if (!valid)
                return valid;

            foreach (var a in Addresses)
            {
                if (!a.IsValidAddress())
                    return false;
            }

            foreach (var e in Emails)
            {
                if (!e.IsValidEmail())
                    return false;
            }

            foreach (var g in Groups)
            {
                if (!g.IsValidGroup())
                    return false;
            }

            foreach (var p in Phones)
            {
                if (!p.IsValidPhone())
                    return false;
            }

            return valid;
        }

        public bool ValidFirstName()
        {
            return FirstName.Length <= FirstNameMaxLength;
        }

        public bool ValidMiddleName()
        {
            return MiddleName.Length <= MiddleNameMaxLength;
        }

        public bool ValidLastName()
        {
            return LastName.Length <= LastNameMaxLength;
        }

        public bool ValidNotes()
        {
            return Notes.Length <= NotesMaxLength;
        }
        #endregion
    }
}