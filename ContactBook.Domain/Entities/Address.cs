namespace ContactBook.Domain
{
    public class Address
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int Line1MaxLength = 100;
        public static readonly int Line2MaxLength = 100;

        public int Id { get; private set; }
        public string Line1 { get; private set; }
        public string Line2 { get; private set; }
    }
}
