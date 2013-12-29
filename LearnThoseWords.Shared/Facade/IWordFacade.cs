using LearnThoseWords.Shared.Entities;
using System.Collections.Generic;

namespace LearnThoseWords.Shared.Facade
{
    public interface IWordFacade
    {
        IWord GetWord(int wordId);
        IEnumerable<IWord> GetAllWords();
        void SaveWord(IWord word);
        void DeleteWord(IWord word);
    }
}
