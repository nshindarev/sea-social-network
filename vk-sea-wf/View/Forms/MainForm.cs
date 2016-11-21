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

        public void show() {
            this.show();
        }
        public MainForm() {
            InitializeComponent();
           // Application.Run(this);
        }
    }
}
