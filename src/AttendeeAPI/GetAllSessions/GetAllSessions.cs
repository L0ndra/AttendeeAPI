
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Conference.DataObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.Protocol;
using Newtonsoft.Json;

namespace SessionAPI
{
    public static class GetAllSessions
    {
        [FunctionName("GetAllSessions")]
        public static async Task<IActionResult> RunAsync([HttpTrigger]HttpRequest req, [Table("Session")]CloudTable sessions, [Table("Speaker")]CloudTable speakers, [Table("Room")]CloudTable rooms, [Table("Category")]CloudTable categories, TraceWriter log)
        {
            var allSessions = await sessions.ExecuteQuerySegmentedAsync(new TableQuery<Session>(), null);
            var allSpeakers = await speakers.ExecuteQuerySegmentedAsync(new TableQuery<Speaker>(), null);
            var allRooms = await rooms.ExecuteQuerySegmentedAsync(new TableQuery<Room>(), null);
            var allCategories = await categories.ExecuteQuerySegmentedAsync(new TableQuery<Category>(), null);

            foreach (var session in allSessions)
            {
                if (session.SpeakersIds != null)
                {
                    session.Speakers = allSpeakers.Where(x => session.SpeakersIds.Contains(x.Id)).ToList();
                }

                session.Room = allRooms.FirstOrDefault(x => x.Id == session.RoomId);
                session.MainCategory = allCategories.FirstOrDefault(x => x.Id == session.CategoryId);
            }

            return new OkObjectResult(allSessions);
        }
    }
}
