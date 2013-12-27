using LearnThoseWords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnThoseWords.DataAccess
{
    public class DbWordRepository : IWordRepository
    {
        private readonly WordDataContext _dataContext;

        public DbWordRepository(WordDataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public IEnumerable<Word> GetAllWords()
        {
            return _dataContext.Words;
        }

        public IEnumerable<Word> GetWordsByCriteria(Func<Word, bool> criteria)
        {
            return _dataContext.Words.Where(criteria);
        }

        public Word GetWordByCriteria(Func<Word, bool> criteria)
        {
            return _dataContext.Words.FirstOrDefault(criteria);
        }

        public void SaveWord(Word word)
        {
            //New word, it has the default zero ID, store it.
            if (word.WordId == 0)
            {
                _dataContext.Words.InsertOnSubmit(word);
                _dataContext.SubmitChanges();
            }
            //Existing word, update the properties one by one on the original.
            else
            {
                Word originalWord = GetWordByCriteria(x => x.WordId == word.WordId);
                if (originalWord != null)
                {
                    originalWord.Description = word.Description;
                    originalWord.Title = word.Title;

                    _dataContext.SubmitChanges();
                }
            }
        }

        public void DeleteWord(Word word)
        {
            _dataContext.Words.DeleteOnSubmit(word);
            _dataContext.SubmitChanges();
        }
    }
}
