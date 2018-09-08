using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    public class Notification: BaseTableEntity
    {        
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}

