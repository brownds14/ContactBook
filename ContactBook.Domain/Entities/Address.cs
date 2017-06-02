namespace ContactBook.Domain
{
    public class Address
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int Line1MaxLength = 100;
        public static readonly int Line2MaxLength = 100;

        public Address()
        {
            Id = -1;
            Line1 = string.Empty;
            Line2 = string.Empty;
        }

        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }

        public virtual Contact Contact { get; set; }

        #region Validation
        public bool IsValidAddress()
        {
            return ValidLine1() && ValidLine2();
        }

        public bool ValidLine1()
        {
            return Line1.Length <= Line1MaxLength;
        }

        public bool ValidLine2()
        {
            return Line2.Length <= Line2MaxLength;
        }
        #endregion
    }
}
