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

using Android.Support.V7.Widget;

using Contacts.Core.UserData;

namespace Contacts.Droid {
    class ContactDetailsRecyclerAdapter : RecyclerView.Adapter {
        List<DetailCellItem> data;
        User user;

        public ContactDetailsRecyclerAdapter(User user) {
            this.user = user;
            data = new List<DetailCellItem>();
            data.Add(new DetailCellItem(DetailCellItem.ItemType.NameAndPicture));
            data.Add(new DetailCellItem(DetailCellItem.ItemType.Phone));
            data.Add(new DetailCellItem(DetailCellItem.ItemType.EMail));
            data.Add(new DetailCellItem(DetailCellItem.ItemType.Adress));
        }

        public override int ItemCount => data.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position) {
            switch (data[position].type) {
                case DetailCellItem.ItemType.NameAndPicture:
                    var headerCell = holder as HeaderViewHolder;
                    headerCell.title.Text = user.GetFullName(true);
                    Utils.GetImageBitmapFromUrl(headerCell.view.Context, user.picture.large, (img) => {
                        headerCell.image.SetImageBitmap(img);
                    });
                    break;
                case DetailCellItem.ItemType.Phone:
                    var phoneCell = holder as DetailViewHolder;
                    phoneCell.title.Text = "Телефон";
                    phoneCell.subtitle.Text = user.phone;
                    break;
                case DetailCellItem.ItemType.EMail:
                    var emailCell = holder as DetailViewHolder;
                    emailCell.title.Text = "E-Mail";
                    emailCell.subtitle.Text = user.email;
                    break;
                case DetailCellItem.ItemType.Adress:
                    var adressCell = holder as AdressViewHolder;
                    adressCell.title.Text = "Адрес";
                    adressCell.street.Text = $"Улица: {user.location.street}";
                    adressCell.city.Text = $"Город: {user.location.city}";
                    adressCell.state.Text = $"Штат: {user.location.state}";
                    adressCell.postcode.Text = $"Zip код: {user.location.postcode}";
                    break;
            }
        }

        public override int GetItemViewType(int position) {
            return (int)data[position].type;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) {
            View view;
            switch ((DetailCellItem.ItemType)viewType) {
                case DetailCellItem.ItemType.NameAndPicture:
                    view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DetailsHeaderItem, parent, false);
                    return new HeaderViewHolder(view);
                case DetailCellItem.ItemType.Phone:
                    view = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.TwoLineListItem, parent, false);
                    return new DetailViewHolder(view);
                case DetailCellItem.ItemType.EMail:
                    view = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.TwoLineListItem, parent, false);
                    return new DetailViewHolder(view);
                case DetailCellItem.ItemType.Adress:
                    view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.DetailsAdressItem, parent, false);
                    return new AdressViewHolder(view);
            }
            return null;
        }

        class HeaderViewHolder : RecyclerView.ViewHolder {
            public View view;
            public ImageView image;
            public TextView title;

            public HeaderViewHolder(View view) : base(view) {
                this.view = view;
                image = view.FindViewById<ImageView>(Resource.Id.image);
                title = view.FindViewById<TextView>(Resource.Id.title);
            }
        }

        class DetailViewHolder : RecyclerView.ViewHolder {
            public View view;
            public TextView title;
            public TextView subtitle;

            public DetailViewHolder(View view) : base(view) {
                this.view = view;
                title = view.FindViewById<TextView>(Android.Resource.Id.Text1);
                subtitle = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            }
        }

        class AdressViewHolder : RecyclerView.ViewHolder {
            public View view;
            public TextView title;
            public TextView street;
            public TextView city;
            public TextView state;
            public TextView postcode;

            public AdressViewHolder(View view) : base(view) {
                this.view = view;
                title = view.FindViewById<TextView>(Resource.Id.title);
                street = view.FindViewById<TextView>(Resource.Id.street);
                city = view.FindViewById<TextView>(Resource.Id.city);
                state = view.FindViewById<TextView>(Resource.Id.state);
                postcode = view.FindViewById<TextView>(Resource.Id.postcode);
            }
        }
    }
}