using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using MyInventory.Infrastructure;
using MyInventory.Models;
using MyInventory.ModelServices;

namespace MyInventory.ViewModels
{
    public class ItemListViewModel : EditableListViewModelBase<Item>
    {
        #region Constructors

        public ItemListViewModel()
        {
            this.Title = "My Inventory";
            // commands
            this.NavigateGroupCommand = new DelegateCommand(ExecuteNavigateGroup);
            this.MarkSoldCommand = new DelegateCommand(ExecuteMarkSold, CanExecuteMarkSold);
        }

        #endregion

        #region Properties

        protected Category CategoryFilter { get; set; }

        public string DeleteText
        {
            get
            {
                if (this.SelectedItems == null || this.SelectedItems.Count() == 0)
                    return "Delete";
                else
                    return "Delete (" + this.SelectedItems.Count() + ")";
            }
        }

        public bool IsTablet
        {
            get { return this.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet; }
        }

        public DelegateCommand MarkSoldCommand { get; set; }

        public string MarkSoldText
        {
            get
            {
                if (this.SelectedItems == null || this.SelectedItems.Count() == 0)
                    return "Mark as Sold";
                else
                    return "Mark as Sold (" + this.SelectedItems.Count() + ")";
            }
        }

        public DelegateCommand NavigateGroupCommand { get; set; }

        protected IItemRepository Repository
        {
            get
            {
                if (Container.Current.CanResolve<IItemRepository>())
                    return Container.Current.Resolve<IItemRepository>();
                else
                    return new ItemRepository(); // for designer support
            }
        }

        public string TitleText
        {
            get { return "Inventories (" + (this.Items != null ? this.Items.Count().ToString() : "0") + ")"; }
        }

        public string TotalItemsText
        {
            get
            {
                if (this.Items == null || this.Items.Count() == 0)
                    return "No items.";
                else if (this.Items.Count() == 1)
                    return "1 item";
                else
                    return this.Items.Count() + " items";
            }
        }

        #endregion

        #region Methods

        protected override bool CanExecuteDelete(object parameter)
        {
            if (parameter is Item)
                return true;
            else if (parameter is IEnumerable<Item>)
                return ((IEnumerable<Item>) parameter).Count() > 0;

            return false;
        }

        protected override bool CanExecuteEdit(object parameter)
        {
            return (this.SelectedItem != null || (parameter != null && parameter is Item));
        }

        private bool CanExecuteMarkSold(object parameter)
        {
            if (parameter is Item)
                return true;
            else if (parameter is IEnumerable<Item>)
                return ((IEnumerable<Item>) parameter).Count() > 0;

            return false;
        }

        protected override void ExecuteAdd(object parameter)
        {
            this.NavigationService.Navigate<ItemEditorViewModel>(new NavigationParameter()
            {
                NavigationMode = NavigationMode.Modal,
                EnsureNavigationContext = true,
                ModalPresentationStyle = ModalPresentationStyle.FormSheet,
                CommandId = "Add"
            });
        }

        protected override void ExecuteDelete(object parameter)
        {
            Item previousRow = null;

            if (parameter is Item)
            {
                if (this.IsTablet)
                    previousRow = this.GetNextValidItem((Item) parameter);

                this.Repository.Delete((Item) parameter);
            }
            else if (parameter is IEnumerable<Item>)
                this.Repository.Delete((IEnumerable<Item>) parameter);

            if (this.SelectedItems != null)
                this.SelectedItems.Clear();

            if (previousRow != null)
            {
                // in master-detail, auto-select a valid row
                this.SelectedItem = previousRow;
            }
        }

        protected override void ExecuteEdit(object parameter)
        {
            if (this.SelectedItem != null)
            {
                this.NavigationService.Navigate<ItemEditorViewModel>(new NavigationParameter()
                {
                    Data = this.SelectedItem,
                    NavigationMode = NavigationMode.Modal,
                    EnsureNavigationContext = true,
                    ModalPresentationStyle = ModalPresentationStyle.FormSheet,
                    CommandId = "Edit"
                });
            }
        }

        private void ExecuteMarkSold(object parameter)
        {
            if (parameter is IEnumerable<Item>)
            {
                var items = parameter as IEnumerable<Item>;

                foreach (Item item in items)
                {
                    item.IsSold = true;
                    item.SoldDate = DateTime.Today;

                    this.OnDataChanged(item);
                }
            }
            else if (parameter is Item)
            {
                var item = parameter as Item;
                item.IsSold = true;
                item.SoldDate = DateTime.Today;

                this.OnDataChanged(item);
            }

            if (this.SelectedItems != null && !this.IsTablet)
                this.SelectedItems.Clear();
        }

        private void ExecuteNavigateGroup(object parameter)
        {
            this.NavigationService.Navigate<GroupDetailViewModel>(new NavigationParameter(parameter));
        }

        public override void Filter(string query, string scope)
        {
            if (scope == "Name")
                this.FilterItems = this.Items.Where(o => o.Name.ToLowerInvariant().StartsWith(query.ToLowerInvariant())).ToList();
            else if (scope == "Location")
                this.FilterItems = this.Items.Where(o => o.Location.ToLowerInvariant().StartsWith(query.ToLowerInvariant())).ToList();
        }

        public override void Navigated(NavigatedParameter parameter)
        {
            if (parameter.Data != null && parameter.Data is Category)
                this.CategoryFilter = parameter.Data as Category;

            // source items, should be plain items, not sorted or filtered
            this.SourceItems = this.Repository.GetAll().ToObservable();

            // refresh group view
            this.RefreshGroupView();
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.RefreshGroupItems();

            // WinRT requires GroupItems notification in another UI thread
            if (this.GetService<IApplicationService>().GetContext().Platform.OperatingSystem == OSKind.WinRT)
                this.GetService<IViewService>().RunOnUIThread(() => this.OnPropertyChanged("GroupItems"));
        }

        protected override void OnSelectedItemChanged(Item newItem)
        {
            this.EditCommand.RaiseCanExecuteChanged();
            this.DeleteCommand.RaiseCanExecuteChanged();
            this.MarkSoldCommand.RaiseCanExecuteChanged();
        }

        protected override void OnSelectedItemsCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            this.OnPropertyChanged("DeleteText");
            this.OnPropertyChanged("MarkSoldText");

            this.DeleteCommand.RaiseCanExecuteChanged();
            this.MarkSoldCommand.RaiseCanExecuteChanged();
        }

        protected override void OnSourceItemsChanged(ICollection<Item> items)
        {
            if (items != null)
            {
                if (this.CategoryFilter == null)
                    this.Items = items.OrderBy(o => o.Name);
                else
                    this.Items = items.OrderBy(o => o.Name).Where(o => o.Category == this.CategoryFilter);
            }
            else
                this.Items = null;

            this.RefreshGroupItems();
        }

        public override void RefreshGroupItems()
        {
            // Uncomment the following line to display items in plain list
            if (this.Items != null && this.CategoryFilter == null)
                this.GroupItems = this.Items.OrderBy(o => o.Category.Name).GroupBy(o => o.Category.Name).Select(o => new CategoryGroup(o)).ToList();

            this.OnPropertyChanged("TotalItemsText");
            this.OnPropertyChanged("TitleText");
        }

        #endregion
    }
}