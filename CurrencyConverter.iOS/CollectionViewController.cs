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

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var pathArr = CollectionView.IndexPathsForVisibleItems;

            Action anim = () => { };

            for (int i = pathArr.Length - 1; i >= 0; i--)
            {
                var cell = CollectionView.CellForItem(pathArr[i]);
                anim = AddAnim(delegate { cell.ContentView.Alpha = 1; }, anim);
                
            }

            anim();
            var cellSelected = CollectionView.GetIndexPathsForSelectedItems();
        }

        private Action AddAnim(Action anim, Action completion)
        {
            return delegate { UIView.Animate(1, anim, completion); };
        }

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