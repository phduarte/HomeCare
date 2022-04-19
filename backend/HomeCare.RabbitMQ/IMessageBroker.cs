namespace HomeCare.RabbitMQ
{
    public interface IMessageBroker
    {
        /// <summary>
        /// Adds a message in queue.
        /// </summary>
        /// <param name="message"></param>
        void Publish<T>(T message);

        /// <summary>
        /// Long running process to start to consume queue's messages (if used)
        /// </summary>
        /// <param name="action">The action that runs when a new message is entered in queue.</param>
        void StartConsume<T>(Action<T> action);
    }
}
