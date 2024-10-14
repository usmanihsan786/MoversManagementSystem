//using Dapper;
//using MediatR;
//using Microsoft.Data.SqlClient;
//using MoversManagementSystem.Events;
//using MoversManagementSystem.Models;
//using System.Runtime.Intrinsics.Arm;

//namespace MoversManagementSystem.Repositories;

//public class DapperMovingQuotesRepository : IMovingQuotesRepository<MovingQuotes>
//{
//    private readonly IMediator _mediator;
//    string connectionString = "Server=USMAN-IHSAN\\SQLEXPRESS;Database=MMS;Trusted_Connection=True;TrustServerCertificate=True";
//    public DapperMovingQuotesRepository(IMediator mediator)
//    {
//        _mediator = mediator;
//    }
//    public int Delete(int Id)
//    {
//        using SqlConnection connection = new SqlConnection(connectionString);
//        var DeleteCmd = $"Delete From MovingQuotes" +
//        $" Where {nameof(MovingQuotes.QuoteId)}  = '{Id}'";
//        int rowsAffected = connection.Execute(DeleteCmd);
//        return rowsAffected;

//    }

//    public MovingQuotes GetQoutesById(int id)
//    {
//        using SqlConnection connection = new SqlConnection(connectionString);

//        var GetByID = $"SELECT * FROM MovingQuotes WHERE {nameof(MovingQuotes.QuoteId)} = {id}";

//       MovingQuotes? myQuote = connection.QueryFirstOrDefault<MovingQuotes>(GetByID);
//        return myQuote; 
//    }

//    public List<MovingQuotes> GetQuotes()
//    {
//        using SqlConnection connection = new SqlConnection(connectionString);
//        string GetQuoteQuery = "SELECT * FROM MovingQuotes";

//       var myQuotes =  connection.Query<MovingQuotes>(GetQuoteQuery);
//        return myQuotes.ToList(); 
        
//    }

//    public int Save(MovingQuotes movingQuotes)
//    {
//        using SqlConnection connection = new SqlConnection(connectionString);
//        string InsertCommand = $"insert into MovingQuotes (FullName, Email, Phone, " +
//            $"MovingFrom, MovingTo, Comments, MovingDate) " +

//            $"values (@FullName, @Email, @Phone, " +
//            $"@MovingFrom, @MovingTo, @Comments, @MovingDate);";

//        int rowsAffected = connection.Execute(InsertCommand, new
//        {
//            movingQuotes.FullName,
//            movingQuotes.Email,
//            movingQuotes.Phone,
//            movingQuotes.MovingFrom,
//            movingQuotes.MovingTo,
//            movingQuotes.Comments,
//            MovingDate = movingQuotes.MovingDate.ToString("yyyy-MM-dd")
//        });
//        return rowsAffected;
//    }

//    public int Update(MovingQuotes movingQuotes)
//    {
//        using SqlConnection connection = new SqlConnection(connectionString);
//        string UpdateCmd = $"update MovingQuotes " +
//           $"set FullName = '{movingQuotes.FullName}'," +
//           $" Email = '{movingQuotes.Email}'  ," +
//           $" Phone ='{movingQuotes.Phone}'," +
//           $" MovingFrom = '{movingQuotes.MovingFrom}'," +
//           $" MovingTo = '{movingQuotes.MovingTo}'" +
//           $",Comments = '{movingQuotes.Comments}' ," +
//           $" MovingDate ='{movingQuotes.MovingDate}'" +
//           $"Where QuoteId = '{movingQuotes.QuoteId}'";

//        int rowsAffected = connection.Execute(UpdateCmd);

//        foreach(var @events in movingQuotes.DomainEvent )
//        {
//            _mediator.Publish( @events );
//        }

//        _mediator.Publish(new MoveScheduledUpdatedEvent(movingQuotes,4));

//        return rowsAffected;

//    }
//}
