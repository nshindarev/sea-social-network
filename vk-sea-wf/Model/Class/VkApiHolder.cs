using System;
using VkNet;

namespace vk_sea_wf
{
    public class VkApiHolder
    {
        private static readonly Lazy<VkApi> vkApiHolder = new Lazy<VkApi>(() => new VkApi());
    
        private VkApiHolder() { }

        public static VkApi Api
        {
            get { return vkApiHolder.Value; }
        }
    }
}