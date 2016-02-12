using Intersoft.Crosslight;
using Intersoft.Crosslight.WinRT;
using MyInventory.ViewModels;
using MyInventory.WinRT.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The Grouped Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234231

namespace MyInventory.WinRT
{
    /// <summary>
    /// A page that displays a grouped collection of items.
    /// </summary>
    [ViewModelType(typeof(ItemListViewModel))]
    public sealed partial class GroupedItemsPage : LayoutAwarePage, IListPage
    {
        public GroupedItemsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The ViewModel for this page
        /// </summary>
        public new ItemListViewModel ViewModel
        {
            get
            {
                return base.ViewModel as ItemListViewModel;
            }
        }
    }
}
