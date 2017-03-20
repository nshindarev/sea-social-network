using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.View.Interfaces
{
    interface ICompanyInfo
    {
        // для вытягивания ID OnWeb company-страниц 
        Dictionary<string, string> getCompanyInfo { get;}

        event EventHandler<EventArgs> btnStudyDatasetClicked;
    }
}
