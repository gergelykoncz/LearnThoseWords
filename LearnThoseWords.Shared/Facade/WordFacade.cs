using LearnThoseWords.Shared.Entities;
using LearnThoseWords.Shared.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LearnThoseWords.Shared.Facade
{
    public class WordFacade : IWordFacade
    {
        private readonly IWordRepository _repository;

        public WordFacade(IWordRepository repository)
        {
            this._repository = repository;
        }

        public IWord GetWord(int wordId)
        {
            return _repository.GetWordByCriteria(x => x.WordId == wordId);
        }

        public IEnumerable<IWord> GetAllWords()
        {
            return _repository.GetAllWords()
                .OrderByDescending(x => x.DateAdded);
        }

        public void SaveWord(IWord word)
        {
            _repository.SaveWord(word);
        }

        public void DeleteWord(IWord word)
        {
            _repository.DeleteWord(word);
        }
    }
}
