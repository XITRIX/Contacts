using System;
using System.Collections.Generic;

namespace Contacts.Core.UserData {
    public class JSONUsersResult {
        public List<User> results;
    }

    public class User {
        public string gender;
        public UserName name;
        public Location location;
        public string email;
        public string phone;
        public Picture picture;

        public string GetFullName(bool withTitle = false) {
            return withTitle
                ? $"{name.UpperTitle} {name.UpperFirst} {name.UpperLast}"
                    : $"{name.UpperFirst} {name.UpperLast}";
        }
    }

    public class UserName {
        public string title;
        public string first;
        public string last;

        public string UpperTitle {
            get {
                return title.FirstCharToUpper();
            }
        }

        public string UpperFirst {
            get {
                return first.FirstCharToUpper();
            }
        }

        public string UpperLast {
            get {
                return last.FirstCharToUpper();
            }
        }
    }

    public class Location {
        public string street;
        public string city;
        public string state;
        public string postcode;

    }

    public class Picture {
        public string large;
        public string medium;
        public string thumbnail;
    }
}
