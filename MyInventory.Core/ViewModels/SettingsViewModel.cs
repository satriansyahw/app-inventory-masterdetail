using System.Collections.Generic;
using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;

namespace MyInventory.ViewModels
{
    public class SettingsViewModel : ListViewModelBase<NavigationItem>
    {
        #region Constructors

        public SettingsViewModel()
        {
            this.Title = "Settings";
            List<NavigationItem> items = new List<NavigationItem>();

            items.Add(new NavigationItem("Preferences", "General", typeof(UserSettingsViewModel)));
            items.Add(new NavigationItem("About", "Others", typeof(AboutNavigationViewModel)));

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