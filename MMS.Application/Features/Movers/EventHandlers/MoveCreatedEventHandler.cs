using MediatR;
using MMS.Core.Events;


namespace MMS.Application.Features.MovingQuotes.EventHandlers;

public class UpdateMoveScheduleHandler : INotificationHandler<MoveCreatedEvent>
{
    public async Task Handle(MoveCreatedEvent notification, CancellationToken cancellationToken)
    {

        await Task.Delay(1000);
        Console.WriteLine("we have notified the owner that the Schedule of move has been updated");
    }
}
