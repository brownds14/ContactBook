using System;
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

            Errors = new Dictionary<string, string>();
            Addresses = new List<Address>();
            Emails = new List<Email>();
            Groups = new List<Group>();
            Phones = new List<Phone>();
        }

        public Dictionary<string, string> Errors { get; private set; }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }

        private void AddError(string key, string value)
        {
            if (!Errors.ContainsKey(key))
                Errors.Add(key, value);
        }

        private void RemoveError(string key)
        {
            if (Errors.ContainsKey(key))
                Errors.Remove(key);
        }

        public void ValidateContact()
        {
            ValidateFirstName();
            ValidateMiddleName();
            ValidateLastName();
            ValidateNotes();
        }

        public bool IsValidContact()
        {
            ValidateContact();
            return Errors.Count == 0;
        }

        public bool ValidateFirstName()
        {
            if (FirstName.Length <= FirstNameMaxLength)
            {
                RemoveError("FirstName");
                return true;
            }
            else
            {
                AddError("FirstName", $"First name needs to be less than {FirstNameMaxLength} characters");
                return false;
            }
        }

        public bool ValidateMiddleName()
        {
            if (MiddleName.Length <= MiddleNameMaxLength)
            {
                RemoveError("MiddleName");
                return true;
            }
            else
            {
                AddError("MiddleName", $"Middle name needs to be less than {MiddleNameMaxLength} characters");
                return false;
            }
        }

        public bool ValidateLastName()
        {
            if (LastName.Length <= LastNameMaxLength)
            {
                RemoveError("LastName");
                return true;
            }
            else
            {
                AddError("LastName", $"Last name needs to be less than {LastNameMaxLength} characters");
                return false;
            }
        }

        public bool ValidateNotes()
        {
            if (Notes.Length <= NotesMaxLength)
            {
                RemoveError("Notes");
                return true;
            }
            else
            {
                AddError("Notes", $"Notes needs to be less than {NotesMaxLength} characters");
                return false;
            }
        }
    }
}