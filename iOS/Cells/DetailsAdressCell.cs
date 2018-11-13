using Foundation;
using System;
using UIKit;

using Contacts.Core.UserData;

namespace Contacts.iOS {
    public partial class DetailsAdressCell : UITableViewCell {
        public DetailsAdressCell(IntPtr handle) : base(handle) {
        }

        public void SetData(Location location) {
            this.street.Text = $"Улица: {location.street}";
            this.city.Text = $"Город: {location.city}";
            this.state.Text = $"Штат: {location.state}";
            this.postcode.Text = $"Zip код: {location.postcode}";
        }

        public void SetData(string street, string city, string state, string postcode) {
            this.street.Text = $"Улица: {street}";
            this.city.Text = $"Город: {city}";
            this.state.Text = $"Штат: {state}";
            this.postcode.Text = $"Zip код: {postcode}";
        }
    }
}