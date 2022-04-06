namespace ProjetoIntegradoTeste.Domain
{
    public delegate void MessageReceivedEventHandler<T>(T message);

    public interface IMessageBroker<T>
    {
        /// <summary>
        /// Event Triggered when a new message is entered in queue.
        /// </summary>
        event MessageReceivedEventHandler<T> MessageReceived;

        /// <summary>
        /// Adds a message in queue.
        /// </summary>
        /// <param name="message"></param>
        void Publish(T message);
        /// <summary>
        /// 
        /// </summary>
        void Setup();
        /// <summary>
        /// Long running process to start to consume queue's messages
        /// </summary>
        void StartConsume();
        /// <summary>
        /// Long running process to start to consume queue's messages (if used)
        /// </summary>
        /// <param name="action">The action that runs when a new message is entered in queue.</param>
        void StartConsume(Action<T> action);
    }
}
