namespace Infrastructure.Notifier.Service
{
    public class UnsubscriptionRequest
    {
        public UnsubscriptionRequest(string userId, string topic)
        {
            UserId = userId;
            Topic = topic;
        }
        public UnsubscriptionRequest()
        {

        }
        public string UserId { get; private set; }
        public string Topic { get; private set; }
    }
}
