using System.Collections.Generic;
using Intersoft.Crosslight;
using Intersoft.Crosslight.ViewModels;

namespace MyInventory.ViewModels
{
    public class TabViewModel : ViewModelBase
    {
        #region Constructors

        public TabViewModel()
        {
            var tabItems = new List<IViewModel>();
            tabItems.Add(new ItemListViewModel());
            //tabItems.Add(new 

            this.TabItems = tabItems;
        }

        #endregion

        #region Fields

        private int _selectedTabIndex = 0;
        private IEnumerable<IViewModel> _tabItems = null;

        #endregion

        #region Properties

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    OnPropertyChanged("SelectedTabIndex");
                }
            }
        }

        public IEnumerable<IViewModel> TabItems
        {
            get { return _tabItems; }
            set
            {
                if (_tabItems != value)
                {
                    _tabItems = value;
                    OnPropertyChanged("TabItems");
                }
            }
        }

        #endregion
    }
}