// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Contacts.iOS
{
    [Register ("DetailCell")]
    partial class DetailCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel detail { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel title { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (detail != null) {
                detail.Dispose ();
                detail = null;
            }

            if (title != null) {
                title.Dispose ();
                title = null;
            }
        }
    }
}