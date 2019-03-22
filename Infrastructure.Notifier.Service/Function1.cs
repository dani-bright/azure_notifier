using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Infrastructure.Notifier.Service
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;
            string nb1 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "nb1", true) == 0)
                .Value;
            string nb2 = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "nb2", true) == 0)
                .Value;
            var result = int.Parse(nb1) + int.Parse(nb2);

            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Hello " + name + " "+ nb1+ " + " + nb2 + " font" + result);
        }
    }
}
