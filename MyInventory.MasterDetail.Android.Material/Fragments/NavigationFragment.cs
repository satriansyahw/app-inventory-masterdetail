using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(NavigationBindingProvider))]
    public class NavigationListFragment : RecyclerViewFragment<NavigationViewModel>
    {
        #region Constructors

        public NavigationListFragment()
        {
        }

        public NavigationListFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.CellStyle = CellStyle.NavigationDrawer;
            this.InteractionMode = ListViewInteraction.Navigation;
        }

        #endregion
    }
}