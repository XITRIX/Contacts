using Foundation;
using System;
using UIKit;

namespace Contacts.iOS {
    public partial class DetailCell : UITableViewCell {
        public DetailCell(IntPtr handle) : base(handle) {
        }

        public void SetTitleText(string text) {
            title.Text = text;
        }

        public void SetDetailText(string text) {
            detail.Text = text;
        }
    }
}