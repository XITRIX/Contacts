using System;
using System.Collections.Generic;

using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

using Contacts.Core.UserData;

namespace Contacts.Droid {
    public class ContactsListRecyclerAdapter : RecyclerView.Adapter {
        List<User> data;
        Action<int> onClickEvent;

        public ContactsListRecyclerAdapter(List<User> data, Action<int> onClickEvent) {
            this.data = data;
            this.onClickEvent = onClickEvent;
        }

        public override int ItemCount => data.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            var cellHolder = holder as CellViewHolder;
            cellHolder.title.Text = data[position].GetFullName();
            cellHolder.position = position;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            View view = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);
            return new CellViewHolder(view, onClickEvent);
        }

        class CellViewHolder : RecyclerView.ViewHolder {
            public View view;
            public TextView title;
            public int position;

            public CellViewHolder(View item, Action<int> onClickEvent) : base(item) {
                view = item;
                title = item.FindViewById<TextView>(Android.Resource.Id.Text1);

                view.Click += delegate {
                    onClickEvent(position);
                };
            }
        }
    }
}
