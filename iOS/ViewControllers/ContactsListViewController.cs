using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

using UIKit;
using Foundation;

namespace Contacts.iOS {
    public partial class ContactsListViewController : UIViewController, IUITableViewDataSource, IUITableViewDelegate {
        ContactsListViewModel viewModel;

        public ContactsListViewController(IntPtr handle) : base(handle) {
        }

        public override void ViewDidLoad() {
            base.ViewDidLoad();

            tableView.DataSource = this;
            tableView.Delegate = this;

            viewModel = new ContactsListViewModel(tableView.ReloadData);
        }

        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView) {
            return viewModel.GetNumberOfSections();
        }

        public nint RowsInSection(UITableView tableView, nint section) {
            return viewModel.GetRowsInSection(section);
        }

        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath) {
            var cell = tableView.DequeueReusableCell("UserCell", indexPath);
            cell.TextLabel.AttributedText = viewModel.GetUserNameAttributedText(indexPath);
            return cell;
        }

        [Export("tableView:titleForHeaderInSection:")]
        public string TitleForHeader(UITableView tableView, nint section) {
            return viewModel.GetTitleForHeader(section);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender) {
            if (segue.Identifier == "UserDetails") {
                ((UserDetailsViewController)segue.DestinationViewController).Initialize(viewModel.GetUserByIndexPath(tableView.IndexPathForSelectedRow));
            }
        }
    }
}
