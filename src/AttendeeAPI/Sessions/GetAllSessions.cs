
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Conference.DataObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Build.Framework;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.Protocol;
using Newtonsoft.Json;

namespace Sessions
{
    public static class GetAllSessions
    {
        [FunctionName("GetAllSessions")]
        public static async Task<IActionResult> RunAsync([HttpTrigger("get", Route = "Sessions")]HttpRequest req, [Table("Session")]CloudTable sessions, ILogger log)
        {
            TableContinuationToken token = null;
            var allSessions = new List<Session>();
            do
            {
                var result = await sessions.ExecuteQuerySegmentedAsync(new TableQuery<Session>(), token);
                token = result.ContinuationToken;
                allSessions.AddRange(result.Results);
            } while (token != null);

            return new OkObjectResult(allSessions);
        }
    }
}
