using Foundation;
using System;
using UIKit;

namespace Contacts.iOS {
    public partial class DetailsHeaderCell : UITableViewCell {
        public DetailsHeaderCell(IntPtr handle) : base(handle) {
        }

        [Export("awakeFromNib")]
        public override void AwakeFromNib() {
            base.AwakeFromNib();

            image.Layer.CornerRadius = image.Frame.Height / 2;
            image.Layer.MasksToBounds = true;
        }

        public void SetData(string name, string url) {
            this.name.Text = name;
            Utils.UIImageFromUrl(url, (image) => {
                this.image.Image = image;
            });
        }
    }
}