using System;
using Portable;
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

            DataSource = new CollectionSource(this, CurrencyKeyData.Data);
            // Delegate = new WaterfallCollectionDelegate(this);
        }
    }
}