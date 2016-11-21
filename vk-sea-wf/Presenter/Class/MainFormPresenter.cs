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
 
        IParse ParseModel;
        IMainView MainForm;

        public MainFormPresenter(IApplicationController Controller,
            IMainView MainForm,
            IParse ParseModel) {

            this.MainForm = MainForm;
            this.ParseModel = ParseModel;
            this.MainForm = MainForm;
        }
        public void Run() {
            this.MainForm.Show();
        }
    }
}
