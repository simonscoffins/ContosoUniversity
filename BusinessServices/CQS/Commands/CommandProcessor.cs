using System;
using System.Threading.Tasks;
using SimpleInjector;

namespace BusinessServices {

    public class CommandProcessor : ICommandProcessor {

        private readonly Container _container;

        public CommandProcessor(Container container) {
            _container = container;
        }

        public void Process(ICommand command) {

            var handler = GetHandler(command, typeof(ICommandHandler<>));
            handler.Handle((dynamic)command);
        }


        public async Task ProcessAsync(ICommand command) {

            var handler = GetHandler(command, typeof(IAsyncCommandHandler<>));
            await handler.Handle((dynamic)command);
        }


        private dynamic GetHandler(object query, Type handlerType) {

            var queryType = query.GetType();
            var generichandlerType = handlerType.MakeGenericType(queryType);
            dynamic handler = _container.GetInstance(generichandlerType);

            return handler;
        }

    }
}