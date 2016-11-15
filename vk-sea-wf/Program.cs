using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.Model.Class;
using vk_sea_wf.Presenter;

namespace vk_sea_wf
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AuthorizationForm webBrowserAuthorize = new AuthorizationForm();
            AuthorizationFormPresenter presenter = new AuthorizationFormPresenter(webBrowserAuthorize, new MyParser());
            Application.Run(webBrowserAuthorize);
          
           // presenter.Run();

            /*AuthorizationForm webBrowserAuthorize = new AuthorizationForm();
            AuthorizationFormPresenter presenter = new AuthorizationFormPresenter(webBrowserAuthorize, new MyParser());
            presenter.Run();*/
        }
    }
}
