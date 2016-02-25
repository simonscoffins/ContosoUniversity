using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Repository {
    public interface IUnitOfWork {

        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}