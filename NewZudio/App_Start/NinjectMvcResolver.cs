using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewZudio.App_Start
{
    public class NinjectMvcResolver
    {
        private readonly IKernel _kernel;

        public NinjectMvcResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            // single service (controller, repo, etc.)
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            // multiple services
            return _kernel.GetAll(serviceType);
        }
    }
}