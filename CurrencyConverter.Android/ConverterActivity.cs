using System;
using Android.Animation;
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
        private Button sellButton;
        private Button buyButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.layout_translation_carrency);

            Animation currencyNameAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.currency_name_anim);
            Animation userInputAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.user_input_anim);
            Animation sellPriceAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.sell_price_anim);
            Animation buyPriceAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.buy_price_anim);
            

            calc = new Portable.Result();

            CurrencyNameValue = this.Intent.GetStringExtra("currencyName");
            var name = FindViewById<TextView>(Resource.Id.textViewKey);
            name.Text = CurrencyNameValue;
            name.StartAnimation(currencyNameAnimation);

            SellingPriceValue = this.Intent.GetFloatExtra("sellingPrice", 0);
            var sell = FindViewById<TextView>(Resource.Id.sellPrice);
            sell.Text = SellingPriceValue.ToString();
            sell.StartAnimation(sellPriceAnimation);

            PurchasePriceValue = this.Intent.GetFloatExtra("purchasePrice", 0);
            var buy = FindViewById<TextView>(Resource.Id.buyPrice);
            buy.Text = PurchasePriceValue.ToString();
            buy.StartAnimation(buyPriceAnimation);

            userInput = FindViewById<EditText>(Resource.Id.userInput);
            var input = FindViewById<TextView>(Resource.Id.userInput);
            input.StartAnimation(userInputAnimation);
            
            resultPrice = FindViewById<TextView>(Resource.Id.resultTextView);
            


            sellButton = FindViewById<Button>(Resource.Id.SellButton);
            buyButton = FindViewById<Button>(Resource.Id.BuyButton);

            sellButton.Click += SellTouch;
            buyButton.Click += BuyTouch;
 
        }
        

        
        void SellTouch(object sender, EventArgs args)
        {
            
            
            float result = calc.GetResult(SellingPriceValue, userInput.Text);
            resultPrice.Text = result.ToString();
            
            Animation sellButtomAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.sell_buttom_anim);
            sellButton.StartAnimation(sellButtomAnimation);

            Animation resultAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.result_anim);
            resultPrice.StartAnimation(resultAnimation);

        }
        
        void BuyTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(PurchasePriceValue, userInput.Text);
            resultPrice.Text = result.ToString();
            
            Animation buyButtomAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.buy_buttom_anim);
            buyButton.StartAnimation(buyButtomAnimation);

            Animation resultAnimation = AnimationUtils.LoadAnimation(this, Resource.Animation.result_anim);
            resultPrice.StartAnimation(resultAnimation);
        }
    }
    
}
