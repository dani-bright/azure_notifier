using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Notifier.Service
{
    public class NotificationRegister
    {
        public NotificationRegister(List<Subscription> subscriptions)
        {
            Subscriptions = subscriptions;
        }
        private NotificationRegister()
        {

        }
        public List<Subscription> Subscriptions { get; private set; }

        internal void AddSubscription(SubscriptionRequest subscriptionRequest)
        {
            var existingSubscription = Subscriptions.SingleOrDefault(x => x.Topic == subscriptionRequest.Topic);

            if (existingSubscription == null)
            {
                var subscribers = new List<Subscriber>
                {
                    new Subscriber(subscriptionRequest.UserId)
                };
                var subscription = new Subscription(subscriptionRequest.Topic, subscribers);
                Subscriptions.Add(subscription);
            }
            else
            {
                existingSubscription.AddSubscriber(subscriptionRequest.UserId); 
            }

        }

        internal IEnumerable<Subscriber> GetSubscribers(string topic)
        {
            var subscriptions = Subscriptions.Where(x => x.Topic == topic).SelectMany(w=>w.Subscribers);
            return subscriptions;
        }

        internal void DeleteSubscription(UnsubscriptionRequest unsubscriptionRequest)
        {
            var existingSubscription = Subscriptions.SingleOrDefault(x => x.Topic == unsubscriptionRequest.Topic);

            existingSubscription?.DeleteSubscriber(unsubscriptionRequest.UserId); //condition != null
        }
    }
}
