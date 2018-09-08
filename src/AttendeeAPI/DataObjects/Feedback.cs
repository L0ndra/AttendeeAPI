using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    /// <summary>
    /// Per user feedback
    /// </summary>
    public class Feedback: BaseTableEntity
    {
        public string UserId { get; set; }
        public string SessionId { get; set; }
        public int SessionRating { get; set; }
        public int Prepeared { get; set; }
        public int Learnnew { get; set; }
        public int StayedinFocus { get; set; }
        public int Expertise { get; set; }
    }
}