using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vk_sea_wf.View.Interfaces
{
    interface ICompanyInfo: IView
    {
        // для вытягивания ID OnWeb company-страниц 
        string getCompanyInfo { get;}

        //TODO: придумать как заменить этот show в интерфейсе с пом наследования
        void show();
        event EventHandler<EventArgs> btnStudyDatasetClicked;
    }
}
