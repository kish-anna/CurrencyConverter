using System;
using CoreGraphics;
using Foundation;
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

            Input.Alpha = 0;

            
            

            CurrencyName.Text = CurrencyNameValue;
            SellPrice.Text = SellingPriceValue.ToString();
            BuyPrice.Text = PurchasePriceValue.ToString();

            BuyButton.TouchUpInside -= BuyTouch;
            BuyButton.TouchUpInside += BuyTouch;

            SellButton.TouchUpInside -= SellTouch;
            SellButton.TouchUpInside += SellTouch;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            // Input.Alpha = 0;
            // CurrencyName.Alpha = 0;

            UIView.Animate(1, () => { Input.Alpha = 1; });
            
            UIView.Animate(1, () =>
                {
                    CurrencyName.Frame = new CGRect(x: 100, y: 100, width: 220, height: 60);
                    Result.Center = View.Center;
                });
            
            
        }

        void BuyTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(PurchasePriceValue, Input.Text);
            Result.Text = result.ToString();
            UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: 0, y: 0, width: 250, height: 80);
                    Result.Center = View.Center;
                    Result.TextColor = UIColor.White;
                    BuyButton.BackgroundColor = UIColor.DarkGray;
                },
                () => { UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: 0, y: 0, width: 220, height: 60);
                    Result.Center = View.Center;
                    Result.TextColor = UIColor.Red;
                    BuyButton.BackgroundColor = UIColor.SystemGray4Color;
                    
                }); });
        }

        void SellTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(SellingPriceValue, Input.Text);
            Result.Text = result.ToString();
            
            UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: 0, y: 0, width: 250, height: 80);
                    Result.Center = View.Center;
                    Result.TextColor = UIColor.White;
                    SellButton.BackgroundColor = UIColor.DarkGray;
                },
                () => { UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: 0, y: 0, width: 220, height: 60);
                    Result.Center = View.Center;
                    Result.TextColor = UIColor.Red;
                    SellButton.BackgroundColor = UIColor.SystemGray4Color;
                    
                }); });
        }
    }
}