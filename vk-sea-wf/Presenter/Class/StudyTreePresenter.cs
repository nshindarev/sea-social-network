using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vk_sea_wf.Model.Interfaces;
using vk_sea_wf.Presenter.Interface;
using vk_sea_wf.View.Interfaces;

namespace vk_sea_wf.Presenter.Class
{
    class StudyTreePresenter
    {
        IApplicationController Controller;
        ICompanyInfo CompanyInfoForm;
        IStudy StudyDecisionTree;

        public StudyTreePresenter (IApplicationController Controller,
            ICompanyInfo CompanyInfoForm,
            IStudy StudyDecisionTree) {
            this.Controller = Controller;
            this.CompanyInfoForm = CompanyInfoForm;
            this.StudyDecisionTree = StudyDecisionTree;

            this.CompanyInfoForm.btnStudyDatasetClicked += new EventHandler<EventArgs>(onbtnStudyClick);
        }
    
        // метод, запускающий обучение дерева принятия решений
        public void onbtnStudyClick(object sender, EventArgs e)
        {
            //TODO: расширить функционал передачи словаря до нескольких соцсетей
            this.StudyDecisionTree.SocialNetworkIds = this.CompanyInfoForm.getCompanyInfo;
        }
    }
}
