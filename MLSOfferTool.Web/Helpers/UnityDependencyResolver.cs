using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace MLSOfferTool.Helpers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _Container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            this._Container = container;
        }

        public object GetService(Type serviceType)
        {
            if (!this._Container.IsRegistered(serviceType) && (serviceType.IsAbstract || serviceType.IsInterface))
                return null;
            return this._Container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this._Container.ResolveAll(serviceType);
        }
    }
}