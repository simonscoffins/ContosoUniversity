using System.Threading.Tasks;

namespace BusinessServices {

    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult> {

        TResult Handle(TQuery query);
    }
}