using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Presenter.Interface;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf.Presenter {
    class MainFormPresenter :IPresenter {
        IView View;
        IParse ParseModel;
        IView MainForm;

        public MainFormPresenter(IApplicationController Controller,
            IAuthorization AuthorizationWindow,
            IParse ParseModel) {

            this.View = View;
            this.ParseModel = ParseModel;
            this.MainForm = MainForm;
        }
        public void Run() {
            this.View.Show();
        }
    }
}
