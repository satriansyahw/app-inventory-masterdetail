using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [Register("AboutViewController")]
    [ImportBinding(typeof(AboutBindingProvider))]
    [RegisterNavigation(DeviceKind.Phone)]
    public partial class AboutViewController : UIViewController<AboutNavigationViewModel>
    {
        #region Constructors

        public AboutViewController()
            : base("AboutView", null)
        {
            this.Title = "About";
        }

        #endregion

        #region Properties

        public override bool AutoFitContentSize
        {
            get { return true; }
        }

        #endregion
    }
}