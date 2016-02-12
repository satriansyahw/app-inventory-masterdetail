using Intersoft.Crosslight;
using Intersoft.Crosslight.Containers;
using MyInventory.ModelServices;
using MyInventory.ViewModels;

namespace MyInventory.Infrastructure
{
    public sealed class MyInventoryAppService : ApplicationServiceBase
    {
        #region Constructors

        public MyInventoryAppService(IApplicationContext context)
            : base(context)
        {
            Container.Current.Register<IItemRepository, ItemRepository>().WithLifetimeManager(new ContainerLifetime());
            Container.Current.Register<ICategoryRepository, CategoryRepository>().WithLifetimeManager(new ContainerLifetime());
        }

        #endregion

        #region Methods

        protected override void OnStart(StartParameter parameter)
        {
            base.OnStart(parameter);

            this.SetRootViewModel<DrawerViewModel>();
        }

        #endregion
    }
}