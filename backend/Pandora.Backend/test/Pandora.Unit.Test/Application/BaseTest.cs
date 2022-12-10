using Microsoft.Extensions.DependencyInjection;

namespace Pandora.Unit.Test.Application
{
    public class BaseTest
    {
        private ServiceProvider Provider = ServiceCollectionProvider.BuildProvider();

        public T Resolve<T>()
        {
            return Provider.GetService<T>();

        }

    }
}
