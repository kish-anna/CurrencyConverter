// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CurrencyConverter.iOS
{
    [Register ("CurrencyCell")]
    partial class CurrencyCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CurrencyLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PurchasePriceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SellingPriceLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CurrencyLabel != null) {
                CurrencyLabel.Dispose ();
                CurrencyLabel = null;
            }

            if (PurchasePriceLabel != null) {
                PurchasePriceLabel.Dispose ();
                PurchasePriceLabel = null;
            }

            if (SellingPriceLabel != null) {
                SellingPriceLabel.Dispose ();
                SellingPriceLabel = null;
            }
        }
    }
}