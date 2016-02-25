using System.Threading.Tasks;

namespace BusinessServices {

    public interface IAsyncQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> {

        Task<TResult> Handle(TQuery query);
    }


}