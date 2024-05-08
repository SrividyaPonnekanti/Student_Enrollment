using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace UntityProvider
{
   public class UnitityFramework
    {
        public T GetProvider<T>(string providerClassName)
        {
            T objProvider = new UnityContainer().LoadConfiguration(providerClassName).Resolve<T>();

            return objProvider;
        }

    }
}
