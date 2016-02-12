// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace MyInventory.iOS
{
    partial class AboutViewController
    {
        [Outlet]
        UIKit.UILabel IntroductionLabel { get; set; }

        [Outlet]
        UIKit.UILabel AboutLabel { get; set; }

        [Outlet]
        UIKit.UIButton LearnMoreButton { get; set; }

        [Outlet]
        UIKit.UILabel FooterLabel { get; set; }

        void ReleaseDesignerOutlets()
        {
            if (IntroductionLabel != null)
            {
                IntroductionLabel.Dispose();
                IntroductionLabel = null;
            }

            if (AboutLabel != null)
            {
                AboutLabel.Dispose();
                AboutLabel = null;
            }

            if (LearnMoreButton != null)
            {
                LearnMoreButton.Dispose();
                LearnMoreButton = null;
            }

            if (FooterLabel != null)
            {
                FooterLabel.Dispose();
                FooterLabel = null;
            }
        }
    }
}
