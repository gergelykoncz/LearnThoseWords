﻿using LearnThoseWords.DataAccess;
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
                kernel.Bind<IWordRepository>().To<DbWordRepository>();
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
            }
        }
    }
}
