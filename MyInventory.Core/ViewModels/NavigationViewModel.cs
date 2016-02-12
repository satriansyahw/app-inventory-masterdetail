using System.Collections.Generic;
using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;

namespace MyInventory.ViewModels
{
    public class NavigationViewModel : ListViewModelBase<NavigationItem>
    {
        #region Constructors

        public NavigationViewModel()
        {
            List<NavigationItem> items = new List<NavigationItem>();

            items.Add(new NavigationItem("Categories", "Two-level Master Detail", typeof(CategoryListViewModel)));
            items.Add(new NavigationItem("Inventories", "Facebook-style Master Detail", typeof(ItemListViewModel)));
            items.Add(new NavigationItem("Settings", "Content Navigation", typeof(SettingsViewModel)));

            this.SourceItems = items;
            this.RefreshGroupItems();
        }

        #endregion

        #region Methods

        public override void RefreshGroupItems()
        {
            if (this.Items != null)
                this.GroupItems = this.Items.GroupBy(o => o.Group).Select(o => new GroupItem<NavigationItem>(o)).ToList();
        }

        #endregion
    }
}