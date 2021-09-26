using System.Threading.Tasks;

namespace flicket.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
