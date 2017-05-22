namespace ContactBook.Domain
{
    public enum PhoneType
    {
        Home,
        Work,
        Mobile,
        Other
    }

    public class Phone
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int NumberMaxLength = 10;

        public int Id { get; set; }
        public string Number { get; set; }
        public PhoneType Type { get; set; }
    }
}
