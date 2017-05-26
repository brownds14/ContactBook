using ContactBook.Domain;
using GalaSoft.MvvmLight;

namespace ContactBook.UI.WPFApp.Model
{
    public class GroupModel : ObservableObject
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

        public int Id
        {
            get { return _group.Id; }
            set
            {
                _group.Id = value;
                RaisePropertyChanged("Id");
            }
        }

        public string GroupName
        {
            get { return _group.GroupName; }
            set
            {
                _group.GroupName = value;
                RaisePropertyChanged("GroupName");
            }
        }

        public Group ToDomainGroup()
        {
            return _group;
        }
    }
}
