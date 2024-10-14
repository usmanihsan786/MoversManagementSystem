//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Data.SqlClient;
//using MoversManagementSystem.Models;
//using System.Xml;

//namespace MoversManagementSystem.Repositories;



//    public class MovingQuotesRepository : IMovingQuotesRepository<MovingQuotes>
//     {
//        string connectionString = "Server=USMAN-IHSAN\\SQLEXPRESS;Database=MMS;Trusted_Connection=True;TrustServerCertificate=True";

    

//    public int Save(MovingQuotes movingQuotes)
//        {

//        SqlConnection mycon = new SqlConnection(connectionString);
//        mycon.Open();
//        string InsertCommand = $"insert into MovingQuotes " +
//           $"values " +
//           $"('{movingQuotes.FullName}'" +
//           $",'{movingQuotes.Email}'," +
//           $"'{movingQuotes.Phone}', " +
//           $"'{movingQuotes.MovingFrom}'," +
//           $"'{movingQuotes.MovingTo}'," +
//           $"'{movingQuotes.Comments}'," +
//           $"'{movingQuotes.MovingDate.ToString("yyyy-MM-dd")}');";

//        SqlCommand mycmd = new SqlCommand(InsertCommand, mycon);

//        int rowsAffected = mycmd.ExecuteNonQuery();
//        return rowsAffected;

//    }

//    public int Update(MovingQuotes movingQuotes)
//    {

//        SqlConnection mycon = new SqlConnection(connectionString);  
//        mycon.Open();
//        var UpdateCmd = $"update MovingQuotes " +
//            $"set FullName = '{movingQuotes.FullName}'," +
//            $"Email = '{movingQuotes.Email}'  ," +
//            $"Phone ='{movingQuotes.Phone}'," +
//            $" MovingFrom= '{movingQuotes.MovingFrom}'," +
//            $" MovingTo= '{movingQuotes.MovingTo}'" +
//            $",Comments = '{movingQuotes.Comments}' ," +
//            $"MovingDate ='{movingQuotes.MovingDate}'" +
//            $"Where QuoteId = '{movingQuotes.QuoteId}';";

//        SqlCommand cmd = new SqlCommand(UpdateCmd, mycon);
//        int rowsAffected =cmd.ExecuteNonQuery();
//        return rowsAffected;

//    }

//    public int Delete( int Id)
//    {
//        SqlConnection mycon = new SqlConnection(connectionString);
//        mycon.Open();
//        var DeleteCmd = $"Delete From MovingQuotes" +
//            $" Where QuoteId = '{Id}';";

//        SqlCommand cmd = new SqlCommand(DeleteCmd, mycon);
//        int rowsAffected = cmd.ExecuteNonQuery();
//        return rowsAffected;
//    }

//    public List<MovingQuotes> GetQuotes()
//    {
//        SqlConnection mycon = new SqlConnection(connectionString);
//        mycon.Open();

//        string GetQuoteQuery = "SELECT * FROM MovingQuotes";

//        SqlCommand cmd = new SqlCommand(GetQuoteQuery, mycon);

//         SqlDataReader reader = cmd.ExecuteReader();
//        List<MovingQuotes> ListQuotes = new List<MovingQuotes>();


//        while(reader.Read())
//            {

//            MovingQuotes movingQuotes = new MovingQuotes();
//            movingQuotes.QuoteId = Convert.ToInt32(reader["QuoteId"]);
//            movingQuotes.FullName = reader["FullName"].ToString();
//            movingQuotes.Email = reader["Email"].ToString();
//            movingQuotes.Phone = reader["Phone"].ToString();
//            movingQuotes.MovingFrom = reader["MovingFrom"].ToString();
//            movingQuotes.MovingTo = reader["MovingTo"].ToString();
//            movingQuotes.Comments = reader["Comments"].ToString();
//            movingQuotes.MovingDate = Convert.ToDateTime(reader["MovingDate"]);

//            ListQuotes.Add(movingQuotes);

//            }
//               return ListQuotes;            
//    }

//    public MovingQuotes GetQoutesById(int id)
//    {
//        SqlConnection mycon = new SqlConnection(connectionString);
//        mycon.Open();

//        var GetQoute = $"SELECT * FROM MovingQuotes WHERE QuoteId = {id}";
//        SqlCommand cmd = new SqlCommand(GetQoute, mycon);
//        var Reader = cmd.ExecuteReader();
//        Reader.Read();

//        MovingQuotes movingQuotes = new MovingQuotes();
//        movingQuotes.QuoteId = Convert.ToInt32 ( Reader["QuoteId"]);
//        movingQuotes.FullName = Reader["FullName"].ToString();
//        movingQuotes.Email = Reader["Email"].ToString();
//        movingQuotes.Phone =  Reader["Phone"].ToString();
//        movingQuotes.MovingFrom = Reader["MovingFrom"].ToString();
//        movingQuotes.MovingTo = Reader["MovingTo"].ToString();
//        movingQuotes.Comments = Reader["Comments"].ToString();
//        movingQuotes.MovingDate = Convert.ToDateTime(Reader["MovingDate"]);


//        return movingQuotes;
//    }




//}
