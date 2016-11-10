using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace Vk_wf_app
{
    class UserFriendsParser
    {
        public static string vkapi_url = "https://api.vk.com/method/";
        private int userId;
        private string accessToken;
        public List<VkUser> userFriends;
        private string order = "hints";
        


        public UserFriendsParser (string accessToken, int userId)
        {
            this.accessToken = accessToken;
            this.userId = userId;
            this.userFriends = new List<VkUser>();
            for (int i = 0; i < 360; i++)
                userFriends.Add(new VkUser());
        }
        public void action()
        {
            HttpRequest myreq = new HttpRequest();
            myreq.AddUrlParam("user_ids", userId);
            myreq.AddUrlParam("access_token", accessToken);
            myreq.AddUrlParam("order", order);
            myreq.AddUrlParam("fields", "name");
            string rez = myreq.Get(vkapi_url + "friends.get").ToString();

            // зачем делать substring?
            rez = rez.Substring(13, rez.Length - 15);

            // (JSON) string -> VkUser
            // this.userFriends = JsonConvert.DeserializeObject<List<VkUser>>(rez);


        }
    }
}
