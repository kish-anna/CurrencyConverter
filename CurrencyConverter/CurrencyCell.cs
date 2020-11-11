using Foundation;
using System;
using UIKit;

namespace CurrencyConverter
{
    public partial class CurrencyCell : UITableViewCell
    {
        public CurrencyCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(CurrencyRate currencyRate)
        {
            CurrencyLabel.Text = currencyRate.CurrencyName;
            SellingPriceLabel.Text = currencyRate.SellingPrice;
            PurchasePriceLabel.Text = currencyRate.PurchasePrice;
        }
    }
}