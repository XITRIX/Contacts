using System;

using Contacts.Core;

using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Contacts.Droid {
    [Activity(Label = "Contacts", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity {
        Core.UserManager userManager;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            userManager = new Core.UserManager(() => {
                recyclerView.SetAdapter(new ContactsListRecyclerAdapter(userManager.GetUsers()));
            });
            //recyclerView.SetAdapter(new ContactsListRecyclerAdapter())

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.myButton);

            //button.Click += delegate { button.Text = $"{count++} clicks!"; };

            //var dataBase = new DataBase();
            //Console.WriteLine(dataBase.users.Count);
        }
    }
}

