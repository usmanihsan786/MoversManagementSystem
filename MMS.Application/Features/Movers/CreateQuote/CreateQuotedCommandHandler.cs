

using MediatR;
using MMS.Application.Features.persistence;

namespace MMS.Application.Features.Movers.CreateQuote;

public class CreateQuotedCommandHandler : IRequestHandler<CreateQuotedCommand, bool>
{
    private readonly IMovingQuotesRepository<Core.Entities.MovingQuotes> _repository;

    public CreateQuotedCommandHandler(IMovingQuotesRepository<Core.Entities.MovingQuotes> repository)
    {
        _repository = repository;
    }



    public async Task<bool> Handle(CreateQuotedCommand request, CancellationToken cancellationToken)
    {


        var NewQuote = Core.Entities.MovingQuotes.Create(request.FullName,
            request.Email,
            request.Phone,
            request.MovingFrom,
            request.MovingTo,
            request.Comments,
            request.MovingDate);

        int rowsAffected = _repository.Save(NewQuote);
        return rowsAffected > 0;





    }
}