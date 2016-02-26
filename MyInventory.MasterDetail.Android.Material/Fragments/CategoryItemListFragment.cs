using Intersoft.Crosslight;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    [RegisterNavigation("CategoryItemList")]
    public class CategoryItemListFragment : ItemListFragment
    {
    }
}