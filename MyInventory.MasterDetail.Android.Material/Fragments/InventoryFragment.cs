using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [RegisterNavigation(DeviceKind.Tablet)]
    public class InventoryFragment : MasterDetailFragment<ItemListViewModel>
    {
        #region Constructors

        public InventoryFragment()
        {
        }

        public InventoryFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion
    }
}