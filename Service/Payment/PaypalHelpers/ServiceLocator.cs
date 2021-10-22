using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Payment.PaypalHelpers
{
    public class ServiceLocator
    {
        private ServiceProvider currentProvider;
        private static ServiceProvider staticProvider;

        public ServiceLocator(ServiceProvider provider)
        {
            currentProvider = provider;
        }

        public static ServiceLocator Current
        {
            get
            {
                return new ServiceLocator(staticProvider);
            }
        }

        public static void SetLocatorProvider(ServiceProvider provider)
        {
            staticProvider = provider;
        }

        public object GetInstance(Type serviceType)
        {
            return currentProvider.GetService(serviceType);
        }

        public TService GetInstance<TService>()
        {
            return currentProvider.GetService<TService>();
        }
    }
}
