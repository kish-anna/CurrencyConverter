// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CurrencyConverter.iOS
{
    [Register ("ViewResultController")]
    partial class ViewResultController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BuyButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView BuyPrice { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView CurrencyName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField Input { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView Result { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SellButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView SellPrice { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BuyButton != null) {
                BuyButton.Dispose ();
                BuyButton = null;
            }

            if (BuyPrice != null) {
                BuyPrice.Dispose ();
                BuyPrice = null;
            }

            if (CurrencyName != null) {
                CurrencyName.Dispose ();
                CurrencyName = null;
            }

            if (Input != null) {
                Input.Dispose ();
                Input = null;
            }

            if (Result != null) {
                Result.Dispose ();
                Result = null;
            }

            if (SellButton != null) {
                SellButton.Dispose ();
                SellButton = null;
            }

            if (SellPrice != null) {
                SellPrice.Dispose ();
                SellPrice = null;
            }
        }
    }
}