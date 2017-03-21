using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Model.Interfaces
{
    public interface IStudy
    {
        string VkPageId {
            get;
            set;
        }
        void parseInformation();
    }
}
