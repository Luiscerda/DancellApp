using DancellApp.Controls;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Platform;
using UIKit;

namespace DancellApp.Platforms.iOS
{
    public  class CustomViewCellMapper : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var cell = base.GetCell(item, reusableCell, tv);

            cell.SelectedBackgroundView = new UIView
            {
                BackgroundColor = ((CustomViewCell)item).SelectBackgroundColor.ToPlatform()
            };

            return cell;
        }
    }
}
