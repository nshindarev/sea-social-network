using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        
        public string VkPageId {
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
        private Group vk_company_page;
        private ReadOnlyCollection<User> vk_group_followers;
        private ReadOnlyCollection<User> has_firm_name_users;


        public StudyDecisionTree()
        { 
        }

        //парсим информацию для обучения
        public void parseInformation()
        {
            getHasFirmNameEmployees();
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
        //получаем список сотрудников
        public void getHasFirmNameEmployees()
        {
            int search_counter;
            this.has_firm_name_users = VkApiHolder.Api.Users.Search(out search_counter, new UserSearchParams
            {
                Company = "OpenWay"
            });
        }

    }
}
