using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [ImportBinding(typeof(CategoryListBindingProvider))]
    [RegisterNavigation(DeviceKind.Phone)]
    public class CategoryListViewController : UITableViewController<CategoryListViewModel>
    {
        #region Constructors

        public CategoryListViewController()
        {
        }

        public CategoryListViewController(CategoryListViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Fields

        private UINavigationItem _drawerNavigationItem = null;

        #endregion

        #region Properties

        private UINavigationItem DrawerNavigationItem
        {
            get
            {
                if (_drawerNavigationItem == null && this.IsPad)
                {
                    var masterDetailViewController = this.GetParentViewController(typeof(IMasterDetailViewController)) as IMasterDetailViewController;
                    if (masterDetailViewController != null)
                    {
                        var drawerController = this.GetParentViewController(typeof(IDrawerNavigationController)) as IDrawerNavigationController;
                        if (drawerController != null)
                            _drawerNavigationItem = drawerController.CenterViewController.NavigationBar.TopItem;
                    }
                }

                return _drawerNavigationItem;
            }
        }

        public override TableViewInteraction InteractionMode
        {
            get { return TableViewInteraction.Navigation; }
        }

        private bool IsPad
        {
            get { return this.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet; }
        }

        #endregion

        #region Methods

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.DrawerNavigationItem != null)
            {
                this.DrawerNavigationItem.Title = "Select a Category";
                this.DrawerNavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] {}, false);
                this.NavigationController.SetNavigationBarHidden(true, false);
            }
        }

        #endregion
    }
}