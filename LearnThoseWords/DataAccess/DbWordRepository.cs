using LearnThoseWords.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnThoseWords.DataAccess
{
    public class DbWordRepository : IWordRepository
    {
        private readonly WordDataContext _dataContext;
        private readonly IDbCreationHelper _dbCreationHelper;

        public DbWordRepository(WordDataContext dataContext,
            IDbCreationHelper dbCreationHelper)
        {
            this._dataContext = dataContext;
            this._dbCreationHelper = dbCreationHelper;

            if (_dataContext.DatabaseExists() == false)
            {
                _dataContext.CreateDatabase();
                _dbCreationHelper.CreateInitialData(this);
            }
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
                word.DateAdded = DateTime.Now;
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
