using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vk_wf_app
{
    public partial class ParseFriendsForm : Form
    {
        private string accessToken;
        private int userId;
        private UserFriendsParser MyParser;

        public ParseFriendsForm(string accessToken, int userId)
        {
            InitializeComponent();
            this.accessToken = accessToken;
            this.userId = userId;
        }

        private void ParseFriendsForm_Load(object sender, EventArgs e)
        {
            this.lblContent.Text += this.userId;
            this.MyParser = new UserFriendsParser(this.accessToken, this.userId);
            MyParser.action();
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (VkUser user in MyParser.userFriends)
                {
                    this.ListBox.Items.Add(user.last_name + " " + user.first_name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
          
        }
    }
}
