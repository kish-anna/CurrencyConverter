using System;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Portable;

namespace CurrencyConverter.Android
{
    public class MyAdapter : RecyclerView.Adapter
    {
        CurrencyKey[] items;
        RecyclerView recyclerView;
        Activity context;

        public MyAdapter(Activity context, RecyclerView recyclerView, CurrencyKey[] data)
        {
            this.recyclerView = recyclerView;
            items = data;
            this.context = context;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // set the view's size, margins, paddings and layout parameters
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.layout_currency_card, parent, false);
            return new MyViewHolder(itemView);

        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as MyViewHolder;
            //holder.TextView.Text = item;
            holder.CurrencyName.Text = item.CurrencyName;
            holder.SellingPrice.Text = item.SellingPrice.ToString();
            holder.PurchasePrice.Text = item.PurchasePrice.ToString();

            holder.ItemView.Click -= RecyclerView_Click;
            holder.ItemView.Click += RecyclerView_Click;

        }

        private void RecyclerView_Click(object sender, EventArgs e)
        {
            var pos = recyclerView.GetChildAdapterPosition((View)sender);

            Intent intent = new Intent(context, typeof(ConverterActivity));
            intent.PutExtra("currencyName", items[pos].CurrencyName);
            intent.PutExtra("sellingPrice", items[pos].SellingPrice);
            intent.PutExtra("purchasePrice", items[pos].PurchasePrice);

            context.StartActivity(intent);
            context.OverridePendingTransition(Resource.Animation.right_in, Resource.Animation.go_to_screen_left_out);
        }

        public override int ItemCount
        {
            get
            {
                return items.Length;
            }
        }
    }
}
