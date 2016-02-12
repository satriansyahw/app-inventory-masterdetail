using System;
using Foundation;
using UIKit;

namespace MyInventory.iOS
{
    public partial class ItemCollectionViewCell : UICollectionViewCell
    {
        #region Constructors

        public ItemCollectionViewCell(IntPtr handle)
            : base(handle)
        {
        }

        #endregion

        #region Fields

        public static readonly NSString Key = new NSString("ItemCollectionViewCell");
        public static readonly UINib Nib = UINib.FromName("ItemCollectionViewCell", NSBundle.MainBundle);

        #endregion

        #region Methods

        public static ItemCollectionViewCell Create()
        {
            return (ItemCollectionViewCell) Nib.Instantiate(null, null)[0];
        }

        #endregion
    }
}