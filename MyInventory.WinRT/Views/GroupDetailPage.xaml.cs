using Intersoft.Crosslight;
using MyInventory.ViewModels;
using MyInventory.WinRT.Common;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The Group Detail Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234229

namespace MyInventory.WinRT
{
    /// <summary>
    /// A page that displays an overview of a single group, including a preview of the items
    /// within the group.
    /// </summary>
    [ViewModelType(typeof(GroupDetailViewModel))]
    public sealed partial class GroupDetailPage : LayoutAwarePage
    {
        public GroupDetailPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The ViewModel for this page
        /// </summary>
        public new GroupDetailViewModel ViewModel
        {
            get
            {
                return base.ViewModel as GroupDetailViewModel;
            }
        }
    }
}
