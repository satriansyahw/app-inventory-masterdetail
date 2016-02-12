using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using MyInventory.Infrastructure;

namespace MyInventory.WinRT.Infrastructure
{
    public sealed class AppInitializer : IApplicationInitializer
    {
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
            ServiceProvider.AddService<IApplicationStateService, ApplicationStateService>();
        }
    }
}
