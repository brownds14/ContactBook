using ContactBook.Domain;

namespace ContactBook.UI.WPFApp.Model
{
    public class GroupModel : NotifyErrors
    {
        private Group _group;

        public GroupModel()
            : this(new Group())
        {
        }

        public GroupModel(Group g)
        {
            _group = g;
        }

        public string GroupName
        {
            get { return _group.GroupName; }
            set
            {
                string prop = "GroupName";
                string msg = $"The name of the group must be less than {Group.GroupNameMaxLength} characters.";
                _group.GroupName = value;
                ChangeError(() => _group.ValidGroupName(), prop, msg);
            }
        }

        public Group ToDomainGroup()
        {
            return _group;
        }
    }
}
