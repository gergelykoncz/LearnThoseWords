using LearnThoseWords.Entities;
using System;

namespace LearnThoseWords.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        private bool _showThisPage;
        public bool ShowThisPage
        {
            get
            {
                return _showThisPage;
            }
            set
            {
                if (_showThisPage != value)
                {
                    NotifyPropertyChanging("ShowThisPage");
                    _showThisPage = value;
                    NotifyPropertyChanged("ShowThisPage");
                }
            }
        }

        public override void Initialize()
        {
            if (MoveForward != null)
            {
                MoveForward(this, EventArgs.Empty);
            }
        }

        public event EventHandler MoveForward;
    }
}
