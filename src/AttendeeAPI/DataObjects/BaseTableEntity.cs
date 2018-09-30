using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    public class BaseTableEntity: TableEntity
    {
        public string Id { get; set; }
    }
}