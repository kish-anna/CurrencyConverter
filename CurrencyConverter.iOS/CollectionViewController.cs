using System;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class CollectionViewController : UICollectionViewController
    {
        public CollectionViewController(IntPtr handle) : base(handle)
        {
        }

        // public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        // {
        //     base.ItemSelected(collectionView, indexPath);
        // }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "GoToConvert")
            {
                var controller = segue.DestinationViewController as ViewResultController;
                var cell = sender as CurrencyCell;

                if (controller == null || cell == null)
                {
                    return;
                }

                controller.CurrencyNameValue = cell.CurrencyKey.CurrencyName;
                controller.SellingPriceValue = cell.CurrencyKey.SellingPrice;
                controller.PurchasePriceValue = cell.CurrencyKey.PurchasePrice;
            }
        }
    }
}