using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Model.Class {
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

}
