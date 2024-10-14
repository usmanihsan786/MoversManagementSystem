using CSharp.Ulid;
using MMS.Core.Common;
using MMS.Core.Entities;

namespace MMS.Core.Events
{
    public class MoveCreatedEvent : EventBase
    {
        public MoveCreatedEvent(

            MovingQuotes movingQuotes,
            int userid) :

            base(
                Ulid.NewUlid().ToString(),
                userid,
                DateTime.UtcNow,
                movingQuotes.QuoteId)
        {
            MovingQuotes = movingQuotes;

        }
        public MovingQuotes MovingQuotes { get; set; }
    }
}