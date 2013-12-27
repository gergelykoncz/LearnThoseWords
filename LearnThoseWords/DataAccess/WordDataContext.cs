﻿using LearnThoseWords.Entities;
using System.Data.Linq;

namespace LearnThoseWords.DataAccess
{
    public class WordDataContext : DataContext
    {
        public static readonly string ConnectionString = "Data Source=isostore:/Words.sdf";

        public WordDataContext() : base(ConnectionString) { }

        public Table<Word> Words;
    }
}
