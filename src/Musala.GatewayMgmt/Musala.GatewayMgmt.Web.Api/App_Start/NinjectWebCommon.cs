[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Musala.GatewayMgmt.Web.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Musala.GatewayMgmt.Web.Api.App_Start.NinjectWebCommon), "Stop")]

namespace Musala.GatewayMgmt.Web.Api.App_Start
{
    using AutoMapper;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Musala.GatewayMgmt.Interfaces.DataAccess.Repositories;
    using Musala.GatewayMgmt.Mapper;
    using Musala.GatewayMgmt.Repositories.Ef;
    using Musala.GatewayMgmt.Repositories.Ef.Repositories;
    using Musala.GatewayMgmt.Services;
    using Musala.GatewayMgmt.SystemInterfaces.Services;
    using Musala.GatewayMgmt.Web.Api.Controllers;
    using Musala.Infrastructure;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using Ninject.Web.WebApi;
    using System;
    using System.Web;
    using System.Web.Http;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<EfUnitOfWork>().InRequestScope();

            // unit of work per request
            kernel.Bind<IUnitOfWorkFactory>().To<EfUnitOfWorkFactory>().InRequestScope();

            // AutoMapper
            kernel.Bind<IMapper>().ToMethod(AutoMapper).InSingletonScope();

            // Repositories
            kernel.Bind<IGatewayRepository>().To<GatewayRepository>();
            kernel.Bind<IDeviceRepository>().To<DeviceRepository>();

            // services
            kernel.Bind<IGatewayService>().To<GatewayService>();
            kernel.Bind<IDeviceService>().To<DeviceService>();

            // Controllers
            kernel.Bind<GatewayController>().ToSelf();
            kernel.Bind<DeviceController>().ToSelf();

            // default binding for everything except unit of work
            //kernel.Bind(x => x.FromAssembliesMatching("*").SelectAllClasses().Excluding<UnitOfWork>().BindDefaultInterface());
        }


        private static IMapper AutoMapper(Ninject.Activation.IContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.ConstructServicesUsing(type => context.Kernel.Get(type));
                cfg.AddProfile(new GatewayMapperProfile());
                cfg.AddProfile(new DeviceMapperProfile());

            });

            Mapper.AssertConfigurationIsValid(); // optional
            return Mapper.Instance;
        }
    }
}