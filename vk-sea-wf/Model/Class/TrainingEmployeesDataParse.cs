using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using vk_sea_wf.Model.DB;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Model.Resource;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vk_sea_wf.Model.Class
{
    class TrainingEmployeesDataParse: IParse, IStudy
    {
        // api fields
        private static string api_url = "https://api.vk.com/";
        private static int app_id = 5677623;
        private string version = "5.60";

        //DB fields
        private DBConnection dbconnection;

        // View parameter fields
        private string vk_company_page_id;
        private string company_name;

        // api parse config fields
        private uint search_employees_count = 1000;
        private uint count_per_user = 20;
        private uint max_count = 600;
        private int count_affiliates;

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

        // IStudy + IParse getter/setter
        public int get_app_id {
            get
            {
                return app_id;
            }
        }
        public int get_scope {
            get
            {
                return scope;
            }
        }
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

        
        public void parseInformation()
        {
            //TODO: убрать
            Stopwatch sw = new Stopwatch();
            sw.Start();

            dbconnection = DBConnection.Instance();
            dbconnection.DatabaseName = "socialnetworkemployees";

            List<User> has_firm_name_affiliates = new List<User>();
            List<User> has_firm_name_employees = VkApiHolder.Api.Users.Search(new UserSearchParams
            {
                Company = this.company_name,
                Count = 1000

            }).ToList();

            this.count_affiliates = 9 * has_firm_name_employees.Count();

            List<Post> group_posts = VkApiHolder.Api.Wall.Get(new WallGetParams()
            {
                OwnerId = Convert.ToInt32("-" + vk_company_page_id),
                Count = count_per_user,
                Filter = WallFilter.Owner
            }).WallPosts.ToList();
            Thread.Sleep(50);


            List<User> has_another_firm_name = new List<User>();
           
            foreach (User employee in has_firm_name_employees)
            {
                if (has_another_firm_name.Count() <= this.count_affiliates)
                {

                    List<User> employee_friends = VkApiHolder.Api.Friends.Get(new FriendsGetParams
                    {
                        UserId = Convert.ToInt32(employee.Id.ToString()),
                        Order = FriendsOrder.Hints,
                        Fields = (ProfileFields)(ProfileFields.All)

                    }).ToList<User>();
                    Thread.Sleep(50);


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
                }
                else
                {

                }
            }

            #region DATABASE INSERT OPERATIONS
            #region CLEAR TABLES
            /*
             * SET FOREIGN_KEY_CHECKS = 0; 
             * TRUNCATE employees;
             * TRUNCATE training_data; 
             * SET FOREIGN_KEY_CHECKS = 1;
             */
            if (dbconnection.IsConnect())
            {
                string query = "SET FOREIGN_KEY_CHECKS = 0; TRUNCATE employees; TRUNCATE training_data; SET FOREIGN_KEY_CHECKS = 1;";
                var cmd = new MySqlCommand(query, dbconnection.Connection);
                var exec = cmd.ExecuteNonQuery();


                #endregion

                MySqlDataReader reader;
                int id_employee = int.MinValue;

                #region Insert employees into DB
                foreach (User employee in has_firm_name_employees)
                {
                    query = "INSERT INTO employees (first_name, last_name, vk_id) VALUES ('" + employee.FirstName + "','" + employee.LastName
                                                                                                                  + "','" + employee.Id
                                                                                       //+ "','" + employee.BirthDate 
                                                                                       + "')";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    exec = cmd.ExecuteNonQuery();

                    query = "SELECT id FROM employees WHERE first_name = '" + employee.FirstName + "' " + " AND last_name = '" + employee.LastName + "'";
                    cmd = new MySqlCommand(query, dbconnection.Connection);

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id_employee = reader.GetInt32(0);
                    }
                    reader.Close();

                    query = "INSERT INTO training_data (id_training_affiliate, has_firm_name, is_employee) VALUES ('" + id_employee + "','1','1')";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    exec = cmd.ExecuteNonQuery();

                  //  parseAffiliateInfo(employee);
                }
                #endregion
                #region Insert not employee affiliates 
                foreach (User affiliate in has_another_firm_name)
                {
                    try
                    {
                        query = "INSERT INTO employees (first_name, last_name, vk_id) VALUES ('" + affiliate.FirstName + "','" + affiliate.LastName
                                                                                                                  + "','" + affiliate.Id
                                                                                      //+ "','" + employee.BirthDate 
                                                                                      + "')";
                        cmd = new MySqlCommand(query, dbconnection.Connection);
                        exec = cmd.ExecuteNonQuery();

                        query = "SELECT id FROM employees WHERE first_name = '" + affiliate.FirstName + "' " + " AND last_name = '" + affiliate.LastName + "'";
                        cmd = new MySqlCommand(query, dbconnection.Connection);

                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            id_employee = reader.GetInt32(0);
                        }
                        reader.Close();

                        query = "INSERT INTO training_data (id_training_affiliate, has_firm_name, is_employee) VALUES ('" + id_employee + "','1','0')";
                        cmd = new MySqlCommand(query, dbconnection.Connection);
                        exec = cmd.ExecuteNonQuery();

                        parseAffiliateInfo(affiliate);
                    }
                    catch (MySqlException ex)
                    {

                    }
                   
                }
                #endregion
            }
            #endregion
            //Analyse official group;
            searchInGroupPosts(group_posts, has_firm_name_employees);
            searchInGroupPosts(group_posts, has_another_firm_name);

             sw.Stop();
        }
        public void parseAffiliateInfo(User affiliate)
        {
          /*  Thread.Sleep(50);
            var affiliate_friends = VkApiHolder.Api.Friends.Get(new FriendsGetParams
            {
                UserId = Convert.ToInt32(affiliate.Id),
                Order = FriendsOrder.Hints,
                Fields = (ProfileFields)(ProfileFields.FirstName |
                                                  ProfileFields.LastName)

            }).ToList<User>();
            Thread.Sleep(50);*/

            // Удалить забаненных
            // affiliate_friends.RemoveAll(user => user.IsFriend.HasValue ? !user.IsFriend.Value : true);


            #region Анализ списка друзей сотрудника
            #endregion

            #region Поиск информации о сотруднике в группе
           
            #endregion

            #region Поиск упоминаний имени компании на стене сотрудника
            #endregion
        }
        public void searchInGroupPosts(List<Post> group_wall_data, List<User> affiliates)
        {
            foreach (User affiliate in affiliates)
            {
                int matches_counter = 0;
                foreach (Post post in group_wall_data)
                {
                    BoyerMoore bm = new BoyerMoore(affiliate.LastName);
                    if (bm.Search(post.Text) != -1) matches_counter++;
                }

                int id_employee = int.MinValue;
                if (matches_counter > 0 && dbconnection.IsConnect())
                {
                    string query = "SELECT id FROM employees WHERE vk_id = '" + affiliate.Id + "'";
                    var cmd = new MySqlCommand(query, dbconnection.Connection);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        id_employee = reader.GetInt32(0);
                    }
                    reader.Close();

                    query = "UPDATE training_data SET on_web = 1 WHERE id_training_affiliate = '" + id_employee.ToString() + "'";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    var exec = cmd.ExecuteNonQuery();
                }
            }
                
                
        
        }
    }
}
