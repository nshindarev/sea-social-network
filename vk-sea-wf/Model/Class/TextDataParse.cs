using System.Collections.Generic;
using System.Linq;
using vk_sea_wf.Model.Interfaces;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.IO;

namespace vk_sea_wf.Model.Class
{
      class TextDataParse : IParse {
        public static string api_url = "https://api.vk.com/";
        public static int app_id = 5677623;
        public string version = "5.60";

        public FriendsOrder order = new FriendsOrder();
        public List<User> userFriends { get; set; }        

        public IList<User> user_friends {
            get
            {
                return this.userFriends;
            }
        }

        public enum VkontakteScopeList {
            notify = 1,
            friends = 2,
            photos = 4,
            audio = 8,
            video = 16,
            offers = 32,
            questions = 64,
            pages = 128,
            link = 256,
            notes = 2048,
            messages = 4096,
            wall = 8192,
            docs = 131072
        }
        public static int scope = (int)(VkontakteScopeList.audio |
            VkontakteScopeList.docs |
            VkontakteScopeList.friends |
            VkontakteScopeList.link |
            VkontakteScopeList.messages |
            VkontakteScopeList.notes |
            VkontakteScopeList.notify |
            VkontakteScopeList.offers |
            VkontakteScopeList.pages |
            VkontakteScopeList.photos |
            VkontakteScopeList.questions |
            VkontakteScopeList.video |
            VkontakteScopeList.wall);

        public int get_app_id {
            get {
                return app_id;
            }
        }
        public int get_scope {
            get {
                return scope;
            }
        }


        public void parseInformation() {

            uint countPerUser = 1;
            uint maxCount = 5;

            uint j = 0;
            bool stop = false;

            this.userFriends = VkApiHolder.Api.Friends.Get(new FriendsGetParams
            {
                UserId = AuthorizatedInfo.userId,
                Order = FriendsOrder.Hints,
                Count = 5,
                Fields = ProfileFields.All
                /* Fields = (ProfileFields) (ProfileFields.FirstName| 
                                             ProfileFields.LastName)*/

            }).ToList();

            string fileName = @"C:\data.txt";
            using (StreamWriter sw = new StreamWriter(fileName))            
            {
                foreach (User user in userFriends)
                {
                    uint i = 0;

                    List<Post> posts = VkApiHolder.Api.Wall.Get(new WallGetParams()
                    {
                        OwnerId = user.Id,
                        Count = countPerUser
                    }).WallPosts.ToList();

                    foreach (Post post in posts)
                    {
                        // TODO: проверка дублирования
                        string s = post.Text + " ";
                        if (post.CopyHistory.Count != 0)
                        {
                            s += post.CopyHistory.First().Text;
                        }
                        s = s.Replace(System.Environment.NewLine, " ").Replace("\"", "").Trim();
                        if (s == string.Empty) break;

                        sw.WriteLine(s);
                        sw.WriteLine();

                        // Остановка после достижения пределов
                        i++; j++;
                        if (countPerUser < i) break;
                        if (maxCount < j)
                        {
                            stop = true;
                            break;
                        }
                    }

                    if (stop) break;
                }
            }
            
        }
    }
}
