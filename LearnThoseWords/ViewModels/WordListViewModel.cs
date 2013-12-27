using LearnThoseWords.BusinessLayer.Facade;
using LearnThoseWords.Entities;
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

        private ObservableCollection<Word> _wordList;
        public ObservableCollection<Word> WordList
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
            WordList = new ObservableCollection<Word>(words);
        }
    }
}
