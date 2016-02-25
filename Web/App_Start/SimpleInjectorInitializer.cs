using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using BusinessServices;
using BusinessServices.CQS.Commands;
using BusinessServices.Decorators;
using MediatR;
using Repository;
using SimpleInjector;
using SimpleInjector.Extensions;
using SimpleInjector.Integration.WebApi;

namespace Web.App_Start {

    public static class SimpleInjectorInitializer {

        public static void Initialize() {
            var container = new Container();

            InitializeContainer(container);
            InitializeMediator(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void InitializeContainer(Container container) {

            var webApiLifeStyle = new WebApiRequestLifestyle();

            // unit of work - db context injection
            container.Register<IUnitOfWork, ContosoUniversityContext>(webApiLifeStyle);

            // register implementations of generic ICommandHandler
            container.Register(typeof(ICommandHandler<>), new[] { typeof(ICommandHandler<>).Assembly }, webApiLifeStyle);


            container.RegisterDecorator(
                typeof(ICommandHandler<>),
                typeof(SaveCommandHandlerDecorator<>));



            container.Register(typeof(IAsyncCommandHandler<>), new[] { typeof(IAsyncCommandHandler<>).Assembly }, webApiLifeStyle);

            //container.Register(typeof(ICommandResponseHandler<,>), new[] { typeof(ICommandResponseHandler<,>).Assembly }, webApiLifeStyle);
            //container.Register(typeof(IAsyncCommandResponseHandler<,>), new[] { typeof(IAsyncCommandResponseHandler<,>).Assembly }, webApiLifeStyle);


            // register implementations of generic IQueryHandler
            container.Register(typeof(IQueryHandler<,>), new[] { typeof(IQueryHandler<,>).Assembly }, webApiLifeStyle);
            container.Register(typeof(IAsyncQueryHandler<,>), new[] { typeof(IAsyncQueryHandler<,>).Assembly }, webApiLifeStyle);

            // register implementations of generic IQueryHandler
            container.Register<IQueryProcessor, QueryProcessor>();
            //            container.Register<ICommandProcessor, CommandProcessor>();
        }


        private static void InitializeMediator(Container container) {

            var webApiLifeStyle = new WebApiRequestLifestyle();



            var assemblies = GetAssemblies().ToArray();
            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies, webApiLifeStyle);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies, webApiLifeStyle);
            //container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            //container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
            //container.RegisterSingleton(Console.Out);
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            //container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));
        }


        private static IEnumerable<Assembly> GetAssemblies() {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(Ping).GetTypeInfo().Assembly;
        }

    }
}