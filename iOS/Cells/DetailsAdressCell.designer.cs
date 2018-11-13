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
    [Register ("DetailsAdressCell")]
    partial class DetailsAdressCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel city { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel postcode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel state { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel street { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (city != null) {
                city.Dispose ();
                city = null;
            }

            if (postcode != null) {
                postcode.Dispose ();
                postcode = null;
            }

            if (state != null) {
                state.Dispose ();
                state = null;
            }

            if (street != null) {
                street.Dispose ();
                street = null;
            }
        }
    }
}