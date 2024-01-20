using Data.API.Context;

namespace Data.API.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWorkRepo
    {
        private readonly AppDbContext _context;

        public UnitOfWorkRepo(AppDbContext context)
        {
            _context = context;
        }

        public async ValueTask DisposeAsync()
        {
           await  _context.DisposeAsync();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
