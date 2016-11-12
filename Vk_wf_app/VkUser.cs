using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_wf_app
{

    // Vk API v5.60
    // TODO: загрузить структуру объектов Vk

    public class VkUser
    {
        public string first_name { get; set; }

        public string last_name { get; set; }

        public int id { get; set; }

        public int online { get; set; }

        //public string domain { get; set; }

        //public City city { get; set; }
    }
    
    public class ResponseWrap
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public int count;
        public IList<VkUser> items { get; set; }
    }


}
    