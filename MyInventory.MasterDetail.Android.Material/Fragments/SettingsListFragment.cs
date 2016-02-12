using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(NavigationBindingProvider))]
    public class SettingsListFragment : RecyclerViewFragment<SettingsViewModel>
    {
        #region Constructors

        public SettingsListFragment()
        {
        }

        public SettingsListFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            // Recycler View configuration
            this.InteractionMode = ListViewInteraction.Navigation;
            this.AutoSelectFirstItem = true;
        }

        #endregion
    }
}