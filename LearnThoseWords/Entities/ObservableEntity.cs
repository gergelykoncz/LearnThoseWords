using System.ComponentModel;

namespace LearnThoseWords.Entities
{
    public abstract class ObservableEntity : INotifyPropertyChanged, INotifyPropertyChanging
    {
        protected void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        protected void NotifyPropertyChanging(string name)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    }
}