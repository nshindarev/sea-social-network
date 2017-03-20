using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.Model.Class;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Presenter;
using vk_sea_wf.Presenter.Class;
using vk_sea_wf.View.Forms;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf
{
    static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // Application.EnableVisualStyles();
           // Application.SetCompatibleTextRenderingDefault(false);

           /* AuthorizationForm webBrowserAuthorize = new AuthorizationForm();
            AuthorizationFormPresenter presenter = new AuthorizationFormPresenter(webBrowserAuthorize, new MyParser());
            presenter.Run(); */
              
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IAuthorization, AuthorizationForm>()
                .RegisterView<IMainView, MainFormParseText>()
                .RegisterService<IParse, MyParser>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<AuthorizationFormPresenter>();
        }
    }
}
