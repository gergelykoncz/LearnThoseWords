﻿using LearnThoseWords.BusinessLayer.Facade;
using LearnThoseWords.DataAccess;
using LearnThoseWords.Infrastructure;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace LearnThoseWords.Tests.Infrastructure
{
    [TestClass]
    public class NinjectContainerTests
    {
        [TestMethod]
        public void InitializeInstantiatesBindings()
        {
            NinjectContainer.Initialize();

            var dbContext = NinjectContainer.Get<WordDataContext>();
            Assert.IsInstanceOfType(dbContext, typeof(WordDataContext));

            //Check if singleton scope is used for the data context.
            var otherContext = NinjectContainer.Get<WordDataContext>();
            Assert.AreSame(dbContext, otherContext);

            var dbRepository = NinjectContainer.Get<IWordRepository>();
            Assert.IsInstanceOfType(dbRepository, typeof(DbWordRepository));

            var wordFacade = NinjectContainer.Get<IWordFacade>();
            Assert.IsInstanceOfType(wordFacade, typeof(WordFacade));
        }
    }
}