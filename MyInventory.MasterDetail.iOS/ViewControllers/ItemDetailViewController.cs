using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory
{
    [ImportBinding(typeof(ItemDetailBindingProvider))]
    public partial class ItemDetailViewController : UIDetailViewController<ItemDetailViewModel>
    {
        #region Constructors

        public ItemDetailViewController()
            : base("ItemDetailViewController", null)
        {
        }

        #endregion

        #region Properties

        public override bool AutoFitContentSize
        {
            get { return true; }
        }

        #endregion

        #region Methods

        protected override void OnViewInitialized()
        {
            base.OnViewInitialized();

            if (this.ViewModel.Item != null)
                this.Title = this.ViewModel.Item.Name;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.NavigationController != null && this.NavigationController.ParentViewController is IMasterDetailViewController)
                this.NavigationController.SetNavigationBarHidden(true, false);
        }

        #endregion
    }
}