using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;
using MyInventory.Infrastructure;
using MyInventory.Models;
using MyInventory.ModelServices;

namespace MyInventory.ViewModels
{
    public class CategoryListViewModel : ListViewModelBase<Category>
    {
        #region Constructors

        public CategoryListViewModel()
        {
            this.Title = "My Inventory";
            this.SourceItems = this.Repository.GetAll().ToObservable();
        }

        #endregion

        #region Properties

        private ICategoryRepository Repository
        {
            get
            {
                if (Container.Current.CanResolve<ICategoryRepository>())
                    return Container.Current.Resolve<ICategoryRepository>();
                else
                    return new CategoryRepository(); // for designer support
            }
        }

        #endregion

        #region Methods

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);
        }

        #endregion
    }
}