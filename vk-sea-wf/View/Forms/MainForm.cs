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

namespace vk_sea_wf.View.Forms
{
    public partial class MainForm : Form, IView, IMainView {

        //events
        public event EventHandler<EventArgs> findFriendsItemClicked;

        // override show 
        public void show() {
            Program.Context.MainForm = this;
            this.Show();
        }

        //consrtuctor 
        public MainForm() {
            InitializeComponent();
        }

        
        private void findToolStripMenuItem_Click(object sender, EventArgs e) {
            if (findFriendsItemClicked != null)
                findFriendsItemClicked(this, e);
        }

        public void fillInHTTPAnswer(IList<String> answer) {

            this.listBox.Items.Clear();
            foreach(String s in answer) {
                this.listBox.Items.Add(s);
            }
        }
    }
}
