namespace BusinessServices.CQS.Commands {

    public interface ICommandResponseHandler<in TCommand, out TResponse> {

        TResponse Handle(TCommand command);
    }
}