using System.Linq;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Input;
using Intersoft.Crosslight.ViewModels;
using MyInventory.Infrastructure;
using MyInventory.Models;
using MyInventory.ModelServices;

namespace MyInventory.ViewModels
{
    public class ItemDetailViewModel : EditableDetailViewModelBase<Item>
    {
        #region Constructors

        public ItemDetailViewModel()
        {
            this.CloseCommand = new DelegateCommand(this.ExecuteClose);
        }

        #endregion

        #region Fields

        private GroupItem<Item> _group;

        #endregion

        #region Properties

        public DelegateCommand CloseCommand { get; set; }

        public GroupItem<Item> Group
        {
            get { return _group; }
            set
            {
                if (_group != value)
                {
                    _group = value;
                    OnPropertyChanged("Group");
                }
            }
        }

        /// Represents a property member that participates in the state saving during application suspension.
        /// Use the [StateAware] attribute to define members that will be saved and restored during application life cycle changes.
        /// </summary>
        [StateAware]
        public string ItemKey
        {
            get { return this.Item.Name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    this.Item = this.ItemRepository.GetAll().First();
                else
                    this.Item = this.ItemRepository.Get(this.Item.Name);

                if (this.Item != null)
                    this.Group = this.ItemRepository.GetCategoryGroup(this.Item.CategoryId);
            }
        }

        private IItemRepository ItemRepository
        {
            get
            {
                if (Container.Current.CanResolve<IItemRepository>())
                    return Container.Current.Resolve<IItemRepository>();
                else
                    return new ItemRepository(); // for designer support
            }
        }

        #endregion

        #region Methods

        protected override void ExecuteAdd(object parameter)
        {
            this.NavigationService.Navigate<ItemEditorViewModel>(new NavigationParameter()
            {
                NavigationMode = NavigationMode.Modal
            });
        }

        private void ExecuteClose(object parameter)
        {
            this.NavigationService.Close();
        }

        protected override void ExecuteEdit(object parameter)
        {
            this.NavigationService.Navigate<ItemEditorViewModel>(new NavigationParameter(this.Item)
            {
                NavigationMode = NavigationMode.Modal
            });
        }

        public override void Navigated(NavigatedParameter parameter)
        {
            base.Navigated(parameter);

            if (parameter.Data != null)
            {
                var item = parameter.Data as Item;
                this.Group = this.ItemRepository.GetCategoryGroup(item.CategoryId);
                this.Item = parameter.Data as Item;
            }
        }

        protected override void OnItemChanging(Item oldItem, Item newItem)
        {
            base.OnItemChanging(oldItem, newItem);
        }

        #endregion
    }
}