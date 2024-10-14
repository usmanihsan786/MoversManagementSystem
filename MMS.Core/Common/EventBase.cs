using MediatR;

namespace MMS.Core.Common
{
    public abstract class EventBase : INotification
    {
        protected EventBase(
            string id,
            int userid,
            DateTime occuredAt,
            int aggregateId)
        {
            Id = id;
            UserId = userid;
            OccuredAt = occuredAt;
            AggregateId = aggregateId;
        }
        public string Id { get; } = string.Empty;
        public int UserId { get; }
        public DateTime OccuredAt { get; }
        public int AggregateId { get; }


    }
}