using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [ImportBinding(typeof(AboutBindingProvider))]
    [RegisterNavigation(DeviceKind.Tablet)]
    public partial class AboutViewController_iPad : UIViewController<AboutNavigationViewModel>
    {
        #region Constructors

        public AboutViewController_iPad()
            : base("AboutView_iPad", null)
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