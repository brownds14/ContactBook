﻿namespace ContactBook.Domain
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
    }
}
