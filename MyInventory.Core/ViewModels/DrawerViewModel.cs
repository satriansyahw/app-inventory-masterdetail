using Intersoft.Crosslight.ViewModels;

namespace MyInventory.ViewModels
{
    public class DrawerViewModel : DrawerViewModelBase
    {
        #region Constructors

        public DrawerViewModel()
        {
            this.LeftViewModel = new NavigationViewModel();
            this.CenterViewModel = new ItemListViewModel();
        }

        #endregion
    }
}