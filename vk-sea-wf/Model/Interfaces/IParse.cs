using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.Class;

namespace vk_sea_wf.Model.Interfaces
{ 
    public interface IParse {
        int get_app_id      { get;}
        int get_scope       { get;}

        //TODO: убрать зависимость с классом VkUser
        IList<String> user_friends { get;}
        IList<List<String>> user_sub_friends { get; }

        void parseInformation();
    }
}
