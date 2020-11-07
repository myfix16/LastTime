using System;

namespace LastTime.Helpers
{
    public class Message
    {
        /// <summary>
        /// The name of the message.
        /// </summary>
        public string MsgName { get; internal set; }
        /// <summary>
        /// The instance that registered this message.
        /// </summary>
        public object RegInstance { get; internal set; }
        /// <summary>
        /// The group that the message belongs to.
        /// </summary>
        public string Group { get; internal set; }
        /// <summary>
        /// The action to perform when the message is sent.
        /// </summary>
        public Action Action { get; internal set; }
        /// <summary>
        /// Reserved property for future extension.
        /// </summary>
        public object Other { get; internal set; }

        public void Execute()
        {
            Action?.Invoke();
        }
    }

    /// <summary>
    /// Generic version of the Message class. It specifies the type of Action's argument.
    /// </summary>
    /// <typeparam name="T">The type of Action's argument.</typeparam>
    public class Message<T> : Message
    {
        public new Action<T> Action { get; internal set; }

        public new void Execute()
        {
            Execute(default);
        }

        public void Execute(T args)
        {
            Action?.Invoke(args);
        }
    }
}
