using System;
using System.Threading.Tasks;
using SimpleInjector;

namespace BusinessServices.CQS {

    public class QueryMediator : IQueryMediator {

        private readonly Container _container;

        public QueryMediator(Container container) {
            _container = container;
        }

        public async Task<TResult> ExecuteAsync<TResult>(IQuery<TResult> query) {

            var handler = GetHandler<TResult>(query, typeof(IAsyncQueryHandler<,>));
            return await handler.Handle((dynamic)query);
        }


        private dynamic GetHandler<TResult>(object query, Type handlerType) {

            var queryType = query.GetType();

            var generichandlerType = handlerType.MakeGenericType(queryType, typeof(TResult));

            dynamic handler = _container.GetInstance(generichandlerType);

            return handler;
        }

    }
}