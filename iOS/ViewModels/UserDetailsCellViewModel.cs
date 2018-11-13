using System;

using Contacts.Core.UserData;

using UIKit;

namespace Contacts.iOS {
    public class UserDetailsCellViewModel {
        public ItemType type;

        public UserDetailsCellViewModel(ItemType type) {
            this.type = type;
        }

        public string CellIdentifire {
            get {
                switch (type) {
                    case ItemType.Adress:
                        return "AdressCell";
                    case ItemType.EMail:
                        return "DetailCell";
                    case ItemType.NameAndPicture:
                        return "Header";
                    case ItemType.Phone:
                        return "DetailCell";
                }
                return "";
            }
        }

        public enum ItemType {
            NameAndPicture,
            Phone,
            EMail,
            Adress
        }
    }
}
