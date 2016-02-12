using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [RegisterNavigation(DeviceKind.Tablet)]
    public class CategoryContainerFragment : MasterDetailFragment<CategoryListViewModel>
    {
        #region Constructors

        public CategoryContainerFragment()
        {
        }

        public CategoryContainerFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion
    }
}