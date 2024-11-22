namespace Tactical.Framework.Persistence
{
    public class OutBoxEventItem
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string EventName { get; set; } = null!;
        public string EventType { get; set; } = null!;
        public string AggregateName { get; set; } = null!;
        public string AggregateType { get; set; } = null!;
        public bool IsPublished { get; set; }
        public string? Payload { get; set; }

        //public string Creator { get; set; } = null!;
        //public string CreatorService { get; set; } = null!;
        //public string EventId { get; set; } = null!;
    }
}
