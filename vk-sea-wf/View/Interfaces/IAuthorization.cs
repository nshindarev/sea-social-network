﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.View.CustomEventArgs;

namespace vk_sea_wf.View.Interfaces
{
    interface IAuthorization
    { 

        // вызываются при введении логина-пароля
        // вызов следующей формы
        void loadNextForm(IMainView MainView);
        void Show();

        event EventHandler<WebBrowserDocumentCompletedEventArgs> LogPassInsert;
    }
}