using Morpher.Russian;
using Morpher.WebService.V2.MorpherWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Model.Resource;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vk_sea_wf.Model
{
    class CollectingTrainingDataset : IStudy
    {
        // api fields
        private static string api_url = "https://api.vk.com/";
        private static int app_id = 5677623;
        private string version = "5.60";

        // api parse config fields
        private uint search_employees_count = 1000;
        private uint count_per_user = 20;
        private uint max_count = 600;
        private int count_affiliates;

        // View parameter fields
        private string vk_company_page_id;
        private string company_name;

        //train and test dataset
        private DataTable training_dataset;
        private Dictionary<string, string> words_in_group;

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

        public void parseInformation()
        {
            //Init columns in dataset
            this.training_dataset = new DataTable("decision tree trainer");

            this.training_dataset.Columns.Add("vk_id", typeof(long));

            this.training_dataset.Columns.Add("on_web", typeof(int));
            this.training_dataset.Columns.Add("has_firm_name", typeof(int));
            this.training_dataset.Columns.Add("likes_counter", typeof(int));
            this.training_dataset.Columns.Add("followed_by", typeof(int));
            this.training_dataset.Columns.Add("following_matches", typeof(int));
            this.training_dataset.Columns.Add("is_employee", typeof(int));

            this.training_dataset.Columns.Add("first_name", typeof(string));
            this.training_dataset.Columns.Add("last_name", typeof(string));

            // collect users with hasFirmName param
            List<User> has_firm_name_employees = VkApiHolder.Api.Users.Search(new UserSearchParams
            {
                Company = this.company_name,
                Count = 1000

            }).ToList();

            this.count_affiliates = 4 * has_firm_name_employees.Count();

            // try to collect official group posts
            List<Post> group_posts = new List<Post>();
            try
            {
                group_posts = VkApiHolder.Api.Wall.Get(new WallGetParams()
                {
                    OwnerId = Convert.ToInt32("-" + vk_company_page_id),
                    Count = count_per_user,
                    Filter = WallFilter.Owner
                }).WallPosts.ToList();
            }
            catch (AccessDeniedException ex)
            {
                Console.WriteLine("cannot analyze likes_counter parameter");
            }

            List<User> has_another_firm_name = new List<User>();
            foreach (User employee in has_firm_name_employees)
            {
                if (has_another_firm_name.Count() <= this.count_affiliates)
                {

                    List<User> employee_friends = VkApiHolder.Api.Friends.Get(new FriendsGetParams
                    {
                        UserId = Convert.ToInt32(employee.Id.ToString()),
                        Order = FriendsOrder.Hints,
                        Fields = (ProfileFields)(ProfileFields.FirstName |
                                                 ProfileFields.LastName |
                                                 ProfileFields.Career)

                    }).ToList<User>();
                    //Thread.Sleep(100);


                    foreach (User employee_friend in employee_friends)
                    {
                        bool match_found = false;
                        for (int i = 0; i < employee_friend.Career.Count; i++)
                        {
                            BoyerMoore search_by_name = new BoyerMoore(this.company_name);
                            BoyerMoore search_by_id = new BoyerMoore(this.vkPageId.ToString());


                            if (employee_friend.Career[i].Company != null)
                            {
                                if (search_by_name.Search((employee_friend.Career[i].Company)) != -1)
                                {
                                    // has_another_firm_name.Add(employee_friend);
                                    match_found = true;
                                    Console.WriteLine("match found: user id = {0}", employee_friend.LastName);
                                }
                            }
                            else
                            {
                                if (search_by_id.Search((employee_friend.Career[i].GroupId.ToString())) != -1)
                                {
                                    //has_another_firm_name.Add(employee_friend);
                                    match_found = true;
                                }
                            }
                        }

                        if (!match_found && employee_friend.Career.Count != 0)
                        {
                            has_another_firm_name.Add(employee_friend);
                        }
                    }


                    //insert dataset into datatable
                    /**
                     *    DataRow Format: 
                     *      
                     *      row[0] = vk_id
                     *      
                     *      row[1] = on_web
                     *      row[2] = has_firm_name
                     *      row[3] = likes_counter
                     *      row[4] = followed_by
                     *      row[5] = following_matches
                     *      row[6] = is_employee
                     *    
                     *      row[7] = first_name
                     *      row[8] = last_name
                     *    
                     */

                    foreach (User training_employee in has_firm_name_employees)
                    {
                        DataRow row = this.training_dataset.NewRow();

                        row[0] = training_employee.Id;

                        row[1] = 0;
                        row[2] = 1;
                        row[3] = 0;
                        row[4] = 0;
                        row[5] = 0;
                        row[6] = 1;

                        row[7] = training_employee.FirstName;
                        row[8] = training_employee.LastName;

                        training_dataset.Rows.Add(row);
                    }

                    foreach (User training_employee in has_another_firm_name)
                    {
                        DataRow row = this.training_dataset.NewRow();

                        row[0] = training_employee.Id;

                        row[1] = 0;
                        row[2] = 0;
                        row[3] = 0;
                        row[4] = 0;
                        row[5] = 0;
                        row[6] = 0;

                        row[7] = training_employee.FirstName;
                        row[8] = training_employee.LastName;

                        training_dataset.Rows.Add(row);
                    }

                    makeDictionary(group_posts);
                    searchInGroupPosts(has_firm_name_employees);
                    searchInGroupPosts(has_another_firm_name);


                    string filterExpression = "on_web = '1'";
                    string sortOrder = "vk_id DESC";
                    DataRow[] on_web_users_found = training_dataset.Select(filterExpression, sortOrder, DataViewRowState.Added);
                    int counter = on_web_users_found.Count();

                    Console.WriteLine("Всего найдено {0} сотрудников упомянутых в группе", counter);
                }
            }
        }

        /// <summary>
        /// метод ищет упоминание фамилии сотрудника в группе
        /// </summary>
        /// <param name="group_wall_data"></param>
        /// <param name="affiliates"></param>
        public void searchInGroupPosts(List<User> affiliates)
        {

            System.Net.ServicePointManager.Expect100Continue = false;
            IDeclension declension = Morpher.Factory.Russian.Declension;

            Console.WriteLine("Привет {0} от {1}!",
                declension.Parse("все дотнетчики").Dative,
                declension.Parse("МОРФЕР").Genitive);


            foreach (User affiliate in affiliates)
            {
                bool match_found = false;

                List<string> surname_diclensions = makeSurnameValuesToSearch(affiliate.LastName);
                foreach (string surname_in_dimension in surname_diclensions)
                {
                    if (words_in_group.ContainsValue(surname_in_dimension)) match_found = true;
                }
              

                int id_employee = int.MinValue;

                if (match_found)
                {
                    string filterExpression = "vk_id = '" + affiliate.Id + "'";
                    string sortOrder = "vk_id DESC";
                    DataRow[] users_found_surname = training_dataset.Select(filterExpression, sortOrder, DataViewRowState.Added);

                    foreach (DataRow row in users_found_surname)
                    {
                        row[1] = 1;
                    }

                }
            }
        }

        private void makeDictionary(List<Post> group_posts)
        {
            this.words_in_group = new Dictionary<string, string>();
            foreach (Post group_post in group_posts)
            {
                string post_txt = group_post.Text.ToLower();
                string[] words_in_post = GetWords(post_txt);

                foreach (string word in words_in_post)
                {
                    if(!this.words_in_group.ContainsKey(word))
                        this.words_in_group.Add(word, word);
                }
            }
        }
        private List<string> makeSurnameValuesToSearch(string surname)
        {
            surname = surname.ToLower();
            List<string> surname_declensions = new List<string>();

            try
            {
                Morpher.Russian.IDeclension declension = Morpher.Factory.Russian.Declension;

                surname_declensions.Add(declension.Parse(surname).Nominative);
                surname_declensions.Add(declension.Parse(surname).Genitive);
                surname_declensions.Add(declension.Parse(surname).Dative);
                surname_declensions.Add(declension.Parse(surname).Accusative);
                surname_declensions.Add(declension.Parse(surname).Instrumental);
                surname_declensions.Add(declension.Parse(surname).Prepositional);
            }
            catch (Exception ex)
            {
                surname_declensions.Add(surname);
            }
            return surname_declensions;
        }

        static string[] GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input, @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToArray();
        }
        static string TrimSuffix(string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
        
        
        //Interface getter/setter
        public string companyName {
            get
            {
                return this.company_name;
            }
            set
            {
                this.company_name = value;
            }
        }
        public string vkPageId {
            get
            {
                return this.vk_company_page_id;
            }
            set
            {
                this.vk_company_page_id = value;
            }
        }
    }
}