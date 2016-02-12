using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [Register("SettingsListViewController")]
    [ImportBinding(typeof(NavigationBindingProvider))]
    [RegisterNavigation(DeviceKind.Phone)]
    public class SettingsListViewController : UITableViewController<SettingsViewModel>
    {
        #region Constructors

        public SettingsListViewController()
        {
        }

        public SettingsListViewController(SettingsViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        public override TableViewInteraction InteractionMode
        {
            get { return TableViewInteraction.Navigation; }
        }

        public override bool ShowGroupHeader
        {
            get { return true; }
        }

        public override UITableViewStyle TableViewStyle
        {
            get { return UITableViewStyle.Grouped; }
        }

        #endregion
    }
}