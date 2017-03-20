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

namespace vk_sea_wf.View
{
    public partial class CompanyInfoForm : Form, IView, ICompanyInfo
    {

        //events
        public event EventHandler<EventArgs> btnStudyDatasetClicked;
        public Dictionary<string,string> getCompanyInfo {
            get { Dictionary<string,string> VKData = new Dictionary<string, string>();
                VKData.Add("VK", this.txtBoxVk.ToString());
                return VKData; }
        }
        public CompanyInfoForm()
        {
            InitializeComponent();
        }

        private void btnStudy_Click(object sender, EventArgs e)
        {
            if (btnStudyDatasetClicked != null)
                btnStudyDatasetClicked(this, e);
        }
    }
}
