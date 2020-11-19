using System;
using Foundation;
using Portable;
using UIKit;

namespace CurrencyConverter.iOS
{
    public class CollectionSource : UICollectionViewDataSource
    {
        private CurrencyCollectionView currencyCollectionView;

        private CurrencyKey[] data;

        public CollectionSource(CurrencyCollectionView currencyCollectionView, CurrencyKey[] data )
        {
            this.currencyCollectionView = currencyCollectionView;
            this.data = data;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = (CurrencyCell) collectionView.DequeueReusableCell("cell", indexPath);

            var currencyRate = data[indexPath.Row];

            cell.UpdateCell(currencyRate);

            return cell;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return data.Length;
        }
        
        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return 1;
        }
    }
}