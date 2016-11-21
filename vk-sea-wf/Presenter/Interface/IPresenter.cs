using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.Presenter.Interface {
    public interface IPresenter {
        void Run();
    }

    public interface IPresenter<in TArg> {
        void Run(TArg argument);
    }
}
