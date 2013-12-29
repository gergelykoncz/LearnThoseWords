using LearnThoseWords.Entities;
using LearnThoseWords.Shared.Repository;

namespace LearnThoseWords.DataAccess
{
    /// <summary>
    /// There's a bug in WP8 when an empty database throws exceptions
    /// on subsequent runs. This class inserts some dummy data.
    /// </summary>
    public class DbCreationHelper : IDbCreationHelper
    {
        public void CreateInitialData(IWordRepository wordRepository)
        {
            var word = new Word();
            word.Definition = "Hello world word";
            word.Title = "Hello";

            wordRepository.SaveWord(word);
        }
    }
}
