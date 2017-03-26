using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.DB;
using vk_sea_wf.Model.Interfaces;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace vk_sea_wf.Model.Class
{
    /*  VK:
     *      1) findUsers: HasFirmName - люди, у которых в личной информации
     *                    указано место работы в данной ИС. Значение целевой функции = true;
     *      2) findFriends: Списки друзей этих сотрудников, у которых тоже указана информация о месте работы, 
     *                      но в другой компании. Значение целевой функции = false;
     */
    class StudyDecisionTree: IStudy{
        //INTERFACE FIELDS
        Dictionary<string, string> SocialNetworkIds;

        // VK API INFO
        public static string api_url = "https://api.vk.com/";
        public static int app_id = 5677623;
        public string version = "5.60";

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
        public Group get_group {
            get
            {
                return vk_company_page;
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

        private string vk_company_page_id;
        private string company_name;
        private Group vk_company_page;
        private ReadOnlyCollection<User> vk_group_followers;
        private List<User> has_firm_name_employees;
        private DBConnection dbconnection;


        public StudyDecisionTree()
        { 
        }

        //парсим информацию для обучения;
        public void parseInformation()
        {
            //TODO: Убрать зависимость с названием
            dbconnection = DBConnection.Instance();
            dbconnection.DatabaseName = "socialnetworkemployees";


            getHasFirmNameEmployees(company_name);
        }


        //получаем список сотрудников
        public void getHasFirmNameEmployees(string company)
        {
            //TODO: убрать это отсюда

           // clearDatabaseTable("training_data");
           // clearDatabaseTable("employees");
            //TODO: добавить какие-нибудь Regex чтобы не тупо по введенному + следить за пробелами

            List<User> has_firm_name_employees = VkApiHolder.Api.Users.Search(new UserSearchParams
            {
                Company = company
            }).ToList();
            
            if (dbconnection.IsConnect())
            {
                // TODO: обработать: id == 0 => exception
                string query;
                MySqlCommand cmd;
                int executor, id = 0;
                MySqlDataReader reader;
                foreach (User employee in has_firm_name_employees)
                {
                    query = "INSERT INTO employees (first_name, last_name) VALUES ('" + employee.FirstName + "','" + employee.LastName
                                                                                       //+ "','" + employee.BirthDate 
                                                                                       + "')";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    executor = cmd.ExecuteNonQuery();

                    query = "SELECT id FROM employees WHERE first_name = '" + employee.FirstName +"' "+ " AND last_name = '" + employee.LastName + "'";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                       id = reader.GetInt32(0);
                    }
                    reader.Close();

                    query = "INSERT INTO training_data (id_training_affiliate, has_firm_name, is_employee) VALUES ('" + id + "','1','1')";
                    cmd = new MySqlCommand(query, dbconnection.Connection);
                    executor = cmd.ExecuteNonQuery();
                }
                /*string query;
                MySqlCommand cmd;
                int executor;
                foreach (User employee in has_firm_name_employees)
                {
                   query = "INSERT INTO employees (first_name, last_name) VALUES ('" + employee.FirstName + "','" + employee.LastName 
                                                                                   //+ "','" + employee.BirthDate 
                                                                                     + "')";
                   cmd = new MySqlCommand(query, dbconnection.Connection);
                   executor = cmd.ExecuteNonQuery();
                }*/
            }
        }
        public void getHasFirmNameNonEmployees(string company)
        {

            if (dbconnection.IsConnect())
            {

            }
        }
        public void clearDatabaseTable(string table_name)
        {
            if (dbconnection.IsConnect())
            {
                string query = "TRUNCATE TABLE " + table_name;
                var cmd = new MySqlCommand(query, dbconnection.Connection);
                var executor = cmd.ExecuteNonQuery();
            }
        }
        // Парсим подписчиков официальной группы ВК
        public void getUsersInGroup()
        {
            this.getVkGroup();
           
            int totalCount;
            vk_group_followers = VkApiHolder.Api.Groups.GetMembers(vk_company_page_id, out totalCount);
            
        }
        // получаем группу на основе введенной информации на 1 экране
        public void getVkGroup()
        {
            this.vk_company_page = VkApiHolder.Api.Groups.GetById(vk_company_page_id);
        }
    }
}
