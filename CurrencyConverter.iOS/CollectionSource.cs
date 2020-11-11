using System;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public class CollectionSource : UICollectionViewDataSource
    {
        private CurrencyCollectionView currencyCollectionView;

        public CollectionSource(CurrencyCollectionView currencyCollectionView)
        {
            this.currencyCollectionView = currencyCollectionView;
        }

        CurrencyKey[] data =
        {
            new CurrencyKey("RUB/USD", 78.94f, 78.35f),
            new CurrencyKey("RUB/EUR", 92.52f, 91.94f),
            new CurrencyKey("RUB/UAH", 78.94f, 78.35f),
            new CurrencyKey("RUB/BYN", 78.94f, 78.35f)
        };

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