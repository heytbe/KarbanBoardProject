namespace Data.API.UnitOfWork
{
    public interface IUnitOfWorkRepo : IAsyncDisposable
    {
        Task<int> SaveAsync();
        int Save();
    }
}
