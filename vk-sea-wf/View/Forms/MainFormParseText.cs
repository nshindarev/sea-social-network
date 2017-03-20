using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf.View.Forms {
    public partial class MainFormParseText :Form, IView, IMainView {
        //events
        public event EventHandler<EventArgs> findFriendsItemClicked;

        // override show 
        public void show() {
            Program.Context.MainForm = this;
            this.Show();
        }
        public MainFormParseText() {
            InitializeComponent();
        }

        private void getTextToolStripMenuItem_Click(object sender, EventArgs e) {
            findFriendsItemClicked?.Invoke(this, e);
        }
        
        public void fillInHTTPAnswer(IList<string> user_friends, IList<List<string>> user_sub_friends)
        {
            MessageBox.Show("Done!");
        }
    }
}
