using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.Model.Class;
using vk_sea_wf.View.CustomEventArgs;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf
{
    public partial class AuthorizationForm: Form, IView, IAuthorization {
       
        public event EventHandler<WebBrowserDocumentCompletedEventArgs> LogPassInsert;

        public AuthorizationForm(){
            InitializeComponent();
        }
        public void show(){
            Application.Run(this);
        }

       
        // событие webBrowser, срабатывает после введения логина-пароля
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) {
          if (LogPassInsert != null)
                LogPassInsert(this, e);
            
        }
       
        // вызывается при загрузке формы для перехода браузера на страницу авторизации
        private void NavigateAuthorization(object sender, EventArgs e) {
            webBrowser.Navigate(String.Format("https://api.vk.com/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token",
              MyParser.app_id, MyParser.scope));
        }
        public void loadNextForm(IMainView MainForm) {
            MainForm.Show();
        }
    }
}
