using System.Threading.Tasks;

namespace BusinessServices {


    public interface IAsyncCommandHandler<in TCommand> {

        Task Handle(TCommand command);
    }
}