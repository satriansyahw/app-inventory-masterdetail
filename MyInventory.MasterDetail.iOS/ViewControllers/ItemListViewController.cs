using CoreGraphics;
using Intersoft.Crosslight;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;
using UIKit;

namespace MyInventory.iOS
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    [RegisterNavigation(DeviceKind.Phone)]
    public partial class ItemListViewController : UITableViewController<ItemListViewModel>
    {
        #region Constructors

        public ItemListViewController()
        {
        }

        public ItemListViewController(ItemListViewModel viewModel)
            : base(viewModel)
        {
        }

        #endregion

        #region Fields

        private UINavigationItem _drawerNavigationItem = null;
        private UISearchDisplayController _searchDisplayController = null;

        #endregion

        #region Properties

        private UIBarButtonItem AddButton { get; set; }

        public override bool AllowSearching
        {
            get { return true; }
        }

        public override ImageSettings CellImageSettings
        {
            get
            {
                return new ImageSettings()
                {
                    ImageSize = new CGSize(36, 36)
                };
            }
        }

        public override TableViewCellStyle CellStyle
        {
            get { return TableViewCellStyle.Subtitle; }
        }

        private UIBarButtonItem DeleteButton { get; set; }

        private UINavigationItem DrawerNavigationItem
        {
            get
            {
                if (_drawerNavigationItem == null)
                {
                    var drawerController = this.GetParentViewController(typeof(IDrawerNavigationController)) as IDrawerNavigationController;
                    if (drawerController != null)
                        _drawerNavigationItem = drawerController.CenterViewController.NavigationBar.TopItem;
                }

                return _drawerNavigationItem;
            }
        }

        private UIBarButtonItem EditButton { get; set; }

        public override EditingOptions EditingOptions
        {
            get { return EditingOptions.AllowEditing | EditingOptions.AllowMultipleSelection; }
        }

        public override bool HideSearchBarInitially
        {
            get { return true; }
        }

        public override TableViewInteraction InteractionMode
        {
            get { return TableViewInteraction.Navigation; }
        }

        public bool IsPad
        {
            get { return this.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet; }
        }

        private UIBarButtonItem MarkSoldButton { get; set; }

        public override UISearchDisplayController SearchDisplayController
        {
            get
            {
                if (this.IsPad && this.SearchBar != null && this.GetType() == typeof(ItemListViewController))
                {
                    if (_searchDisplayController == null)
                        _searchDisplayController = new UIDrawerSearchDisplayController(this.SearchBar, this);

                    return _searchDisplayController;
                }
                else
                    return base.SearchDisplayController;
            }
        }

        public override string[] SearchScopes
        {
            get { return new string[] {"Name", "Location"}; }
        }

        public override bool ShowGroupHeader
        {
            get { return true; }
        }

        #endregion

        #region Methods

        protected override void InitializeView()
        {
            base.InitializeView();

            UIBarButtonItem addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            UIBarButtonItem deleteButton = null;
            UIBarButtonItem markSoldButton = null;
            UIBarButtonItem editButton = null;

            this.NavigationItem.Title = "My Inventory";
            this.NavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] {addButton, this.EditButtonItem}, false);

            // Configure ToolBar

            if (!this.IsPad)
            {
                deleteButton = new UIBarButtonItem();
                deleteButton.Style = UIBarButtonItemStyle.Bordered;
                deleteButton.TintColor = UIColor.Red;

                markSoldButton = new UIBarButtonItem();
                markSoldButton.Style = UIBarButtonItemStyle.Bordered;
            }
            else
            {
                deleteButton = new UIBarButtonItem(UIBarButtonSystemItem.Trash);
                markSoldButton = new UIBarButtonItem(UIBarButtonSystemItem.Action);
                editButton = new UIBarButtonItem(UIBarButtonSystemItem.Compose);
            }

            this.SetToolbarItems(new UIBarButtonItem[] {deleteButton, markSoldButton}, false);

            // Configure Footer
            UILabel totalCountLabel = new UILabel(new CGRect(0, 0, this.TableView.Bounds.Width, 44));
            totalCountLabel.TextAlignment = UITextAlignment.Center;
            totalCountLabel.TextColor = UIColor.Gray;
            this.TableView.TableFooterView = totalCountLabel;

            // Register Views
            this.RegisterViewIdentifier("AddButton", addButton);
            this.RegisterViewIdentifier("DeleteButton", deleteButton);
            this.RegisterViewIdentifier("MarkSoldButton", markSoldButton);
            this.RegisterViewIdentifier("FooterLabel", totalCountLabel);
            this.RegisterViewIdentifier("EditButton", !this.IsPad ? this.EditButtonItem : editButton);

            this.AddButton = addButton;
            this.EditButton = editButton;
            this.DeleteButton = deleteButton;
            this.MarkSoldButton = markSoldButton;
        }

        protected override void OnViewModelPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsEditing")
            {
                this.NavigationController.SetToolbarHidden(!this.ViewModel.IsEditing, true);

                if (this.ViewModel.IsEditing)
                    this.NavigationItem.SetRightBarButtonItem(null, true);
                else
                    this.NavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] {this.AddButton, this.EditButtonItem}, true);
            }
            else if (e.PropertyName == "TitleText")
            {
                if (this.DrawerNavigationItem != null)
                    this.DrawerNavigationItem.Title = this.ViewModel.TitleText;
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (this.DrawerNavigationItem != null)
            {
                this.DrawerNavigationItem.Title = this.ViewModel.TitleText;

                if (this.IsPad)
                {
                    this.DrawerNavigationItem.SetRightBarButtonItems(new UIBarButtonItem[] {this.AddButton, this.EditButton, new UIBarButtonItem(UIBarButtonSystemItem.FixedSpace)
                    {
                        Width = 32f
                    },
                        this.DeleteButton, this.MarkSoldButton,}, false);
                }
            }
        }

        #endregion
    }
}