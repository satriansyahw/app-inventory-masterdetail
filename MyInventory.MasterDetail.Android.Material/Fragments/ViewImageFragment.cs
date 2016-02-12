using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemDetailBindingProvider))]
    [RegisterNavigation("PhotoDetail")]
    public class ViewImageFragment : Fragment<ItemDetailViewModel>
    {
        #region Constructors

        public ViewImageFragment()
        {
        }

        public ViewImageFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.view_image_layout; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            this.Title = "View Image";
            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}