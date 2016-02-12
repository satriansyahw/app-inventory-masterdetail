using Intersoft.Crosslight;
using MyInventory.Models;

namespace MyInventory.ModelServices
{
    public interface IItemRepository : IEditableDataRepository<Item, string>
    {
        #region Methods

        CategoryGroup GetCategoryGroup(int group);
        GroupItem<Item> GetLocationGroup(string group);

        #endregion
    }
}