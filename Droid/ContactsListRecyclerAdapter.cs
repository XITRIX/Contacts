using System;
using System.Collections.Generic;

using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using Contacts.Core.UserData;

namespace Contacts.Droid {
    public class ContactsListRecyclerAdapter : RecyclerView.Adapter {
        List<User> data;

        public ContactsListRecyclerAdapter(List<User> data) {
            this.data = data;
        }

        public override int ItemCount => data.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            var cellHolder = holder as CellViewHolder;
            cellHolder.title.Text = data[position].GetFullName();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            View view = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);
            return new CellViewHolder(view);
        }

        class CellViewHolder : RecyclerView.ViewHolder {
            public View view;
            public TextView title;
            public CellViewHolder(View item) : base(item) {
                view = item;
                title = item.FindViewById<TextView>(Android.Resource.Id.Text1);
            }
        }
    }
}
