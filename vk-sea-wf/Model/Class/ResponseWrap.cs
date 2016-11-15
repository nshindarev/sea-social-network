using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Model.Class
{
    public class ResponseWrap {
        public Response response { get; set; }
    }
        public class Response
     {
         public int count;
         public IList<VkUser> items { get; set; }
     }
}
