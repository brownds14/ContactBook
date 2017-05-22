namespace ContactBook.Domain
{
    public class Email
    {      
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int EmailAddrMaxLength = 100;

        public int Id { get; set; }
        public string EmailAddr { get; set; }
    }
}
