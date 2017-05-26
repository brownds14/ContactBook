namespace ContactBook.Domain
{
    public class Email
    {      
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int EmailAddrMaxLength = 100;

        public Email()
        {
            Id = -1;
            EmailAddr = string.Empty;
            Contact = null;
        }

        public int Id { get; set; }
        public string EmailAddr { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
