using LearnThoseWords.BusinessLayer.Facade;
using LearnThoseWords.Entities;

namespace LearnThoseWords.ViewModels
{
    public class SaveWordViewModel : ViewModelBase
    {
        private readonly IWordFacade _wordFacade;

        private Word _word;
        public Word Word
        {
            get
            {
                return _word;
            }
            set
            {
                if (_word != value)
                {
                    NotifyPropertyChanging("Word");
                    _word = value;
                    NotifyPropertyChanged("Word");
                }
            }
        }


        public SaveWordViewModel(IWordFacade wordFacade)
        {
            this._wordFacade = wordFacade;
        }

        public void Initialize(int wordId)
        {
            Word = _wordFacade.GetWord(wordId);
        }
    }
}
