using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vk_wf_app
{
    [JsonObject(MemberSerialization.OptIn)]
    class VkUser
    {
        [JsonProperty("first_name", Required = Required.Always)]
        public string first_name { get; set; }

        [JsonProperty("last_name", Required = Required.Always)]
        public string last_name { get; set; }

        [JsonProperty("id", Required = Required.Always)]
        public int id { get; set; }

        [JsonProperty("online", Required = Required.Always)]
        public int online { get; set; }

        public VkUser()
        {

        }
    }
}
    