using System.Linq;
using Intersoft.Crosslight;
using MyInventory.Infrastructure;
using MyInventory.ModelServices;

namespace MyInventory.Models
{
    public class CategoryGroup : GroupItem<Item>
    {
        #region Constructors

        public CategoryGroup(IGrouping<string, Item> groupItem)
            : base(groupItem)
        {
            this.Category = this.CategoryRepository.GetByName(groupItem.Key);
        }

        #endregion

        #region Properties

        public Category Category { get; private set; }

        private ICategoryRepository CategoryRepository
        {
            get { return Container.Current.Resolve<ICategoryRepository>(); }
        }

        #endregion
    }
}