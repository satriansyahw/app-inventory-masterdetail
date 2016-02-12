using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [RegisterNavigation(DeviceKind.Tablet)]
    [Register("SettingsMasterDetailViewController")]
    public class SettingsMasterDetailViewController : UINestedMasterDetailViewController<SettingsViewModel>
    {
        #region Constructors

        public SettingsMasterDetailViewController()
        {
        }

        public SettingsMasterDetailViewController(SettingsViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        protected override bool EnsureDetailNavigationContext
        {
            get { return true; }
        }

        #endregion
    }
}