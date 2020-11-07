using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastTime.Helpers
{
    public class MainMessageRegister : MessageRegisterBase
    {
        public override void Register()
        {
            RegisterMsg("ShowBox", new Action<string>(s => MessageBox.Show(s)));

            RegisterMsg<ConfirmMsgArgs>("ShowConfirmBox", a =>
            {
                if (MessageBox.Show(a.Content, a.Title, MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    a.Result = true;
                else
                    a.Result = false;
            });

            RegisterMsg<ComputeMsgArgs>("ShowComputeWindow", a =>
            {
                ComputeWindow win = new ComputeWindow();
                win.Owner = RegInstance as Window;
                win.ShowDialog();
            });
        }
    }
}
