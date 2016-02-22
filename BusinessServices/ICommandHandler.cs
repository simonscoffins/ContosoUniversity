namespace BusinessServices {
    public interface ICommandHandler<TCommand> {

        void Handle(TCommand command);
    }
}