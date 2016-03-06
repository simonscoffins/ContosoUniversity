using System.Threading.Tasks;

namespace BusinessServices.CQS {


    public interface IQueryMediator {

        Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query);
    }
}