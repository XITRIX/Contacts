using Foundation;
using System;
using UIKit;

using Contacts.Core.UserData;

namespace Contacts.iOS {
    public partial class UserDetailsViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate {
       UserDetailsViewModel viewModel;

        public UserDetailsViewController(IntPtr handle) : base(handle) {
        }

        public void Initialize(User user) {
            viewModel = new UserDetailsViewModel(user);
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            tableView.DataSource = this;
            tableView.Delegate = this;

            tableView.TableFooterView = new UIView();
        }

        public nint RowsInSection(UITableView tableView, nint section) {
            return viewModel.GetRowsCount();
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            var item = viewModel.GetItemByIndexPath(indexPath);
            var user = viewModel.GetUser();

            var cell = tableView.DequeueReusableCell(item.CellIdentifire, indexPath);
            switch (item.type) {
                case UserDetailsCellViewModel.ItemType.NameAndPicture:
                    ((DetailsHeaderCell)cell).SetData(user.GetFullName(), user.picture.large);
                    break;
                case UserDetailsCellViewModel.ItemType.Phone:
                    ((DetailCell)cell).SetData("Телефон", user.phone);
                    break;
                case UserDetailsCellViewModel.ItemType.EMail:
                    ((DetailCell)cell).SetData("E-Mail", user.email);
                    break;
                case UserDetailsCellViewModel.ItemType.Adress:
                    ((DetailsAdressCell)cell).SetData(user.location);
                    break;
            }
            return cell;
        }
    }
}