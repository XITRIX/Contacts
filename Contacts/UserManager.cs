using System;
using System.Collections.Generic;
using Contacts.Core.UserData;

namespace Contacts.Core {
    public class UserManager {
        private readonly DataBase dataBase;

        public UserManager(Action onFinishLoading) {
            dataBase = new DataBase(onFinishLoading);
        }

        public User GetUserAt(int index) {
            return dataBase.users[index];
        }

        public int GetUsersCount() {
            return dataBase.users.Count;
        }

        public List<User> GetUsers() {
            return dataBase.users;
        }

        public Dictionary<char, List<User>> GetAlphabeticallySortedUsersDictionary() {
            Dictionary<char, List<User>> res = new Dictionary<char, List<User>>();

            foreach (var user in dataBase.users) {
                if (!res.ContainsKey(user.name.UpperLast[0])) {
                    res.Add(user.name.UpperLast[0], new List<User>());
                }
                res[user.name.UpperLast[0]].Add(user);
            }

            return res;
        }
    }
}
