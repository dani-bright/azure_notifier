using System;
using System.Linq;
using Infrastructure.Notifier.Client;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace Infrastructure.Notifier.Service
{
    public static class QueueFunction
    {
        [FunctionName("QueueFunction")]
        public static void Run([QueueTrigger("myqueue-items", Connection = "")]string myQueueItem, TraceWriter log)
        {
            var notification = JsonConvert.DeserializeObject<Notification>(myQueueItem);

            var register = NotificationRegisterLoader.GetRegister(NotificationRegisterLoader.GetSubscriptionsBlob());

            var subscribers = register.GetSubscribers(notification.Topic);
            log.Info($"Got notification fom {notification.Topic} {string.Join(", ", subscribers.Select(x=>x.UserId))}");

        }
    }
}
