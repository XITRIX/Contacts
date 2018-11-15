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

using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V7.View;

using Contacts.Core.UserData;

namespace Contacts.Droid {
    [Activity(Label = "Контакт")]
    public class ContactDetailsActivity : AppCompatActivity {
        User user;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RecyclerViewLayout);

            user = User.Deserialize(Intent.GetStringExtra("User"));
            
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            recyclerView.SetLayoutManager(new LinearLayoutManager(this));
            recyclerView.AddItemDecoration(new Utils.ItemOffsetDecoration(12));
            recyclerView.SetAdapter(new ContactDetailsRecyclerAdapter(user));
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            if (item.ItemId == Android.Resource.Id.Home) {
                Finish();
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}