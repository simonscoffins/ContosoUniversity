
using System;
using System.Threading.Tasks;
using BusinessServices.Departments;
using SimpleInjector;

namespace BusinessServices {

    public class QueryProcessor : IQueryProcessor {

        private readonly Container _container;

        public QueryProcessor(Container container) {
            _container = container;
        }

        public TResult Process<TResult>(IQuery<TResult> query) {

            var handler = GetHandler<TResult>(query, typeof(IQueryHandler<,>));
            return handler.Handle((dynamic)query);
        }

        public async Task<TResult> ProcessAsync<TResult>(IQuery<TResult> query) {

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