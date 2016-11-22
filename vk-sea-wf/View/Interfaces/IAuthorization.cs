using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.View.CustomEventArgs;

namespace vk_sea_wf.View.Interfaces
{
    interface IAuthorization : IView{ 

        // вызываются при введении логина-пароля
        void show();

        // событие срабатывает при заполнении в web-browser логина и пароля
        event EventHandler<WebBrowserDocumentCompletedEventArgs> LogPassInsert;
    }
}
