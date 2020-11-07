using System;

namespace LastTime.Helpers
{
    /// <summary>
    /// Define behaviors of manages message service.
    /// </summary>
    public interface IMessageManager
    {
        /// <summary>
        /// Register a message.
        /// </summary>
        void Register(object regInstance, string msgName, Action action, string group = "");
        void Register<T>(object regInstance, string msgName, Action<T> action, string group = "");
        void SendMsg(string msgName, Type targetType = null, string group = "");
        void SendMsg<T>(string msgName, T msgArgs, Type targetType = null, string group = "");
        /// <summary>
        /// Unregister the messages that match with given condition.
        /// </summary>
        /// <param name="regInstance"></param>
        /// <param name="msgName"></param>
        /// <param name="group"></param>
        /// <param name="action"></param>
        /// <param name="other"></param>
        void Unregister(object regInstance = null, string msgName = "", string group = "", Type targetType = null, object other = null);
        void Clear();
    }
}
