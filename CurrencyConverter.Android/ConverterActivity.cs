using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Portable;
using Android.Views.Animations;


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

            Animation currencyNameAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.currency_name_anim);
            Animation userInputAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.user_input_anim);

            calc = new Portable.Result();

            CurrencyNameValue = this.Intent.GetStringExtra("currencyName");
            var name = FindViewById<TextView>(Resource.Id.textViewKey);
            name.Text = CurrencyNameValue;
            name.StartAnimation(currencyNameAnimation);

            SellingPriceValue = this.Intent.GetFloatExtra("sellingPrice", 0);
            var sell = FindViewById<TextView>(Resource.Id.sellPrice);
            sell.Text = SellingPriceValue.ToString();

            PurchasePriceValue = this.Intent.GetFloatExtra("purchasePrice", 0);
            var buy = FindViewById<TextView>(Resource.Id.buyPrice);
            buy.Text = PurchasePriceValue.ToString();

            userInput = FindViewById<EditText>(Resource.Id.userInput);
            var input = FindViewById<TextView>(Resource.Id.userInput);
            input.StartAnimation(userInputAnimation);
            
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
