using LearnThoseWords.Entities;
using System;
using System.Collections.Generic;

namespace LearnThoseWords.DataAccess
{
    public interface IWordRepository
    {
        IEnumerable<Word> GetAllWords();
        IEnumerable<Word> GetWordsByCriteria(Func<Word, bool> criteria);
        Word GetWordByCriteria(Func<Word, bool> criteria);
        void SaveWord(Word word);
        void DeleteWord(Word word);
    }
}
