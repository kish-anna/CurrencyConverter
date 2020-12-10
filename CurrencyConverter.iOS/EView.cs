using System;
using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace CurrencyConverter.iOS
{
    public partial class EView : UIView
    {
        private UIView topControlPointView = new UIView();
        private UIView leftControlPointView = new UIView();
        private UIView bottomControlPointView = new UIView();
        private UIView rightControlPointView = new UIView();

        private CAShapeLayer elasticShape = new CAShapeLayer();

        // override UIColor BackgroundColor
        public override UIColor BackgroundColor
        {
            set
            {
                elasticShape.FillColor = value.CGColor;
                base.BackgroundColor = UIColor.Clear;
            }
        }

        public EView()
        {
            SetupComponents();
        }

        public EView(IntPtr handle) : base(handle)
        {
            SetupComponents();
        }

        public EView(CGRect frame) : base(frame)
        {
            SetupComponents();
        }

        public EView(NSCoder coder) : base(coder)
        {
            SetupComponents();
        }

        private void SetupComponents()
        {
            elasticShape.FillColor = BackgroundColor?.CGColor;
            elasticShape.Path = UIBezierPath.FromRect(Bounds).CGPath;
            Layer.AddSublayer(elasticShape);

            UIView[] controlPoints =
                {topControlPointView, leftControlPointView, bottomControlPointView, rightControlPointView};

            for (int i = 0; i < controlPoints.Length; i++)
            {
                // UIView controlPoint = controlPoints[i];
                AddSubview(controlPoints[i]);
                controlPoints[i].Frame = new CGRect(x: 0.0, y: 0.0, width: 5.0, height: 5.0);
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

        private CGPath bezierPathForControlPoints()
        {
            UIBezierPath path = new UIBezierPath();

            var top = topControlPointView.Layer.PresentationLayer.Position;
            var left = leftControlPointView.Layer.PresentationLayer.Position;
            var bottom = bottomControlPointView.Layer.PresentationLayer.Position;
            var right = rightControlPointView.Layer.PresentationLayer.Position;

            var width = Frame.Size.Width;
            var height = Frame.Size.Height;

            path.MoveTo(new CGPoint(0, 0));
            path.AddQuadCurveToPoint(new CGPoint(width, 0), top);
            path.AddQuadCurveToPoint(new CGPoint(width, height), right);
            path.AddQuadCurveToPoint(new CGPoint(0, height), bottom);
            path.AddQuadCurveToPoint(new CGPoint(0, 0), left);

            return path.CGPath;
        }

        public void UpdateLoop()
        {
            elasticShape.Path = bezierPathForControlPoints();
        }

        // private void initDisplayLink()
        // {
        // 	
        //
        // 	return displayLink;
        // }

        private CADisplayLink DisplayLink
        {
            get
            {
                var d = CADisplayLink.Create(UpdateLoop);
                d.AddToRunLoop(NSRunLoop.Current, NSRunLoopMode.Common);

                return d;
            }
        }


        private void StartUpdateLoop()
        {
            DisplayLink.Paused = false;
        }

        private void StopUpdateLoop()
        {
            DisplayLink.Paused = true;
        }


        public void animateControlPoints()
        {
            var overshootAmount = 30.0f;
            //
            // var springAnimation = new CASpringAnimation();
            // springAnimation.Duration = 0.25;
            // springAnimation.Damping = 0.9f;
            // springAnimation.InitialVelocity = 1.5f;
            //
            // topControlPointView.Center = new CGPoint(topControlPointView.Center.X, topControlPointView.Center.Y - overshootAmount);
            // leftControlPointView.Center = new CGPoint(leftControlPointView.Center.X - overshootAmount, leftControlPointView.Center.Y);
            // bottomControlPointView.Center = new CGPoint(bottomControlPointView.Center.X, bottomControlPointView.Center.Y + overshootAmount);
            // rightControlPointView.Center = new CGPoint(rightControlPointView.Center.X + overshootAmount, rightControlPointView.Center.Y);

            AnimateNotify(0.25, 0.0, 0.9f, 1.5f, UIViewAnimationOptions.PreferredFramesPerSecondDefault, () =>
                {
                    topControlPointView.Center = new CGPoint(topControlPointView.Center.X,
                        topControlPointView.Center.Y - overshootAmount);
                    leftControlPointView.Center = new CGPoint(leftControlPointView.Center.X - overshootAmount,
                        leftControlPointView.Center.Y);
                    bottomControlPointView.Center = new CGPoint(bottomControlPointView.Center.X,
                        bottomControlPointView.Center.Y + overshootAmount);
                    rightControlPointView.Center = new CGPoint(rightControlPointView.Center.X + overshootAmount,
                        rightControlPointView.Center.Y);
                },
                finished =>
                {
                    AnimateNotify(0.45, 0.0, 0.15f, 5.5f, UIViewAnimationOptions.PreferredFramesPerSecondDefault,
                        () => { PositionControlPoints(); }, b => { StopUpdateLoop(); });
                });
        }


        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            // base.TouchesBegan(touches, evt);

            StartUpdateLoop();
            animateControlPoints();
        }
    }
}