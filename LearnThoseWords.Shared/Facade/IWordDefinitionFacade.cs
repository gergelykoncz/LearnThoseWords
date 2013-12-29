using System.Threading.Tasks;

namespace LearnThoseWords.Shared.Facade
{
    public interface IWordDefinitionFacade
    {
        Task<string> GetDefinition(string word);
    }
}
