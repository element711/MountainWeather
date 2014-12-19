using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.iOS;
using Silkweb.Mobile.Core.Views;
using MonoTouch.UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (TextCellExtended), typeof (TextCellExtendedRenderer))]

namespace Silkweb.Mobile.MountainWeather.iOS
{
    public class TextCellExtendedRenderer : Xamarin.Forms.Platform.iOS.TextCellRenderer
    {      
        private UIView _bgView;

        public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
        {                  
            var cell = base.GetCell (item, tv);

            var textCellExtended = item as TextCellExtended;

            if (textCellExtended.ShowDisclosure)
                cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;

            if (textCellExtended.SelectedBackgroundColor != default(Color))
            {
                if (_bgView == null)
                {
                    _bgView = new UIView(cell.SelectedBackgroundView.Bounds);
                    _bgView.Layer.BackgroundColor = textCellExtended.SelectedBackgroundColor.ToCGColor();
                }
            
                cell.SelectedBackgroundView = _bgView;
            }

            return cell;
        }
    }
}

