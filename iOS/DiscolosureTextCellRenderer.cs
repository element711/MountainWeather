using Xamarin.Forms;
using Silkweb.Mobile.MountainWeather.iOS;
using Silkweb.Mobile.Core.Views;

[assembly: ExportRenderer (typeof (TextCellExtended), typeof (DiscolosureTextCellRenderer))]

namespace Silkweb.Mobile.MountainWeather.iOS
{
    public class DiscolosureTextCellRenderer : Xamarin.Forms.Platform.iOS.TextCellRenderer
    {      
        public override MonoTouch.UIKit.UITableViewCell GetCell (Cell item, MonoTouch.UIKit.UITableView tv)
        {                  
            var cell = base.GetCell (item, tv);

            var textCellExtended = item as TextCellExtended;

            if (textCellExtended.ShowDisclosure)
                cell.Accessory = MonoTouch.UIKit.UITableViewCellAccessory.DisclosureIndicator;  

            return cell;
        }
    }
}

