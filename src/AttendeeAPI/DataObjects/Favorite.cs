using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    /// <summary>
    /// This is per user
    /// </summary>
    public class Favorite: BaseTableEntity
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
    }
}