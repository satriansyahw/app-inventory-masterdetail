using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [RegisterNavigation(DeviceKind.Tablet)]
    [Register("CategoryMasterDetailViewController")]
    public class CategoryMasterDetailViewController : UINestedMasterDetailViewController<CategoryListViewModel, ItemDetailViewModel>
    {
        #region Constructors

        public CategoryMasterDetailViewController()
        {
        }

        public CategoryMasterDetailViewController(CategoryListViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        protected override bool EnsureNavigationContext
        {
            get { return true; }
        }

        #endregion
    }
}