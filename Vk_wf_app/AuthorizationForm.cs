using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vk_wf_app
{
    public partial class AuthorizationForm : Form
    {
        private string api_url = "https://api.vk.com/";
        private int appId = 5677623;
        private string accessToken;
        private int userId;
        private enum VkontakteScopeList {
            notify = 1,
            friends = 2,
            photos = 4,
            audio = 8,
            video = 16,
            offers = 32,
            questions = 64,
            pages = 128,
            link = 256,
            notes = 2048,
            messages = 4096,
            wall = 8192,
            docs = 131072
        }
        
        private int scope = (int)(VkontakteScopeList.audio |
            VkontakteScopeList.docs |
            VkontakteScopeList.friends |
            VkontakteScopeList.link |
            VkontakteScopeList.messages |
            VkontakteScopeList.notes |
            VkontakteScopeList.notify |
            VkontakteScopeList.offers |
            VkontakteScopeList.pages |
            VkontakteScopeList.photos |
            VkontakteScopeList.questions |
            VkontakteScopeList.video | 
            VkontakteScopeList.wall);

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void authorizationForm_Load(object sender, EventArgs e)
        {
            // открыть в webBrowser страницу авторизации
            // передаем client_id, scope, display
            webBrowser.Navigate(String.Format("https://api.vk.com/oauth/authorize?client_id={0}&scope={1}&display=popup&response_type=token", appId, scope));
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.ToString().IndexOf("access_token") != -1)
            {
                this.accessToken = "";
                this.userId = 0;

                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Url.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        accessToken = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        userId = Convert.ToInt32(m.Groups["value"].Value);
                    }
                    // еще можно запомнить срок жизни access_token - expires_in,
                    // если нужно
                }
                MessageBox.Show(String.Format("Ключ доступа: {0}\nUserID: {1}", accessToken, userId));

                ParseFriendsForm parser = new ParseFriendsForm(this.accessToken, this.userId);
                parser.Show();
                this.Hide();
            }
        }
    }
}
