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

using Contacts.Core.UserData;

namespace Contacts.Droid {

    class ContactsListViewModel {
        Core.UserManager userManager;

        public ContactsListViewModel(Action<Exception> completion) {
            userManager = new Core.UserManager(completion);
        }

        public List<User> GetUsers() {
            return userManager.GetUsers();
        }

        public void OnCellClick(Activity activity, int position) {
            var intent = new Intent(activity, typeof(ContactDetailsActivity));
            intent.PutExtra("User", userManager.GetUserAt(position).Serialize());
            activity.StartActivity(intent);
        }
    }
}