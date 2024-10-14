namespace MMS.Application.Features.persistence;

public interface IMovingQuotesRepository<T> where T : class, new()
{
    int Save(T entity);
    int Update(T entity);
    int Delete(int Id);
    List<T> GetQuotes();
    T GetQoutesById(int id);

}