using Foundation;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [Register("NavigationViewController")]
    [ImportBinding(typeof(NavigationBindingProvider))]
    public class NavigationViewController : UITableViewController<NavigationViewModel>
    {
        #region Constructors

        public NavigationViewController()
        {
        }

        public NavigationViewController(NavigationViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Properties

        public override bool DeselectRowOnNavigate
        {
            get { return true; }
        }

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

        #region Methods

        protected override void InitializeView()
        {
            base.InitializeView();

            // set TableView appearance
            this.Appearance.BackgroundColor = UIColor.FromRGB(62, 64, 70);
            this.Appearance.SeparatorColor = UIColor.FromRGB(77, 79, 84);
            this.Appearance.CellBackgroundColor = UIColor.Clear;
            this.Appearance.CellSelectedBackgroundColor = UIColor.FromRGB(39, 40, 43);
            this.Appearance.TitleTextColor = UIColor.White;

            // set navigation title
            this.NavigationItem.Title = "Crosslight App";
        }

        #endregion
    }
}