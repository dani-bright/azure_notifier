using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;

namespace Infrastructure.Notifier.Service
{
    public static class NotificationRegisterLoader
    {
        public static CloudBlockBlob GetSubscriptionsBlob()
        {
            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("notifications");
            container.CreateIfNotExists();
            var subscriptionsBlob = container.GetBlockBlobReference("subscritions");
            return subscriptionsBlob;
        }

        public static NotificationRegister GetRegister(CloudBlockBlob subscriptionsBlob)
        {
            if (subscriptionsBlob.Exists())
            {
                //subscriptionsBlob.Delete();
                var registerJson = subscriptionsBlob.DownloadText();
                var register = JsonConvert.DeserializeObject<NotificationRegister>(registerJson);
                return register;
            }
            else
            {
                return new NotificationRegister(new List<Subscription>());
            }
        }

    }
}
