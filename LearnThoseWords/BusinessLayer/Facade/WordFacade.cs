using LearnThoseWords.DataAccess;
using LearnThoseWords.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LearnThoseWords.BusinessLayer.Facade
{
    public class WordFacade : IWordFacade
    {
        private readonly IWordRepository _repository;

        public WordFacade(IWordRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Word> GetAllWords()
        {
            return _repository.GetAllWords()
                .OrderByDescending(x => x.DateAdded);
        }

        public void SaveWord(Word word)
        {
            _repository.SaveWord(word);
        }

        public void DeleteWord(Word word)
        {
            _repository.DeleteWord(word);
        }
    }
}
