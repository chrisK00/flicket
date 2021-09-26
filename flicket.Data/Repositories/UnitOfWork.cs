using System.Threading.Tasks;
using flicket.Data.Interfaces;

namespace flicket.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
                return await _context.SaveChangesAsync() > 0;
        }
    }
}
