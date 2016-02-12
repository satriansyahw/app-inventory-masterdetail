using System;
using Android.Runtime;
using Intersoft.Crosslight;
using Intersoft.Crosslight.Android.v7;
using MyInventory.ViewModels;

namespace MyInventory.Android
{
    [ImportBinding(typeof(ItemListBindingProvider))]
    public class ItemEditFragment : FormFragment<ItemEditorViewModel>
    {
        #region Constructors

        public ItemEditFragment()
        {
        }

        public ItemEditFragment(IntPtr javaReference, JniHandleOwnership transfer)
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