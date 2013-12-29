using System.Linq;
using System.Threading.Tasks;
using WordnikApi.Api;

namespace LearnThoseWords.Shared.Facade
{
    public class WodnikDefinitionFacade : IWordDefinitionFacade
    {
        private readonly WordApi _wordApi;

        public WodnikDefinitionFacade(WordApi wordApi)
        {
            this._wordApi = wordApi;
        }

        public async Task<string> GetDefinition(string word)
        {
            var definitions = await _wordApi.GetDefinitions(word, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty);
            if (definitions.Count > 0)
            {
                return definitions.First().Text;
            }
            return string.Empty;
        }
    }
}
