namespace Infrastructure.Notifier.Service
{
    public class SubscriptionRequest
    {
        public SubscriptionRequest(string userId, string topic, string channel)
        {
            UserId = userId;
            Topic = topic;
            Channel = channel;
        }
        public SubscriptionRequest()
        {

        }
        public string UserId { get; private set; }
        public string Topic { get; private set; }
        public string Channel { get; private set; }
    }
}
