namespace Infrastructure.Notifier.Service
{
    public class Subscriber
    {
        public Subscriber(string userId, string channel)
        {
            UserId = userId;
            Channel = channel;
        }
        private Subscriber()
        {

        }
        public string UserId { get; private set; }
        public string Channel { get; private set; }
    }
}
