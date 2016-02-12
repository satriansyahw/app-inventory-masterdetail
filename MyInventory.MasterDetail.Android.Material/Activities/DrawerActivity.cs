using System;
using Android.App;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [Activity()]
    [RegisterNavigation(IsRootView = true)]
    public class DrawerActivity : DrawerActivity<DrawerViewModel>
    {
        #region Constructors

        public DrawerActivity()
        {
        }

        public DrawerActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion
    }
}