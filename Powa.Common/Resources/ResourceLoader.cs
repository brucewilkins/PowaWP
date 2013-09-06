using System.Reflection;
using System.Resources;

namespace Powa.Common.Resources
{
    public static class ResourceLoader
    {
        private static ResourceManager _resourceManager;

        public static string GetString(string resource)
        {
            if (_resourceManager == null)
            {
                _resourceManager = new ResourceManager("Powa.Common.Resources.Resource",
                    Assembly.Load(new AssemblyName("Powa.Common")));
            }

            return _resourceManager.GetString(resource);
        }
    }
}
