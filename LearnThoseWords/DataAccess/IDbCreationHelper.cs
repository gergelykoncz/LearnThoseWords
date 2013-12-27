
namespace LearnThoseWords.DataAccess
{
    public interface IDbCreationHelper
    {
        void CreateInitialData(IWordRepository repository);
    }
}
