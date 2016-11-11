using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_wf_app
{
    public class VkUser
    {
        // !!! Vk API v.3.0
        // TODO: изменить версию API хотя бы до 5.60
        // TODO: изменить структуру объектов Vk

        public string first_name { get; set; }

        public string last_name { get; set; }

        public int uid { get; set; }

        public int user_id { get; set; }

        public int online { get; set; }

        //public string domain { get; set; }

        //public City city { get; set; }
    }
    
    public class ResponseWrap
    {
        public IList<VkUser> response { get; set; }
    }
}
    