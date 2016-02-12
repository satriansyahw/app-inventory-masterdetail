using Intersoft.Crosslight.Forms;
using Intersoft.Crosslight.iOS;
using MyInventory.ViewModels;

namespace MyInventory.iOS
{
    public partial class ItemEditViewController : UIFormViewController<ItemEditorViewModel>
    {
        #region Methods

        protected override void InitializeView()
        {
            base.InitializeView();

            // customize form metadata
            var thumbnailImage = this.Form.GetProperty("ThumbnailImage");
            var imageAttribute = thumbnailImage.GetAttribute<ImageAttribute>();

            if (this.IsOS7())
                imageAttribute.UseCircleMask = true;
        }

        #endregion
    }
}