using System;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class ViewResultController : UIViewController
    {
        public string CurrencyNameValue = "";
        public float SellingPriceValue = 0;
        public float PurchasePriceValue = 0;

        public ViewResultController(IntPtr handle) : base(handle)
        {
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
            float userInputFloat = 0;

            try
            {
                userInputFloat = Convert.ToSingle(Input.Text);
            }
            catch (Exception ex)
            {
            }

            var result = userInputFloat * PurchasePriceValue;

            Result.Text = result.ToString();
        }
        
        void SellTouch(object sender, EventArgs args)
        {
            float userInputFloat = 0;

            try
            {
                userInputFloat = Convert.ToSingle(Input.Text);
            }
            catch (Exception ex)
            {
            }

            var result = userInputFloat * SellingPriceValue;

            Result.Text = result.ToString();
        }
    }
}