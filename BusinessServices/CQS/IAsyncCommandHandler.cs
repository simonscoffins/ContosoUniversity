using System.Threading.Tasks;

namespace BusinessServices.CQS {

    public interface IAsyncCommandHandler<in TCommand> {

        Task Handle(TCommand command);
    }
}