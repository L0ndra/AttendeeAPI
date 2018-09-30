
using System;
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

namespace Upsert
{
    public static class UpsertSession
    {
        [FunctionName("UpsertSession")]
        public static async Task<IActionResult> Run([HttpTrigger("post", Route = "Sessions")]HttpRequest req, [Table("Session")]CloudTable sessions, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var session = JsonConvert.DeserializeObject<Session>(requestBody);

            session.PartitionKey = session.Id;
            session.RowKey = session.Id;
            session.SpeakersIdsJson = JsonConvert.SerializeObject(session.SpeakersIds);
            
            log.LogInformation(JsonConvert.SerializeObject(session));
            
            var result = await sessions.ExecuteAsync(TableOperation.InsertOrReplace(session));
            
            return new OkObjectResult(result.Result);
        }
    }
}
