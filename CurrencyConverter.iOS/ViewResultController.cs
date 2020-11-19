using System;
using UIKit;
using Portable;

namespace CurrencyConverter.iOS
{
    public partial class ViewResultController : UIViewController
    {
        public string CurrencyNameValue = "";
        public float SellingPriceValue = 0;
        public float PurchasePriceValue = 0;

        private ICalc calc;
        
        public ViewResultController(IntPtr handle) : base(handle)
        {
            calc = new Result();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CurrencyName.Text = CurrencyNameValue;
            SellPrice.Text = SellingPriceValue.ToString();
            BuyPrice.Text = PurchasePriceValue.ToString();

            BuyButton.TouchUpInside -= BuyTouch;
            BuyButton.TouchUpInside += BuyTouch;
            
            SellButton.TouchUpInside -= SellTouch;
            SellButton.TouchUpInside += SellTouch;
        }
        
        void BuyTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(PurchasePriceValue, Input.Text);
            Result.Text = result.ToString();
        }
         
        void SellTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(SellingPriceValue, Input.Text);
            Result.Text = result.ToString();
        }
    }
}