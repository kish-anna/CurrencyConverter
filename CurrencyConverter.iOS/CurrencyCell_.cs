using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class CurrencyCell : UICollectionViewCell
    {
        public CurrencyCell(IntPtr handle) : base(handle)
        {
        }

        internal void UpdateCell(CurrencyKey currencyKey)
        {
            CurrencyLabel.Text = currencyKey.CurrencyName;
            SellingPriceLabel.Text = currencyKey.SellingPrice.ToString();
            PurchasePriceLabel.Text = currencyKey.PurchasePrice.ToString();
        }
    }
}