using VkNet.Enums.SafetyEnums;

namespace vk_sea_wf.Model
{
    internal class PhotosGetParams
    {
        public PhotosGetParams()
        {
        }

        public uint Count { get; set; }
        public WallFilter Filter { get; set; }
        public int OwnerId { get; set; }
    }
}