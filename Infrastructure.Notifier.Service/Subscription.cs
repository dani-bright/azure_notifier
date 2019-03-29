using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Notifier.Service
{
    public class Subscription
    {

        public Subscription(string topic, List<Subscriber> subscribers)
        {
            Topic = topic;
            Subscribers = subscribers;
        }

        private Subscription()
        {
        }


        public string Topic { get; private set; }
        public List<Subscriber> Subscribers { get; private set; }

        internal void AddSubscriber(string userId, string channel)
        {
            var existingSubscriber = Subscribers.SingleOrDefault(x => x.UserId == userId);
            if (existingSubscriber == null)
            {
                Subscribers.Add(new Subscriber(userId, channel));
            }
        }
        internal void DeleteSubscriber(string userId)
        {
            var existingSubscriber = Subscribers.SingleOrDefault(x => x.UserId == userId);
            if (existingSubscriber != null)
            {
                Subscribers.Remove(existingSubscriber);
            }
        }
    }
}
