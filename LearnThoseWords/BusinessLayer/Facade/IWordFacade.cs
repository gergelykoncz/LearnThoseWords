using LearnThoseWords.Entities;
using System.Collections.Generic;

namespace LearnThoseWords.BusinessLayer.Facade
{
    public interface IWordFacade
    {
        IEnumerable<Word> GetAllWords();
        void SaveWord(Word word);
        void DeleteWord(Word word);
    }
}
