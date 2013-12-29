using LearnThoseWords.Shared.Repository;

namespace LearnThoseWords.DataAccess
{
    public interface IDbCreationHelper
    {
        void CreateInitialData(IWordRepository repository);
    }
}
