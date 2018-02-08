using MLSOfferTool.Services;
using Unity;

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
                //_Instance.RegisterType<IPropertyDataService, PropertyDataService>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<IPropertyDataService, PropertyDataService>();
                return _Instance;
            }
        }
    }
}