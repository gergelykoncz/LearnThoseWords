using System.Data.Linq.Mapping;

namespace LearnThoseWords.Entities
{
    public class Word : ObservableEntity
    {
        private int _wordId;

        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
        public int WordId
        {
            get
            {
                return _wordId;
            }
            set
            {
                if (_wordId != value)
                {
                    NotifyPropertyChanging("WordId");
                    _wordId = value;
                    NotifyPropertyChanged("WordId");
                }
            }
        }

        private string _title;

        [Column]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                {
                    NotifyPropertyChanging("Title");
                    _title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _description;

        [Column]
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (_description != value)
                {
                    NotifyPropertyChanging("Description");
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private bool _isLocal;

        public bool IsLocal
        {
            get
            {
                return _isLocal;
            }
            set
            {
                if (_isLocal != value)
                {
                    NotifyPropertyChanging("IsLocal");
                    _isLocal = value;
                    NotifyPropertyChanged("IsLocal");
                }
            }
        }
    }
}
