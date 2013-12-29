using LearnThoseWords.BusinessLayer.Repository;
using LearnThoseWords.DataAccess;
using LearnThoseWords.Shared.Facade;
using LearnThoseWords.Shared.Repository;
using Ninject;

namespace LearnThoseWords.Infrastructure
{
    public static class NinjectContainer
    {
        private static IKernel kernel;

        public static void Initialize()
        {
            if (kernel == null)
            {
                kernel = new StandardKernel();

                kernel.Bind<WordDataContext>().ToSelf().InSingletonScope();
                kernel.Bind<IDbCreationHelper>().To<DbCreationHelper>().InSingletonScope();
                kernel.Bind<IWordRepository>().To<DbWordRepository>().InSingletonScope();
                kernel.Bind<IWordFacade>().To<WordFacade>();
                kernel.Bind<IWordDefinitionFacade>().To<WodnikDefinitionFacade>();
            }
        }

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        public static void Dispose()
        {
            if (kernel != null)
            {
                kernel.Dispose();
                kernel = null;
            }
        }
    }
}
