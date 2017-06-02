namespace ContactBook.Domain
{
    public class Group
    {
        //Decreasing MaxLengths will create issues with existing data 
        public static readonly int GroupNameMaxLength = 20;

        public Group()
        {
            Id = -1;
            GroupName = string.Empty;
        }

        public int Id { get; set; }
        public string GroupName { get; set; }

        public virtual Contact Contact { get; set; }

        public bool IsValidGroup()
        {
            return ValidGroupName();
        }

        public bool ValidGroupName()
        {
            return GroupName.Length <= GroupNameMaxLength;
        }
    }
}
