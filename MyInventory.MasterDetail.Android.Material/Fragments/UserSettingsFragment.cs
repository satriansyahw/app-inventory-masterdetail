using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    public class UserSettingsFragment : FormFragment<UserSettingsViewModel>
    {
        #region Constructors

        public UserSettingsFragment()
        {
        }

        public UserSettingsFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.AddBarItem(new BarItem("SaveButton", CommandItemType.Done));
        }

        #endregion
    }
}