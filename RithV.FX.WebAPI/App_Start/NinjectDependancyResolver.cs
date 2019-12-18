using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace RithV.FX.WebAPI
{
    public class NinjectDependancyResolver : IDependencyResolver
    {
        private readonly IKernel _container;

        public NinjectDependancyResolver(IKernel container)
        {
            _container = container;
        }

        public IKernel Container
        {
            get { return _container; }
        }

        public void Dispose()
        {
            //no 
        }

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            return _container.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAll(serviceType);
        }
    }
}