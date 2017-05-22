using ContactBook.Domain;
using System.Data.Entity;

namespace ContactBook.DAL.Repositories
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(string connString)
            : base(connString)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Address
            builder.Entity<Address>().Property(x => x.Line1).HasMaxLength(Address.Line1MaxLength);
            builder.Entity<Address>().Property(x => x.Line2).HasMaxLength(Address.Line2MaxLength);

            //Contact
            builder.Entity<Contact>().Property(x => x.FirstName).HasMaxLength(Contact.FirstNameMaxLength);
            builder.Entity<Contact>().Property(x => x.MiddleName).HasMaxLength(Contact.MiddleNameMaxLength);
            builder.Entity<Contact>().Property(x => x.LastName).HasMaxLength(Contact.LastNameMaxLength);
            builder.Entity<Contact>().Property(x => x.Notes).HasMaxLength(Contact.NotesMaxLength);

            //Email
            builder.Entity<Email>().Property(x => x.EmailAddr).HasMaxLength(Email.EmailAddrMaxLength);

            //Group
            builder.Entity<Group>().Property(x => x.GroupName).HasMaxLength(Group.GroupNameMaxLength);

            //Phone
            builder.Entity<Phone>().Property(x => x.Number).HasMaxLength(Phone.NumberMaxLength);
        }
    }
}
