using System;
using System.Threading;

using UIKit;
using Foundation;

namespace Contacts.iOS {
    public static class Utils {
        public static void UIImageFromUrl(string uri, Action<UIImage> completion) {
            new Thread(() => {
                using (var url = new NSUrl(uri))
                using (var data = NSData.FromUrl(url)) {
                    var image = UIImage.LoadFromData(data);
                    CoreFoundation.DispatchQueue.MainQueue.DispatchAsync(() => {
                        completion.Invoke(image);
                    });
                }
            }).Start();
        }
    }
}
