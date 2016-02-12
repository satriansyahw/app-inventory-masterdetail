// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MyInventory
{
	[Register ("ItemDetailViewController")]
	partial class ItemDetailViewController
	{
		[Outlet]
		UIKit.UILabel CategoryLabel { get; set; }

		[Outlet]
		UIKit.UILabel DescriptionLabel { get; set; }

		[Outlet]
		UIKit.UIImageView ImageView { get; set; }

		[Outlet]
		UIKit.UILabel IsSoldLabel { get; set; }

		[Outlet]
		UIKit.UILabel LocationLabel { get; set; }

		[Outlet]
		UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		UIKit.UILabel NotesLabel { get; set; }

		[Outlet]
		UIKit.UILabel PriceLabel { get; set; }

		[Outlet]
		UIKit.UILabel PurchaseDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel QuantityLabel { get; set; }

		[Outlet]
		UIKit.UILabel SerialNumberLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CategoryLabel != null) {
				CategoryLabel.Dispose ();
				CategoryLabel = null;
			}

			if (DescriptionLabel != null) {
				DescriptionLabel.Dispose ();
				DescriptionLabel = null;
			}

			if (ImageView != null) {
				ImageView.Dispose ();
				ImageView = null;
			}

			if (IsSoldLabel != null) {
				IsSoldLabel.Dispose ();
				IsSoldLabel = null;
			}

			if (LocationLabel != null) {
				LocationLabel.Dispose ();
				LocationLabel = null;
			}

			if (NotesLabel != null) {
				NotesLabel.Dispose ();
				NotesLabel = null;
			}

			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}

			if (PurchaseDateLabel != null) {
				PurchaseDateLabel.Dispose ();
				PurchaseDateLabel = null;
			}

			if (QuantityLabel != null) {
				QuantityLabel.Dispose ();
				QuantityLabel = null;
			}

			if (SerialNumberLabel != null) {
				SerialNumberLabel.Dispose ();
				SerialNumberLabel = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}
		}
	}
}
