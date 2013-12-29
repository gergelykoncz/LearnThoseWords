using LearnThoseWords.Shared.Entities;
using LearnThoseWords.Shared.Facade;
using System.Collections.ObjectModel;

namespace LearnThoseWords.ViewModels
{
    public class WordDeckViewModel : ViewModelBase
    {
        private readonly IWordFacade _wordFacade;

        private ObservableCollection<IWord> _words;
        public ObservableCollection<IWord> Words
        {
            get
            {
                return _words;
            }
            set
            {
                if (_words != value)
                {
                    NotifyPropertyChanging("Words");
                    _words = value;
                    NotifyPropertyChanged("Words");
                }
            }
        }

        public WordDeckViewModel(IWordFacade wordFacade)
        {
            this._wordFacade = wordFacade;
        }

        public override void Initialize()
        {
            var words = _wordFacade.GetAllWords();
            Words = new ObservableCollection<IWord>(words);
        }
    }
}
