using System.Threading.Tasks;
using BusinessServices.CQS;
using Repository;

namespace BusinessServices.Decorators {


    public class SaveCommandHandlerDecorator<TCommand> : IAsyncCommandHandler<TCommand> {

        private readonly IAsyncCommandHandler<TCommand> _decorated;
        private readonly IUnitOfWork _uow;

        public SaveCommandHandlerDecorator(IAsyncCommandHandler<TCommand> decorated, IUnitOfWork uow) {
            _decorated = decorated;
            _uow = uow;
        }

        public async Task Handle(TCommand command) {

            await _decorated.Handle(command);
            await _uow.SaveChangesAsync();
        }
    }
}