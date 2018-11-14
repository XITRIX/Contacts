using System;

using Contacts.Core;

using Android.App;
using Android.Widget;
using Android.OS;

using Android.Support.V7.App;
using Android.Support.V7.Widget;

namespace Contacts.Droid {
    [Activity(Label = "Контакты", MainLauncher = true, Icon = "@mipmap/icon")]
    public class ContactsListActivity : AppCompatActivity {
        ContactsListViewModel viewModel;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.RecyclerViewLayout);

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));

            viewModel = new ContactsListViewModel((error) => {
                if (error == null)
                    recyclerView.SetAdapter(new ContactsListRecyclerAdapter(viewModel.GetUsers(), (position) => {
                        viewModel.OnCellClick(this, position);
                    }));
            });
        }
    }
}

