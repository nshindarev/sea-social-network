using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Model.Interfaces
{
    interface IParse {
        int get_app_id      { get;}
        int get_scope       { get;}
        int userId         { get; set; }
        string access_token { get; set; }

        void parseInformation();
    }
}
