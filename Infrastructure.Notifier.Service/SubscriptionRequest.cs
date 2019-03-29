namespace Infrastructure.Notifier.Service
{
    public class SubscriptionRequest
    {
        public SubscriptionRequest(string userId, string topic)
        {
            UserId = userId;
            Topic = topic;
        }
        public SubscriptionRequest()
        {

        }
        public string UserId { get; private set; }
        public string Topic { get; private set; }
    }
}
