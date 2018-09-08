using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    public class MiniHack: BaseTableEntity
    {
        public string Name { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string GitHubUrl {get;set;}
        public string BadgeUrl { get; set; }
        public string UnlockCode { get; set; }
    }
}

