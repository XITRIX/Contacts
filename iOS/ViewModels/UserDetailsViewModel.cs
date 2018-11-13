using System;
using System.Collections.Generic;

using Contacts.Core;
using Contacts.Core.UserData;

using Foundation;

namespace Contacts.iOS {
    public class UserDetailsViewModel {
        readonly User user;
        private List<UserDetailsCellViewModel> items;

        public UserDetailsViewModel(User user) {
            this.user = user;

            items = new List<UserDetailsCellViewModel> {
                new UserDetailsCellViewModel(UserDetailsCellViewModel.ItemType.NameAndPicture),
                new UserDetailsCellViewModel(UserDetailsCellViewModel.ItemType.Phone),
                new UserDetailsCellViewModel(UserDetailsCellViewModel.ItemType.EMail),
                new UserDetailsCellViewModel(UserDetailsCellViewModel.ItemType.Adress)
            };
        }

        public int GetRowsCount() {
            return items.Count;
        }

        public UserDetailsCellViewModel GetItemByIndexPath(NSIndexPath indexPath) {
            return items[indexPath.Row];
        }

        public User GetUser() {
            return user;
        }
    }
}
