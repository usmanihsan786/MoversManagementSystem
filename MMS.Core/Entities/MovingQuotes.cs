
using MMS.Core.Common;
using MMS.Core.Events;
namespace MMS.Core.Entities
{
    public class MovingQuotes : IHasDomainEvents
    {
        public int QuoteId { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Phone { get; private set; } = string.Empty;
        public string MovingFrom { get; private set; } = string.Empty;
        public string MovingTo { get; private set; } = string.Empty;
        public string Comments { get; private set; } = string.Empty;
        public DateTime MovingDate { get; private set; }

            public static MovingQuotes Create(
            string fullName,
            string email,
            string phone,
            string movingFrom,
            string movingTo,
            string comments,
            DateTime movingdate)
        {

            MovingQuotes movingQuotes = new MovingQuotes()
            {
                FullName = fullName,
                Email = email,
                Phone = phone,
                MovingFrom = movingFrom,
                MovingTo = movingTo,
                Comments = comments,
                MovingDate = movingdate,


            };

            movingQuotes.RegisterEvent(new MoveCreatedEvent(movingQuotes, 6562));
            movingQuotes.ClearDomainEvents();
            return movingQuotes;

        }



    }
}