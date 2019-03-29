using System;

namespace Infrastructure.Notifier.Client
{
    public class Notification
    {
        public Notification(string topic, string message)
        {
            Topic = topic;
            Message = message;
        }

        private Notification()
        {
        }

        public string Topic { get; private set; }
        public string Message { get; private set; }
    }
}
