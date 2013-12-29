using LearnThoseWords.DataAccess;
using LearnThoseWords.Entities;
using LearnThoseWords.Shared.Entities;
using LearnThoseWords.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LearnThoseWords.BusinessLayer.Repository
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

        public IEnumerable<IWord> GetAllWords()
        {
            return _dataContext.Words;
        }

        public IEnumerable<IWord> GetWordsByCriteria(Func<IWord, bool> criteria)
        {
            return _dataContext.Words.Where(criteria);
        }

        public IWord GetWordByCriteria(Func<IWord, bool> criteria)
        {
            return _dataContext.Words.FirstOrDefault(criteria);
        }

        public void SaveWord(IWord word)
        {
            Word wp8Word = word as Word;
            if (wp8Word != null)
            {
                //New word, it has the default zero ID, store it.
                if (word.WordId == 0)
                {
                    word.DateAdded = DateTime.Now;

                    _dataContext.Words.InsertOnSubmit(wp8Word);
                    _dataContext.SubmitChanges();
                }
                //Existing word, update the properties one by one on the original.
                else
                {
                    Word originalWord = GetWordByCriteria(x => x.WordId == wp8Word.WordId) as Word;
                    if (originalWord != null)
                    {
                        originalWord.Definition = word.Definition;
                        originalWord.Title = word.Title;

                        _dataContext.SubmitChanges();
                    }
                }
            }
        }

        public void DeleteWord(IWord word)
        {
            Word wp8Word = word as Word;
            _dataContext.Words.DeleteOnSubmit(wp8Word);
            _dataContext.SubmitChanges();
        }
    }
}
