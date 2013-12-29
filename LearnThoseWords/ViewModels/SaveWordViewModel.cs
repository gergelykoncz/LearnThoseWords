using LearnThoseWords.Entities;
using LearnThoseWords.Resources;
using LearnThoseWords.Shared.Entities;
using LearnThoseWords.Shared.Facade;
using System.Windows;

namespace LearnThoseWords.ViewModels
{
    public class SaveWordViewModel : ViewModelBase
    {
        private readonly IWordFacade _wordFacade;
        private readonly IWordDefinitionFacade _wordDefinitionFacade;

        private IWord _word;
        public IWord Word
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

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    NotifyPropertyChanging("IsBusy");
                    _isBusy = value;
                    NotifyPropertyChanged("IsBusy");
                }
            }
        }

        public SaveWordViewModel(IWordFacade wordFacade,
            IWordDefinitionFacade wordDefinitionFacade)
        {
            this._wordFacade = wordFacade;
            this._wordDefinitionFacade = wordDefinitionFacade;
        }

        public override void Initialize()
        {
            Word = new Word();
        }

        public void Initialize(int wordId)
        {
            Word = _wordFacade.GetWord(wordId);
        }

        public void SaveWord()
        {
            _wordFacade.SaveWord(Word);
        }

        public void DeleteWord()
        {
            _wordFacade.DeleteWord(Word);
        }

        public async void GetDefinition()
        {
            if (string.IsNullOrWhiteSpace(Word.Title) == false)
            {
                try
                {
                    IsBusy = true;
                    Word.Definition = await _wordDefinitionFacade.GetDefinition(Word.Title);
                }
                catch
                {
                    MessageBox.Show(AppResources.SaveWordPageWordnikConnectionErrorMessage, AppResources.SaveWordPageWordnikConnectionErrorCaption, MessageBoxButton.OK);
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }
    }
}
