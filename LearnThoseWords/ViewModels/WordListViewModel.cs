using LearnThoseWords.Shared.Entities;
using LearnThoseWords.Shared.Facade;
using System.Collections.ObjectModel;

namespace LearnThoseWords.ViewModels
{
    public class WordListViewModel : ViewModelBase
    {
        private readonly IWordFacade _wordFacade;

        public WordListViewModel(IWordFacade wordFacade)
        {
            this._wordFacade = wordFacade;
        }

        private ObservableCollection<IWord> _wordList;
        public ObservableCollection<IWord> WordList
        {
            get
            {
                return _wordList;
            }
            set
            {
                if (_wordList != value)
                {
                    NotifyPropertyChanging("WordList");
                    _wordList = value;
                    NotifyPropertyChanged("WordList");
                }
            }
        }

        public override void Initialize()
        {
            var words = _wordFacade.GetAllWords();
            WordList = new ObservableCollection<IWord>(words);
        }
    }
}
