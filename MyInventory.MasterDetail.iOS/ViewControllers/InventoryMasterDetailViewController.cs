using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [RegisterNavigation(DeviceKind.Tablet)]
    [Register("InventoryMasterDetailViewController")]
    public class InventoryMasterDetailViewController : UINestedMasterDetailViewController<ItemListViewModel, ItemDetailViewModel>
    {
        #region Constructors

        public InventoryMasterDetailViewController()
        {
        }

        public InventoryMasterDetailViewController(ItemListViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion
    }
}