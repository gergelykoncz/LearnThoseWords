using LearnThoseWords.Shared.Entities;
using System;
using System.Data.Linq.Mapping;

namespace LearnThoseWords.Entities
{
    [Table]
    public class Word : ObservableEntity, IWord
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

        private string _definition;

        [Column]
        public string Definition
        {
            get
            {
                return _definition;
            }
            set
            {
                if (_definition != value)
                {
                    NotifyPropertyChanging("Definition");
                    _definition = value;
                    NotifyPropertyChanged("Definition");
                }
            }
        }

        private DateTime _dateAdded;

        [Column]
        public DateTime DateAdded
        {
            get
            {
                return _dateAdded;
            }
            set
            {
                if (_dateAdded != value)
                {
                    NotifyPropertyChanging("DateAdded");
                    _dateAdded = value;
                    NotifyPropertyChanged("DateAdded");
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
