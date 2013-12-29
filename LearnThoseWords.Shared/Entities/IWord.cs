using System;

namespace LearnThoseWords.Shared.Entities
{
    public interface IWord
    {
        DateTime DateAdded { get; set; }
        string Definition { get; set; }
        int WordId { get; set; }
        string Title { get; set; }
    }
}
