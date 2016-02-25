using MediatR.Internal;

namespace MediatR {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Default mediator implementation relying on single- and multi instance delegates for resolving handlers.
    /// </summary>
    public class Mediator : IMediator {
        private readonly SingleInstanceFactory _singleInstanceFactory;

        public Mediator(SingleInstanceFactory singleInstanceFactory) {
            _singleInstanceFactory = singleInstanceFactory;
        }



        public TResponse Send<TResponse>(IRequest<TResponse> request) {
            var defaultHandler = GetHandler(request);

            var result = defaultHandler.Handle(request);

            return result;
        }

        public async Task<TResponse> SendAsync<TResponse>(IAsyncRequest<TResponse> request) {
            var defaultHandler = GetHandler(request);

            var result = await defaultHandler.Handle(request);

            return result;
        }


        private RequestHandlerWrapper<TResponse> GetHandler<TResponse>(IRequest<TResponse> request) {

            return GetHandler<RequestHandlerWrapper<TResponse>, TResponse>(request,
                typeof(IRequestHandler<,>),
                typeof(RequestHandlerWrapper<,>));
        }

        private AsyncRequestHandlerWrapper<TResponse> GetHandler<TResponse>(IAsyncRequest<TResponse> request) {

            return GetHandler<AsyncRequestHandlerWrapper<TResponse>, TResponse>(request, typeof(IAsyncRequestHandler<,>), typeof(AsyncRequestHandlerWrapper<,>));
        }


        private TWrapper GetHandler<TWrapper, TResponse>(object request, Type handlerType, Type wrapperType) {

            var requestType = request.GetType();

            var genericHandlerType = handlerType.MakeGenericType(requestType, typeof(TResponse));
            var genericWrapperType = wrapperType.MakeGenericType(requestType, typeof(TResponse));

            var handler = GetHandler(request, genericHandlerType);

            return (TWrapper)Activator.CreateInstance(genericWrapperType, handler);
        }



        private object GetHandler(object request, Type handlerType) {
            try {
                return _singleInstanceFactory(handlerType);
            } catch (Exception e) {
                throw BuildException(request, e);
            }
        }


        private static InvalidOperationException BuildException(object message, Exception inner) {
            return new InvalidOperationException("Handler was not found for request of type " + message.GetType() + ".\r\nContainer or service locator not configured properly or handlers not registered with your container.", inner);
        }
    }
}