using Foundation;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [Register("MainDrawerViewController")]
    public class MainDrawerViewController : UIDrawerNavigationController<DrawerViewModel>
    {
        #region Constructors

        public MainDrawerViewController()
        {
            this.DrawerSettings.StatusBarTransitionMode = StatusBarTransitionMode.TranslucentBlack;
            this.DrawerSettings.CenterStatusBarContentStyle = StatusBarContentStyle.Light;
            this.DrawerSettings.NavigationBarColor = UIColor.FromRGB(47, 80, 147);
            this.DrawerSettings.NavigationBarTintColor = UIColor.White;
            this.DrawerSettings.NavigationBarTitleAttributes = new UITextAttributes()
            {
                TextColor = UIColor.White
            };
        }

        #endregion
    }
}