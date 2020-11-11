using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace CurrencyConverter
{
    class CurrencyTVS : UITableViewSource
    {
        private List<CurrencyRate> currency;

        public CurrencyTVS(List<CurrencyRate> currency)
        {
            this.currency = currency;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (CurrencyCell)tableView.DequeueReusableCell("cell_id", indexPath);

            var currencyRate = currency[indexPath.Row];

            cell.UpdateCell(currencyRate);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return currency.Count;
        }
    }
}