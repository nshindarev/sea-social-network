using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.Class;

namespace vk_sea_wf.Model.Interfaces
{ 
    interface IParse {
        int get_app_id      { get;}
        int get_scope       { get;}

        //TODO: убрать зависимость с классом VkUser
        IList<VkUser> user_friends { get; set; }

        void parseInformation();
    }
}
