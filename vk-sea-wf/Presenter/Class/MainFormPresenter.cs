using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using vk_sea_wf.Model.Class;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Presenter.Interface;
using vk_sea_wf.View.Interfaces;
using System.Windows.Forms;
using VkNet.Model;

namespace vk_sea_wf.Presenter {
    class MainFormPresenter :IPresenter {
       

        IApplicationController Controller;
        IParse ParseModel;
        IMainView MainForm;

        public MainFormPresenter(IApplicationController Controller,
            IMainView MainForm,
            IParse ParseModel) {

            this.MainForm = MainForm;
            this.ParseModel = ParseModel;
            this.Controller = Controller;

            this.MainForm.findFriendsItemClicked += new EventHandler<EventArgs>(onFindFriendsItemClicked);
        }
        public void Run() {
            this.MainForm.show();
        }
        public void onFindFriendsItemClicked (object sender, EventArgs e) {
            /*
            this.MainForm.getOutputTool.Items.Clear();
            this.ParseModel.parseInformation();

            foreach(VkUser user in this.ParseModel.user_friends) {
                this.MainForm.getOutputTool.Items.Add(user.first_name + " " + user.last_name);
            }*/

            this.ParseModel.parseInformation();
            this.MainForm.fillInHTTPAnswer(this.ParseModel.user_friends);
        }
    }
}
