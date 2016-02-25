using System.Threading.Tasks;

namespace BusinessServices {


    public interface IQueryProcessor {

        TResult Process<TResult>(IQuery<TResult> query);

        Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query);
    }
}