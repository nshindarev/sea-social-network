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
    public partial class CompanyInfoForm_v2 : Form, IView, ICompanyInfo
    {
        //events
        public event EventHandler<EventArgs> btnStudyDatasetClicked;
        public string getCompanyName {
            get
            {
                return this.txtBoxName.Text.ToString();
            }
        }
        public string getCompanyInfo {
            get
            {
                return this.txtBoxVK.Text.ToString();
            }
        }
        public CompanyInfoForm_v2()
        {
            InitializeComponent();
        }
        public void show()
        {
            this.Show();
        }
        private void btnStudy_Click(object sender, EventArgs e)
        {
            if (btnStudyDatasetClicked != null)
                btnStudyDatasetClicked(this, e);
        }
    }
}
