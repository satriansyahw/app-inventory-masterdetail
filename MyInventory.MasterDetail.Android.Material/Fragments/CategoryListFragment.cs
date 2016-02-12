using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(CategoryListBindingProvider))]
    public class CategoryListFragment : RecyclerViewFragment<CategoryListViewModel>
    {
        #region Constructors

        public CategoryListFragment()
        {
        }

        public CategoryListFragment(IntPtr javaReference, JniHandleOwnership transfer)
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
            this.ChoiceInputMode = ChoiceInputMode.Single;
            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}