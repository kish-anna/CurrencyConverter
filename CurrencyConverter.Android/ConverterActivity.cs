using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace CurrencyConverter.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ConverterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout_translation_carrency);

            var currencyName = this.Intent.GetStringExtra("currencyName");
            var name = FindViewById<TextView>(Resource.Id.textViewKey);
            name.Text = currencyName;

            var sellPrice = this.Intent.GetFloatExtra("sellingPrice", 0);
            var sell = FindViewById<TextView>(Resource.Id.sellPrice);
            sell.Text = sellPrice.ToString();

            var buyPrice = this.Intent.GetFloatExtra("purchasePrice", 0);
            var buy = FindViewById<TextView>(Resource.Id.buyPrice);
            buy.Text = buyPrice.ToString();

            var userInput = FindViewById<EditText>(Resource.Id.userInput);

            var sellButton = FindViewById<Button>(Resource.Id.SellButton);
            var buyButton = FindViewById<Button>(Resource.Id.BuyButton);

            var resultPrice = FindViewById<TextView>(Resource.Id.resultTextView);

            sellButton.Click += delegate
            {
                float userInputFloat = 0;
                
                try
                {
                    userInputFloat = Convert.ToSingle(userInput.Text);
                }
                catch (Exception ex)
                {

                }

                var result = userInputFloat * sellPrice;

                resultPrice.Text = result.ToString();
            };

            buyButton.Click += delegate
            {
                float userInputFloat = 0;

                try
                {
                    userInputFloat = Convert.ToSingle(userInput.Text);
                }
                catch (Exception ex)
                {

                }

                var result = userInputFloat * buyPrice;

                resultPrice.Text = result.ToString();
            };

        }
    }
    
}
