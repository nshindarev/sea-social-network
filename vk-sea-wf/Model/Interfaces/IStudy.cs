using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Model.Interfaces
{
    public interface IStudy
    {
        string vkPageId {
            get;
            set;
        }
        string companyName {
            get;
            set;
        }
        void parseInformation();
    }
}
