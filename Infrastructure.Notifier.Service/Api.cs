using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace Infrastructure.Notifier.Service
{
    public static class Api
    {
        [FunctionName("Subscribe")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "subscribe")]SubscriptionRequest subscriptionRequest, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            log.Info(subscriptionRequest.Topic);

            var subscriptionsBlob = NotificationRegisterLoader.GetSubscriptionsBlob();
            var register = NotificationRegisterLoader.GetRegister(subscriptionsBlob);

            register.AddSubscription(subscriptionRequest);
            var serializedRegister = JsonConvert.SerializeObject(register, Formatting.Indented);
            subscriptionsBlob.UploadText(serializedRegister);
            log.Info(serializedRegister);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [FunctionName("Unsubscribe")]
        public static async Task<HttpResponseMessage> Unsubscribe([HttpTrigger(AuthorizationLevel.Function, "post", Route = "unsubscribe")]UnsubscriptionRequest unsubscriptionRequest, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");
            log.Info(unsubscriptionRequest.Topic);

            var subscriptionsBlob = NotificationRegisterLoader.GetSubscriptionsBlob();
            var register = NotificationRegisterLoader.GetRegister(subscriptionsBlob);

            register.DeleteSubscription(unsubscriptionRequest);
            var serializedRegister = JsonConvert.SerializeObject(register, Formatting.Indented);
            subscriptionsBlob.UploadText(serializedRegister);
            log.Info(serializedRegister);

            return new HttpResponseMessage(HttpStatusCode.OK);
        }

    }
}
