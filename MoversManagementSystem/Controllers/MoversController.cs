


using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMS.Application.Features.Movers.CreateQuote;



namespace MoversManagementSystem.Controllers
{
    [Route("Movers")]
    [ApiController]
    public class MoversController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoversController(IMediator mediator)
        {
            _mediator = mediator;
        }
        //[Route("GetList")]
        //[HttpGet]
        //public IActionResult Getlsit()
        //{
        //   var List = _movingQuotesRepository.GetQuotes();
        //    return Ok(List);
        //}

        //[Route("Get")]
        //[HttpGet]
        //public IActionResult GetById(int id)
        //{
        //    MovingQuotes movingQuote = _movingQuotesRepository.GetQoutesById(id);
        //    //movingQuote.RegisterEvent(new MoveScheduledEvent(1, "2", 1, DateTime.Now, 1));
        //    return Ok(movingQuote);
        //}   

        [Route("Save")]
        [HttpPost]
        public async Task<IActionResult> Save([FromBody] CreateQuoteRequest createQuoteRequest )
        {
            var command = new CreateQuotedCommand()
            {
                QuoteId = createQuoteRequest.QuoteId,
                Email = createQuoteRequest.Email,
                FullName = createQuoteRequest.FullName,
                Phone = createQuoteRequest.Phone,
                MovingFrom  = createQuoteRequest.MovingFrom,
                MovingTo = createQuoteRequest.MovingTo, 
                MovingDate = createQuoteRequest.MovingDate,
                Comments = createQuoteRequest.Comments,

            };
   

               var result =  await _mediator.Send(command);
                   return result ? Ok() : BadRequest() ;

        }

        //[Route("Update")]
        //[HttpPost]
        //public IActionResult Update([FromBody] MovingQuotes movingQuotes)

        //{
        //    int rowsAffected = _movingQuotesRepository.Update(movingQuotes);
        //    return Ok();

          

        //}

        //[Route("Delete")]
        //[HttpDelete]
        //public IActionResult Delete([FromQuery]int id)
        //{

        //   int rowsAffected =_movingQuotesRepository.Delete(id);
        //    return Ok();
        //}


    }
}

public class CreateQuoteRequest
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


public class CrreateQuotesResponse
{
    public bool Success { get; set; }

}