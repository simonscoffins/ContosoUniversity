using System.Threading.Tasks;

namespace BusinessServices.CQS.Commands {

    public interface IAsyncCommandResponseHandler<in TCommand, TResponse> {

        Task<TResponse> Handle(TCommand command);
    }
}