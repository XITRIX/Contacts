using Foundation;
using System;
using UIKit;

using Contacts.Core.UserData;

namespace Contacts.iOS {
    public partial class UserDetailsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate {
        public User user;

        public UserDetailsViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            tableView.DataSource = this;
            tableView.Delegate = this;

            tableView.TableFooterView = new UIView();
        }

        public nint RowsInSection(UITableView tableView, nint section) {
            return 4;
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            if (indexPath.Row == 0) {
                var cell = (DetailsHeaderCell)tableView.DequeueReusableCell("Header", indexPath);
                cell.SetName(user.GetFullName(true));
                cell.SetImage(user.picture.large);
                return cell;
            } else if (indexPath.Row == 1) {
                var cell = (DetailCell)tableView.DequeueReusableCell("DetailCell", indexPath);
                cell.SetTitleText("Телефон");
                cell.SetDetailText(user.phone);
                return cell;
            } else if (indexPath.Row == 2) {
                var cell = (DetailCell)tableView.DequeueReusableCell("DetailCell", indexPath);
                cell.SetTitleText("E-Mail");
                cell.SetDetailText(user.email);
                return cell;
            } else if (indexPath.Row == 3) {
                var cell = (DetailsAdressCell)tableView.DequeueReusableCell("AdressCell", indexPath);
                cell.SetStreetText(user.location.street);
                cell.SetCityText(user.location.city);
                cell.SetStateText(user.location.state);
                cell.SetPostcodeText(user.location.postcode);
                return cell;
            }
            return null;
        }
    }
}