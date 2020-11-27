using System;
using CoreGraphics;
using UIKit;
using Portable;

namespace CurrencyConverter.iOS
{
    public partial class ViewResultController : UIViewController
    {
        public string CurrencyNameValue = "";
        public float SellingPriceValue = 0;
        public float PurchasePriceValue = 0;
        private nfloat x;

        private ICalc calc;
        private UIFont standart;

        public ViewResultController(IntPtr handle) : base(handle)
        {
            calc = new Result();
            
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
                
            x = CurrencyName.Frame.X;
            standart = SellPrice.Font;

            CurrencyName.Frame = new CGRect(x: - (CurrencyName.Frame.Width), y: CurrencyName.Frame.Y, width: CurrencyName.Frame.Width, height: CurrencyName.Frame.Height);
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
            
            UIView.Animate(2, () =>
            {
                CurrencyName.Frame = new CGRect(x: x, y: CurrencyName.Frame.Y, width:  CurrencyName.Frame.Width, height: CurrencyName.Frame.Height);
             });
            
            UIView.Animate(1, () => { Input.Alpha = 1; });
        }

        void BuyTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(PurchasePriceValue, Input.Text);
            Result.Text = result.ToString();

            UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: Result.Frame.X - 15, y: Result.Frame.Y - 10, width: Result.Frame.Width + 30, height: Result.Frame.Height + 20);
                    Result.TextColor = UIColor.Red;
                    BuyButton.BackgroundColor = UIColor.DarkGray;
                    BuyPrice.TextColor = UIColor.Black;
                    
                },
                () => { UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: Result.Frame.X + 15, y: Result.Frame.Y + 10, width:  Result.Frame.Width - 30, height: Result.Frame.Height - 20);
                    Result.TextColor = UIColor.White;
                    BuyButton.BackgroundColor = UIColor.SystemGray4Color;
                    BuyPrice.TextColor = UIColor.White;
                    
                }); });
        }

        void SellTouch(object sender, EventArgs args)
        {
            float result = calc.GetResult(SellingPriceValue, Input.Text);
            Result.Text = result.ToString();
            
            UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: Result.Frame.X - 15, y: Result.Frame.Y - 10, width: Result.Frame.Width + 30, height: Result.Frame.Height + 20);
                    Result.TextColor = UIColor.Red;
                    SellButton.BackgroundColor = UIColor.DarkGray;
                    SellPrice.Font = SellPrice.Font.WithSize(50f);
                    SellPrice.TextColor = UIColor.Black;
                },
                () => { UIView.Animate(1, () =>
                {
                    Result.Frame = new CGRect(x: Result.Frame.X + 15, y: Result.Frame.Y + 10, width:  Result.Frame.Width - 30, height: Result.Frame.Height - 20);
                    Result.TextColor = UIColor.White;
                    SellButton.BackgroundColor = UIColor.SystemGray4Color;
                    SellPrice.Font = standart;
                    SellPrice.TextColor = UIColor.White;
                }); });
        }
    }
}