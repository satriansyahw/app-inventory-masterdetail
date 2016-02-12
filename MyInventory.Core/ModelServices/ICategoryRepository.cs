using MyInventory.Models;

namespace MyInventory.ModelServices
{
    public interface ICategoryRepository : IDataRepository<Category, int>
    {
        #region Methods

        Category GetByName(string name);

        #endregion
    }
}