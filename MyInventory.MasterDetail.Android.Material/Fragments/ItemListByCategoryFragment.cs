using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android;
using Intersoft.Crosslight.Android.v7;
using Intersoft.Crosslight.Android.v7.ComponentModels;
using MyInventory.ViewModels;
using EditAction = Intersoft.Crosslight.Android.v7.ComponentModels.EditAction;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    public class ItemListByCategoryFragment : RecyclerViewFragment<ItemListByCategoryViewModel>
    {
        #region Constructors

        public ItemListByCategoryFragment()
        {
        }

        public ItemListByCategoryFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Properties

        protected override int ItemLayoutId
        {
            get { return Resource.Layout.item_layout; }
        }

        #endregion

        #region Methods

        protected override void Initialize()
        {
            base.Initialize();

            // Defines floating action button.
            this.FloatingActionButtons.Add(new FloatingActionButton("AddButton")
            {
                Position = FloatingActionButtonPosition.BottomRight,
                CommandItemType = CommandItemType.Add,
                Direction = FloatingActionButtonDirection.Up,
                HideOnScrollUp = true
            });

            // Defines contextual action.
            ListContextualToolbarSettings settings = this.ContextualToolbarSettings as ListContextualToolbarSettings;
            if (settings != null)
            {
                settings.Mode = ContextualMode.Default;
                settings.CheckAllEnabled = true;
                settings.CheckAllMargin = 0;
                settings.BarItems.Add(new BarItem("DeleteButton", CommandItemType.Trash));
            }

            // Defines editing action from swipe gesture.
            this.EditActions.Add(new EditAction("Sold"));
            this.EditActions.Add(new EditAction("Delete", true));

            // Recycler View configuration
            this.InteractionMode = ListViewInteraction.Navigation;
            this.ChoiceInputMode = ChoiceInputMode.Single;
            this.EditingOptions = EditingOptions.AllowEditing | EditingOptions.AllowMultipleSelection;

            // Image Loader settings
            this.ImageLoaderSettings.AnimateOnLoad = true;
            this.ImageLoaderSettings.CacheExpirationPolicy = CacheExpirationPolicy.AutoDetect;

            // Defines shared elements
            this.SourceSharedElementIds.Add(Resource.Id.Icon);
            this.AutoSelectFirstItem = true;

            this.IconId = Resource.Drawable.ic_toolbar;
        }

        #endregion
    }
}