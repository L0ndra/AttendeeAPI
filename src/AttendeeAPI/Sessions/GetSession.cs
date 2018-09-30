
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace Sessions
{
    public static class GetSession
    {
        [FunctionName("GetSession")]
        public static async Task<IActionResult> Run([HttpTrigger("get", Route = "Sessions/{id}")]HttpRequest req, string id, [Table("Session")]CloudTable sessions, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var session = await sessions.ExecuteAsync(TableOperation.Retrieve(id, id));

            return session != null
                ? (ActionResult)new OkObjectResult(session.Result)
                : new BadRequestObjectResult($"There are no session with with {id} id");
        }
    }
}
