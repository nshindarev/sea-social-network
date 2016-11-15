using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.Model.Class;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.View.Forms;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf.Presenter
{
    class AuthorizationFormPresenter {

        IParse ParseModel;
        IAuthorization AuthorizationWindow;

        //TODO: протестировать конструкторы с 1 и 0 параметрами
        public AuthorizationFormPresenter(IAuthorization AuthorizationWindow, IParse ParseModel) {
            this.ParseModel = ParseModel;
            this.AuthorizationWindow = AuthorizationWindow;

            AuthorizationWindow.LogPassInsert += new EventHandler<WebBrowserDocumentCompletedEventArgs>(OnLogPassInserted);
        }
        public AuthorizationFormPresenter(IAuthorization AuthorizationWindow): this (AuthorizationWindow, new MyParser()) {
        }
        public AuthorizationFormPresenter(IParse ParseModel):this(new AuthorizationForm(), ParseModel) {
        }
        public AuthorizationFormPresenter(): this (new AuthorizationForm(), new MyParser()) {
        }


        public void Run() {
            AuthorizationWindow.show();
        }
        // по событию передаем в model access_token и user_id
        // передача управления в MainForm
        public void OnLogPassInserted(object sender, WebBrowserDocumentCompletedEventArgs e) {
            if (e.Url.ToString().IndexOf("access_token") != -1) {
                ParseModel.access_token = "";
                ParseModel.user_id = 0;

                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token") {
                        ParseModel.access_token = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id") {
                        ParseModel.user_id = Convert.ToInt32(m.Groups["value"].Value);
                    }
                    // еще можно запомнить срок жизни access_token - expires_in,
                    // если нужно
                }
                this.AuthorizationWindow.loadNextForm(new MainForm());
            }
        }
       
    }
}
    
