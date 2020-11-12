using System;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class CurrencyCell : UICollectionViewCell
    {
        public CurrencyKey CurrencyKey { get; private set; }

        public CurrencyCell(IntPtr handle) : base(handle)
        {
        }

        internal void UpdateCell(CurrencyKey currencyKey)
        {
            CurrencyKey = currencyKey;

            CurrencyLabel.Text = currencyKey.CurrencyName;
            SellingPriceLabel.Text = currencyKey.SellingPrice.ToString();
            PurchasePriceLabel.Text = currencyKey.PurchasePrice.ToString();
        }
    }
}