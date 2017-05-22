namespace ContactBook.Domain
{
    public class Group
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int GroupNameMaxLength = 20;

        public int Id { get; set; }
        public string GroupName { get; set; }
    }
}
