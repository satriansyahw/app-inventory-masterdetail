using CoreGraphics;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [ImportBinding(typeof(ItemDetailBindingProvider))]
    [RegisterNavigation("PhotoDetail")]
    public partial class PhotoDetailViewController : UIViewController<ItemDetailViewModel>
    {
        #region Constructors

        public PhotoDetailViewController()
            : base("PhotoDetailViewController", null)
        {
            // Uncomment for iOS6
            // this.ContentSizeForViewInPopover = new SizeF(350f, 550f);

            this.PreferredContentSize = new CGSize(400f, 500f);
        }

        #endregion

        #region Fields

        private UIBarStyle _originalBarStyle;

        #endregion

        #region Methods

        public override void DetermineNavigationMode(NavigationParameter parameter)
        {
            if (this.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet)
            {
                parameter.NavigationMode = NavigationMode.Modal;
                parameter.ModalPresentationStyle = Intersoft.Crosslight.ModalPresentationStyle.FormSheet;
                parameter.EnsureNavigationContext = true;

                var closeButton = new UIBarButtonItem("Close", UIBarButtonItemStyle.Bordered, null);

                this.RegisterViewIdentifier("CloseButton", closeButton);
                this.NavigationItem.RightBarButtonItem = closeButton;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.NavigationController != null)
            {
                _originalBarStyle = this.NavigationController.NavigationBar.BarStyle;
                this.NavigationController.NavigationBar.BarStyle = UIBarStyle.Black;
            }
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            if (this.NavigationController != null)
                this.NavigationController.NavigationBar.BarStyle = _originalBarStyle;
        }

        #endregion
    }
}