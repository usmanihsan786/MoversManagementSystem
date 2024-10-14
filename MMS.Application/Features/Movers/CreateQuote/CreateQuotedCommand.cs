using MediatR;

namespace MMS.Application.Features.Movers.CreateQuote
{
    public class CreateQuotedCommand : IRequest<bool>
    {
        public int QuoteId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string MovingFrom { get; set; } = string.Empty;
        public string MovingTo { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public DateTime MovingDate { get; set; }

    }
}