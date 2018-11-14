using System;
using System.Threading;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Support.V7.Widget;

namespace Contacts.Droid {
    static class Utils {
        public static void GetImageBitmapFromUrl(Context context, string url, Action<Bitmap> completion) {
            var mainThread = Thread.CurrentThread;
            
            new Thread(() => {
                Bitmap imageBitmap = null;

                using (var webClient = new WebClient()) {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0) {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

                ((Activity)context).RunOnUiThread(() => {
                    completion(imageBitmap);
                });
            }).Start();
        }

        public class ItemOffsetDecoration : RecyclerView.ItemDecoration {
            private int itemOffset;

            public ItemOffsetDecoration(int itemOffset) {
                this.itemOffset = itemOffset;
            }

            public override void GetItemOffsets(Rect outRect, View view, RecyclerView parent, RecyclerView.State state) {
                base.GetItemOffsets(outRect, view, parent, state);
                outRect.Set(itemOffset, itemOffset, itemOffset, itemOffset);
            }
        }
    }
}