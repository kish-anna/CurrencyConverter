using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace CurrencyConverter.Android
{
    public class MyViewHolder : RecyclerView.ViewHolder
    {
        //public TextView TextView { get; set; }
        public TextView CurrencyName { get; set; }
        public TextView SellingPrice { get; set; }
        public TextView PurchasePrice { get; set; }

        public MyViewHolder(View v) : base(v)
        {

            //TextView = v;
            CurrencyName = v.FindViewById<TextView>(Resource.Id.CurrencyName);
            SellingPrice = v.FindViewById<TextView>(Resource.Id.SellingPrice);
            PurchasePrice = v.FindViewById<TextView>(Resource.Id.PurchasePrice);
        }
    }
}
