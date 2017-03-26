using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.DB;
using vk_sea_wf.Model.Interfaces;
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
            dbconnection = DBConnection.Instance();
            dbconnection.DatabaseName = "socialnetworkemployees";

            List<User> has_firm_name_employees = VkApiHolder.Api.Users.Search(new UserSearchParams
            {
                Company = this.company_name
            }).ToList();


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

                foreach (User employee in has_firm_name_employees)
                {
                    query = "INSERT INTO employees (first_name, last_name) VALUES ('" + employee.FirstName + "','" + employee.LastName
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
                }
            }
        }
    }
}
