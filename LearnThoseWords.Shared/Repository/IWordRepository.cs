using LearnThoseWords.Shared.Entities;
using System;
using System.Collections.Generic;

namespace LearnThoseWords.Shared.Repository
{
    public interface IWordRepository
    {
        IEnumerable<IWord> GetAllWords();
        IEnumerable<IWord> GetWordsByCriteria(Func<IWord, bool> criteria);
        IWord GetWordByCriteria(Func<IWord, bool> criteria);
        void SaveWord(IWord word);
        void DeleteWord(IWord word);
    }
}
