using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    [Register("PreferencesViewController")]
    public class PreferencesViewController : UIFormViewController<UserSettingsViewModel>
    {
        #region Constructors

        public PreferencesViewController()
        {
        }

        public PreferencesViewController(UserSettingsViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        private bool IsPad
        {
            get { return this.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet; }
        }

        #endregion

        #region Methods

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.Title = "Preferences";

            if (this.IsPad)
                this.NavigationController.SetNavigationBarHidden(true, false);
        }

        #endregion
    }
}