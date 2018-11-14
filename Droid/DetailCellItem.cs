using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Contacts.Droid {
    class DetailCellItem {
        public ItemType type;

        public DetailCellItem(ItemType type) {
            this.type = type;
        }

        public enum ItemType {
            NameAndPicture,
            Phone,
            EMail,
            Adress
        }
    }
}