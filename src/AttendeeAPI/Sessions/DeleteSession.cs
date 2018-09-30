
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Conference.DataObjects;
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
    public static class DeleteSession
    {
        [FunctionName("DeleteSession")]
        public static async Task<IActionResult> Run([HttpTrigger("delete", Route = "Sessions/{id}")]HttpRequest req, string id, [Table("Session")]CloudTable sessions, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var session = await sessions.ExecuteAsync(TableOperation.Retrieve<Session>(id, id));
            if (session.Result == null)
            {
                return new BadRequestObjectResult($"Entity with {id} don't exist");
            }
            var result = await sessions.ExecuteAsync(TableOperation.Delete(session.Result as Session));

            return new OkObjectResult(result.Result);
        }
    }
}
