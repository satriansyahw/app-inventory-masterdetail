// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace MyInventory.iOS
{
	[Register ("ItemCollectionViewCell")]
	partial class ItemCollectionViewCell
	{
		[Outlet]
		UIKit.UIImageView ImageView { get; set; }

		[Outlet]
		UIKit.UILabel TextLabel { get; set; }

		[Outlet]
		UIKit.UIImageView CheckmarkAccessory { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (TextLabel != null) {
				TextLabel.Dispose ();
				TextLabel = null;
			}

			if (CheckmarkAccessory != null) {
				CheckmarkAccessory.Dispose ();
				CheckmarkAccessory = null;
			}
		}
	}
}
