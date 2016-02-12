using Intersoft.Crosslight;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    [RegisterNavigation("CategoryItemList")]
    public class CategoryItemListFragment : ItemListFragment
    {
        #region Properties

        protected override bool ShowActionBarUpButton
        {
            get { return true; }
        }

        #endregion
    }
}