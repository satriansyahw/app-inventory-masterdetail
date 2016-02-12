using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    [RegisterNavigation("CategoryItemList")]
    public class CategoryItemListViewController : ItemListViewController
    {
        #region Constructors

        public CategoryItemListViewController()
        {
        }

        public CategoryItemListViewController(ItemListViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        public override bool AllowSearching
        {
            get { return !this.IsPad; }
        }

        public override EditingOptions EditingOptions
        {
            get
            {
                // disable list editing in master detail
                return EditingOptions.Default;
            }
        }

        #endregion

        #region Methods

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // we don't want to show cluttered buttons while the item list is presented in master detail
            // this will just show "Back" button, so users can go back to the upper level

            this.NavigationController.SetNavigationBarHidden(false, true);
            this.NavigationItem.Title = string.Empty;
            this.NavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] {}, false);
        }

        #endregion
    }
}