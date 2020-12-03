using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class ElasticTextField : UITextField
    {
        EView elasticView;
        // float overshootAmount = 40.0f;
        
        public ElasticTextField()
        {
            SetUpView();
        }
        
        public ElasticTextField(IntPtr handle) : base(handle)
        {
            SetUpView();
        }

        public ElasticTextField(CGRect frame) : base(frame)
        {
            SetUpView();
        }

        public ElasticTextField(NSCoder coder) : base(coder)
        {
            SetUpView();
        }

        private void SetUpView()
        {
            ClipsToBounds = false;
            BorderStyle = UITextBorderStyle.None;

            elasticView = new EView(Bounds);
            elasticView.BackgroundColor = BackgroundColor;
            AddSubview(elasticView);
            
            BackgroundColor = UIColor.Clear;
            elasticView.UserInteractionEnabled = false;
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            
            elasticView.TouchesBegan(touches, evt);
        }
    }
    

    
}