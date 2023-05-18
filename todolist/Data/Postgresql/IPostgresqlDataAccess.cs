namespace todolist.Data.Postgresql
{
    public interface IPostgresqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, U>(string script, U parameters, string connectionId = "Default");
        Task SetData<U>(string script, U parameters, string connectionId = "Default");
    }
}