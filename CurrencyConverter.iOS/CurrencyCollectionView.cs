using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class CurrencyCollectionView : UICollectionView
    {
        public CurrencyCollectionView(IntPtr handle) : base(handle)
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            DataSource = new CollectionSource(this);
            // Delegate = new WaterfallCollectionDelegate(this);
        }
    }
}