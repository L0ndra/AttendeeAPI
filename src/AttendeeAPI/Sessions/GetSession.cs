
using System;
using System.Collections.Generic;
using System.IO;
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
    public static class GetSession
    {
        [FunctionName("GetSession")]
        public static async Task<IActionResult> Run([HttpTrigger("get", Route = "Sessions/{id}")]HttpRequest req, string id, [Table("Session")]CloudTable sessions, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            log.LogInformation(id);

            var result = await sessions.ExecuteAsync(TableOperation.Retrieve<Session>(id, id));

            var session = result.Result as Session;
            if (session == null)
            {
                return new BadRequestObjectResult($"There are no session with with {id} id");
            }
            
            session.SpeakersIds = JsonConvert.DeserializeObject<IEnumerable<string>>(session.SpeakersIdsJson);
            
            log.LogInformation(JsonConvert.SerializeObject(session));

            return new OkObjectResult(session);

        }
    }
}
