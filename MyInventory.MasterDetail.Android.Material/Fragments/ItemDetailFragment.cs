using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using Intersoft.Crosslight.Android.v7.ComponentModels;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemDetailBindingProvider))]
    public class ItemDetailFragment : DetailFragment<ItemDetailViewModel>
    {
        #region Constructors

        public ItemDetailFragment()
        {
        }

        public ItemDetailFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ContentLayoutId
        {
            get { return Resource.Layout.item_detail_layout; }
        }

        protected override bool ShowActionBarUpButton
        {
            get
            {
                if (ServiceProvider.GetService<IApplicationService>().GetContext().Device.Kind == DeviceKind.Tablet)
                    return false;
                else
                    return true;
            }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            if (ServiceProvider.GetService<IApplicationService>().GetContext().Device.Kind != DeviceKind.Tablet)
            {
                this.ToolbarSettings.Mode = ToolbarMode.Collapsing;
                this.ToolbarSettings.CollapsingToolbarSettings.EnableParallaxImage = true;
                this.ToolbarSettings.CollapsingToolbarSettings.ExpandedHeight = 240;

                this.TargetSharedElementIds.Add(Resource.Id.parallax_image);
            }

            // Defines floating action button.
            this.FloatingActionButtons.Add(new FloatingActionButton("EditItem")
            {
                Position = FloatingActionButtonPosition.BottomRight,
                CommandItemType = CommandItemType.Edit,
                Direction = FloatingActionButtonDirection.Up,
                HideOnScrollUp = true
            });
        }

        #endregion
    }
}