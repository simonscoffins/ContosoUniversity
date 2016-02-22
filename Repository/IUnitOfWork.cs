using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Repository {
    public interface IUnitOfWork {

        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}