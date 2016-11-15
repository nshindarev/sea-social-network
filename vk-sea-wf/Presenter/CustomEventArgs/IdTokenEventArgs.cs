using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.View.CustomEventArgs
{
    class IdTokenEventArgs : EventArgs {
        public string access_token { get; set; }
        public int access_user_id { get; set; }
    }
}