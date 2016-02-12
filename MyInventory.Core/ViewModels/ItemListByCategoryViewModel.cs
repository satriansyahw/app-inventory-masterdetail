using System.Collections.Generic;
using System.Linq;
using MyInventory.Models;

namespace MyInventory.ViewModels
{
    public class ItemListByCategoryViewModel : ItemListViewModel
    {
        #region Constructors

        public ItemListByCategoryViewModel()
        {
        }

        #endregion

        #region Methods

        protected override void OnSourceItemsChanged(ICollection<Item> items)
        {
            if (items != null)
            {
                if (this.CategoryFilter == null)
                    this.Items = items.OrderBy(o => o.Name);
                else
                {
                    this.Items = items.OrderBy(o => o.Name).Where(o => o.Category == this.CategoryFilter);
                    CategoryFilter = null;
                }
            }
            else
                this.Items = null;

            this.RefreshGroupItems();
        }

        #endregion
    }
}