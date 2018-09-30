using Microsoft.WindowsAzure.Storage.Table;

namespace Conference.DataObjects
{
    public class BaseTableEntity: TableEntity
    {
        public new string PartitionKey => Id;
        public new string RowKey => Id;
        public string Id { get; set; }
    }
}