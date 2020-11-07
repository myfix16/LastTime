using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastTime.Helpers
{
    /// <summary>
    /// Defines the behaviors of a message register.
    /// </summary>
    public interface IMessageRegister
    {
        object RegInstance { get; set; }
        IMessageManager MsgManager { get; set; }
        void Register();
        //void RegisterMsg(string msgName,Action action,string group);
        //void RegisterMsg<T>(string msgName, Action<T> action, string group);
    }
}
