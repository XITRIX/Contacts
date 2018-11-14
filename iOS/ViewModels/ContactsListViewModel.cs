using System;
using System.Collections.Generic;

using Contacts.Core;
using Contacts.Core.UserData;

using Foundation;

namespace Contacts.iOS {
    public class ContactsListViewModel {

        private readonly UserManager userManager;
        private List<char> tableDataKeys;
        private Dictionary<char, List<User>> tableData;

        public ContactsListViewModel(Action completion) {
            userManager = new UserManager(() => {
                tableData = userManager.GetAlphabeticallySortedUsersDictionary();
                tableDataKeys = (new List<char>(tableData.Keys));
                tableDataKeys.Sort((a, b) => a.CompareTo(b));
                completion();
            });
        }

        public int GetNumberOfSections() {
            return tableDataKeys == null ? 0 : tableDataKeys.Count;
        }

        public int GetRowsInSection(nint section) {
            return tableData[tableDataKeys[Convert.ToInt32(section)]].Count;
        }

        public string GetTitleForHeader(nint section) {
            return tableDataKeys[Convert.ToInt32(section)].ToString();
        }

        public NSMutableAttributedString GetUserNameAttributedText(NSIndexPath indexPath) {
            User user = tableData[tableDataKeys[indexPath.Section]][indexPath.Row];
            var first = new NSMutableAttributedString(user.name.UpperFirst + " ");
            var last = new NSMutableAttributedString(user.name.UpperLast, new CoreText.CTStringAttributes() {
                Font = new CoreText.CTFont(UIKit.UIFont.BoldSystemFontOfSize(17).Name, 17)
            });

            first.Append(last);
            return first;
        }

        public User GetUserByIndexPath(NSIndexPath indexPath) {
            return tableData[tableDataKeys[indexPath.Section]][indexPath.Row];
        }
    }
}
