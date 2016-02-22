﻿
using SimpleInjector;

namespace BusinessServices {

    public class QueryProcessor : IQueryProcessor {

        private readonly Container _container;

        public QueryProcessor(Container container) {
            _container = container;
        }

        public TResult Process<TResult>(IQuery<TResult> query) {

            var handlerType = typeof (IQueryHandler<,>).MakeGenericType(query.GetType(), typeof (TResult));
            dynamic handler = _container.GetInstance(handlerType);

            return handler.Handle((dynamic) query);
        }
    }
}