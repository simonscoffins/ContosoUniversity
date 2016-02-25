using Repository;

namespace BusinessServices.Decorators {


    public class SaveCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand> {

        private readonly ICommandHandler<TCommand> _decorated;
        private readonly IUnitOfWork _uow;

        public SaveCommandHandlerDecorator(ICommandHandler<TCommand> decorated, IUnitOfWork uow) {
            _decorated = decorated;
            _uow = uow;
        }

        public void Handle(TCommand command) {

            _decorated.Handle(command);
            //var task = _uow.SaveChangesAsync();
            //task.Wait();
        }
    }
}