using Intersoft.Crosslight;
using MyInventory.Infrastructure;

namespace MyInventory.Android.Infrastructure
{
    public sealed class AppInitializer : IApplicationInitializer
    {
        #region Methods

        public IApplicationService GetApplicationService(IApplicationContext context)
        {
            return new MyInventoryAppService(context);
        }

        public void InitializeApplication(IApplicationHost appHost)
        {
        }

        public void InitializeComponents(IApplicationHost appHost)
        {
        }

        public void InitializeServices(IApplicationHost appHost)
        {
        }

        #endregion
    }
}