using System;
using System.Collections.Generic;
using System.Linq;

namespace LastTime.Helpers
{
    public class MessageManager : IMessageManager
    {
        private static MessageManager _default;

        public static MessageManager Default
        {
            get
            {
                _default ??= new MessageManager();
                return _default;
            }
        }

        /// <summary>
        /// A list of registered messages.
        /// </summary>
        private readonly List<Message> _messageList = new List<Message>();

        public void Register(object regInstance, string msgName, Action action, string group = "")
        {
            _messageList.Add(new Message
            {
                RegInstance = regInstance,
                MsgName = msgName,
                Action = action,
                Group = group
            });
        }

        public void Register<T>(object regInstance, string msgName, Action<T> action, string group = "")
        {
            _messageList.Add(new Message<T>
            {
                RegInstance = regInstance,
                MsgName = msgName,
                Action = action,
                Group = group
            });
        }

        public void SendMsg(string msgName, Type targetType = null, string group = "")
        {
            var filtedMsgs = Filter(msgName: msgName, targetType: targetType, group: group);

            foreach (var item in filtedMsgs)
            {
                item.Execute();
            }
        }

        public void SendMsg<T>(string msgName, T msgArgs, Type targetType = null, string group = "")
        {
            var filtedMsgs = Filter(msgName: msgName, targetType: targetType, group: group);
            foreach (var item in filtedMsgs)
            {
                if (item is Message<T> msgAction)
                    msgAction.Execute(msgArgs);
            }
        }

        public void Unregister(
            object regInstance = null,
            string msgName = "",
            string group = "",
            Type targetType = null,
            object other = null)
        {
            var msgs = Filter(regInstance, msgName, group, targetType, other);

            foreach (var msg in msgs)
            {
                _messageList.Remove(msg);
            }
        }

        public void Clear()
        {
            _messageList.Clear();
        }

        private IEnumerable<Message> Filter(
            object regInstance = null,
            string msgName = "",
            string group = "",
            Type targetType = null,
            object other = null)

            => _messageList
                .Where(m => (regInstance == null) || m.RegInstance == regInstance)
                .Where(m => (msgName == "") || m.MsgName == msgName)
                .Where(m => (group == "") || m.Group == group)
                .Where(m => (targetType == null) || m.RegInstance.GetType() == targetType)
                .Where(m => (other == null) || m.Other == other);

    }
}
