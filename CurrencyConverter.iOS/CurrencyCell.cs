using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class CurrencyCell : UICollectionViewCell
    {
        //public CurrencyCell(IntPtr handle)
        //{
        //}

        internal void UpdateCell(CurrencyRate currencyRate)
        {
            CurrencyLabel.Text = currencyRate.CurrencyName;
            SellingPriceLabel.Text = currencyRate.SellingPrice;
            PurchasePriceLabel.Text = currencyRate.PurchasePrice;
        }
    }
}
