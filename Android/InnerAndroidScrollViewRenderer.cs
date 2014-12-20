using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.Android;
using Android.Views;

[assembly: ExportRenderer (typeof (ScrollView), typeof (InnerAndroidScrollViewRenderer))]

namespace Silkweb.Mobile.MountainWeather.Android
{
    /// <summary>
    /// Fix from http://forums.xamarin.com/discussion/20834/horizontal-scrollview-within-vertical-scrollview
    /// </summary>
    public class InnerAndroidScrollViewRenderer : ScrollViewRenderer
    {
        float StartX, StartY;
        int IsHorizontal=-1;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (((ScrollView)e.NewElement).Orientation == ScrollOrientation.Horizontal) IsHorizontal = 1;

        }
        public override bool DispatchTouchEvent(MotionEvent e)
        {

            switch (e.Action)
            {
                case MotionEventActions.Down:
                    StartX=e.RawX;
                    StartY=e.RawY;
                    this.Parent.RequestDisallowInterceptTouchEvent(true);
                    break;
                case MotionEventActions.Move:
                    if (IsHorizontal * Math.Abs(StartX - e.RawX) < IsHorizontal * Math.Abs(StartY - e.RawY))
                        this.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
                case MotionEventActions.Up:
                    this.Parent.RequestDisallowInterceptTouchEvent(false);
                    break;
            }

            return base.DispatchTouchEvent(e);
        }
    }
}

