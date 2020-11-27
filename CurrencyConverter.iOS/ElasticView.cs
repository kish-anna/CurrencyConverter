using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace CurrencyConverter.iOS
{
    public class ElasticView : UIView

    {
        
        private UIView topControlPointView = new UIView();
        private UIView leftControlPointView = new UIView();
        private UIView bottomControlPointView = new UIView();
        private UIView rightControlPointView = new UIView();

        private CAShapeLayer elasticShape = new CAShapeLayer();

        public ElasticView(CGRect frame) : base(frame)
        {
            SetupComponents();
        }
        
        public ElasticView(NSCoder coder) : base(coder)
        {
            SetupComponents();
        }

        private void SetupComponents()
        {
            elasticShape.FillColor = BackgroundColor?.CGColor;
            elasticShape.Path = UIBezierPath.FromRect(Bounds).CGPath;
            
            UIView[] controlPoints = {topControlPointView, leftControlPointView,bottomControlPointView, rightControlPointView};

            for (int i = 0; i < controlPoints.Length; i++)
            {
                // UIView controlPoint = controlPoints[i];
                AddSubview(controlPoints[i]);
                controlPoints[i].Frame = new CGRect(x: 0.0, y: 0.0, width: 5.0, height: 5.0);
                controlPoints[i].BackgroundColor = UIColor.Blue;
            }

            PositionControlPoints();
        }

        private void PositionControlPoints()
        {
            topControlPointView.Center = new CGPoint(Bounds.GetMidX(), 0.0);
            leftControlPointView.Center = new CGPoint(0.0, Bounds.GetMidY());
            bottomControlPointView.Center = new CGPoint(Bounds.GetMidX(), Bounds.GetMaxY());
            rightControlPointView.Center = new CGPoint(Bounds.GetMaxX(), Bounds.GetMidY());
        }



    }
}