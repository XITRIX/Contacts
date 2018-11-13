using Foundation;
using System;
using UIKit;

namespace Contacts.iOS {
    public partial class DetailsAdressCell : UITableViewCell {
        public DetailsAdressCell(IntPtr handle) : base(handle) {
        }

        public void SetStreetText(string text) {
            street.Text = $"Улица: {text}";
        }

        public void SetCityText(string text) {
            city.Text = $"Город: {text}";
        }

        public void SetStateText(string text) {
            state.Text = $"Штат: {text}";
        }

        public void SetPostcodeText(string text) {
            postcode.Text = $"Zip код: {text}";
        }
    }
}