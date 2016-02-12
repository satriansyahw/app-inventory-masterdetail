using Intersoft.Crosslight;
using MyInventory.ViewModels;
using MyInventory.WinRT.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

// The Item Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234232

namespace MyInventory.WinRT
{
    /// <summary>
    /// A page that displays details for a single item within a group while allowing gestures to
    /// flip through other items belonging to the same group.
    /// </summary>
    [ViewModelType(typeof(ItemDetailViewModel))]
    public sealed partial class ItemDetailPage : LayoutAwarePage
    {
        public ItemDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The ViewModel for this page
        /// </summary>
        public new ItemDetailViewModel ViewModel
        {
            get
            {
                return base.ViewModel as ItemDetailViewModel;
            }
        }
    }
}
