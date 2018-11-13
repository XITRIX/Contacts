using Foundation;
using System;
using UIKit;

namespace Contacts.iOS {
    public partial class DetailCell : UITableViewCell {
        public DetailCell(IntPtr handle) : base(handle) {
        }

        public void SetData(string title, string detail) {
            this.title.Text = title;
            this.detail.Text = detail;
        }
    }
}