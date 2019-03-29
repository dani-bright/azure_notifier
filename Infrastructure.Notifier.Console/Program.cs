using Infrastructure.Notifier.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;

namespace Infrastructure.Notifier.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.ReadLine();

            var account = CloudStorageAccount.Parse("UseDevelopmentStorage=true");
            var queueClient = account.CreateCloudQueueClient();
            var myQueue = queueClient.GetQueueReference("myqueue-items");
            myQueue.CreateIfNotExists();
            var content = JsonConvert.SerializeObject(new Notification("topic2", "test"));
            myQueue.AddMessage(new CloudQueueMessage(content));
        }
    }
   
}
