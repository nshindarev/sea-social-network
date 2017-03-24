using System.Collections.Generic;
using System.Linq;
using vk_sea_wf.Model.Interfaces;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.IO;
using KBCsv;

namespace vk_sea_wf.Model.Class
{
    class TextDataParsePsych : IParse
    {
        public static string api_url = "https://api.vk.com/";
        public static int app_id = 5677623;
        public string version = "5.60";

        public FriendsOrder order = new FriendsOrder();
        public List<User> userFriends { get; set; }

        public IList<User> user_friends
        {
            get
            {
                return this.userFriends;
            }
        }

        public enum VkontakteScopeList
        {
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

        public int get_app_id
        {
            get
            {
                return app_id;
            }
        }
        public int get_scope
        {
            get
            {
                return scope;
            }
        }


        public void parseInformation()
        {

            string[] columns = {
                "text",
                "Konf-I", "Trad-I", "Dobr-I", "Univ-I", "Samo-I", "Stim-I", "Ged-I", "Dost-I", "Vlas-I", "Bezop-I",
                "Konf-P", "Trad-P", "Dobr-P", "Univ-P", "Samo-P", "Stim-P", "Ged-P", "Dost-P", "Vlas-P", "P",
                "A", "B", "C", "E", "F", "G", "H", "I", "L", "M", "N", "O", "Q1", "Q2", "Q3", "Q4",
                "Отриц.", "Вытесн.", "Регрессия", "Компенсац.", "Проекц.", "Замещ.", "Рационализац.", "Гиперкомпенсац.", "Общ. Ур."
            };

            string inputFileName = @"C:\psych.csv";
            string outFileName = @"C:\vk-psych.csv";

            using (var sr = new StreamReader(inputFileName))
            using (var reader = new CsvReader(sr))
            using (var sw = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8))
            using (var writer = new CsvWriter(sw))
            {
                reader.ValueSeparator = ',';

                writer.ForceDelimit = false;
                writer.ValueSeparator = ',';
                writer.ValueDelimiter = '\'';

                reader.ReadHeaderRecord();
                writer.WriteRecord(columns);

                while (reader.HasMoreRecords)
                {
                    var dataRecord = reader.ReadDataRecord();

                    List<Post> posts = VkApiHolder.Api.Wall.Get(new WallGetParams()
                    {
                        OwnerId = long.Parse(dataRecord["id"]),
                        Filter = WallFilter.Owner
                    }).WallPosts.ToList();

                    foreach (Post post in posts)
                    {
                        string s = post.Text + " ";
                        if (post.CopyHistory.Count != 0)
                        {
                            s += post.CopyHistory.First().Text;
                        }
                        s = s.Replace(System.Environment.NewLine, " ")
                            .Replace("\n", " ")
                            .Replace("\r", " ")
                            .Replace("\"", "")
                            .Replace(";", " ")
                            .Replace(",", " ")
                            .Replace("'", "")
                            .Trim();
                        if (s == string.Empty) continue;

                        var outputRecord = new string[columns.Length];
                        outputRecord[0] = s;
                        for (int i = 1; i < columns.Length; i++)
                        {
                            outputRecord[i] = dataRecord[columns[i]];
                        }

                        writer.WriteRecord(outputRecord);
                    }

                    System.Threading.Thread.Sleep(50);
                }                
            }
        }

    }
}
