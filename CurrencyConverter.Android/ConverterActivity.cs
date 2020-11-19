using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Portable;


namespace CurrencyConverter.Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class ConverterActivity : Activity
    {
        private ICalc calc;
        
        public string CurrencyNameValue = "";
        public float SellingPriceValue = 0;
        public float PurchasePriceValue = 0;
        private EditText userInput;
        private TextView resultPrice;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.layout_translation_carrency);
            
            calc = new Portable.Result();

            CurrencyNameValue = this.Intent.GetStringExtra("currencyName");
            var name = FindViewById<TextView>(Resource.Id.textViewKey);
            name.Text = CurrencyNameValue;

            SellingPriceValue = this.Intent.GetFloatExtra("sellingPrice", 0);
            var sell = FindViewById<TextView>(Resource.Id.sellPrice);
            sell.Text = SellingPriceValue.ToString();

            PurchasePriceValue = this.Intent.GetFloatExtra("purchasePrice", 0);
            var buy = FindViewById<TextView>(Resource.Id.buyPrice);
            buy.Text = PurchasePriceValue.ToString();

            userInput = FindViewById<EditText>(Resource.Id.userInput);
            resultPrice = FindViewById<TextView>(Resource.Id.resultTextView);

            var sellButton = FindViewById<Button>(Resource.Id.SellButton);
            var buyButton = FindViewById<Button>(Resource.Id.BuyButton);

            sellButton.Click += SellTouch;
            buyButton.Click += BuyTouch;

        }
        
        void SellTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(SellingPriceValue, userInput.Text);
            resultPrice.Text = result.ToString();
        }
        
        void BuyTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(PurchasePriceValue, userInput.Text);
            resultPrice.Text = result.ToString();
        }
    }
    
}
