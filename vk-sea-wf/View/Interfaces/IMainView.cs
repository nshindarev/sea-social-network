using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vk_sea_wf.View.Interfaces{
    public interface IMainView: IView {
        
        void show();
        void fillInHTTPAnswer(IList<String> user_friends);

        event EventHandler<EventArgs> findFriendsItemClicked;
    }
}
