using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

using Newtonsoft.Json;
using Contacts.Core.UserData;

namespace Contacts.Core {
    public class DataBase {

        public List<User> users = new List<User>();

        public DataBase(Action onFinishLoading) {
            LoadUsersFromAPIAsync(onFinishLoading);
        }

        private async void LoadUsersFromAPIAsync(Action onFinishLoading) {
            var client = new HttpClient();
            var response = await client.GetStringAsync("https://randomuser.me/api/?seed=10&results=1000");
            users.AddRange(JsonConvert.DeserializeObject<JSONUsersResult>(response).results);
            users.Sort((a,b) => string.Compare(a.name.first, b.name.first, StringComparison.CurrentCulture));
            onFinishLoading.Invoke();
        }
    }
}
