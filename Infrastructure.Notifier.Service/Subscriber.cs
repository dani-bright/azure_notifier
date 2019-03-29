namespace Infrastructure.Notifier.Service
{
    public class Subscriber
    {
        public Subscriber(string userId)
        {
            UserId = userId;
        }
        private Subscriber()
        {

        }
        public string UserId { get; private set; }
    }
}
