using MLSOfferTool.Services;
using Unity;
using Unity.Lifetime;

namespace MLSOfferTool
{
    public static class DependencyConfig
    {
        private static IUnityContainer _Instance;

        static DependencyConfig()
        {
            _Instance = new UnityContainer();
        }

        public static IUnityContainer Instance
        {
            get
            {
                //register services
                _Instance.RegisterType<IPropertyDataService, PropertyDataService>(new HierarchicalLifetimeManager());
                return _Instance;
            }
        }
    }
}