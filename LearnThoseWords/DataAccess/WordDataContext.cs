using LearnThoseWords.Entities;
using System.Data.Linq;

namespace LearnThoseWords.DataAccess
{
    public class WordDataContext : DataContext
    {
        private const string ConnectionString = "Data Source=isostore:/LearnThoseWords.sdf";

        public WordDataContext()
            : base(ConnectionString)
        {
            
        }

        public Table<Word> Words;
    }
}