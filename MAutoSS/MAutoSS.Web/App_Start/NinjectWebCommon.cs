[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MAutoSS.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MAutoSS.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MAutoSS.Web.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using MAutoSS.Data.Contracts;
    using MAutoSS.Data;
    using MAutoSS.Data.Repositories.Contracts;
    using MAutoSS.Data.Repositories;
    using MAutoSS.Services;
    using MAutoSS.Services.Contracts;
    using System.Data.Entity;
    using MAutoSS.Data.Postgre;
    using MAutoSS.Data.Postgre.Contracts;
    using Ninject.Activation;
    using System.Linq;

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

            //SQL Server dbcontext bindings
            //kernel.Bind<DbContext>().To<MAutoSSDbContext>().InRequestScope();
            //kernel.Bind<IMAutoSSDbContext>().To<MAutoSSDbContext>().InRequestScope();

            //PostgreSQL dbcontext bindings
            kernel.Bind<DbContext>().To<MAutoSSDbContextPostgre>().InRequestScope();
            kernel.Bind<IMAutoSSDbContextPostgre>().To<MAutoSSDbContextPostgre>().InRequestScope();

            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>)).InRequestScope();

            kernel.Bind<IDealershipService>().To<DealershipService>();
            kernel.Bind<IEmployeeService>().To<EmployeeService>().InRequestScope();
            kernel.Bind<ICarBrandsService>().To<CarBrandsService>().InRequestScope();
            kernel.Bind<ICarModelsService>().To<CarModelsService>().InRequestScope();
            kernel.Bind<ICarService>().To<CarService>().InRequestScope();
            kernel.Bind<ICarFeaturesService>().To<CarFeaturesService>().InRequestScope();
            kernel.Bind<ITransmissionTypesService>().To<TransmissionTypeService>().InRequestScope();
            kernel.Bind<IVehicleTypeService>().To<VehicleTypeService>().InRequestScope();
            kernel.Bind<IFuelTypeService>().To<FuelTypeService>().InRequestScope();

            kernel.Bind<ICustomerService>().To<CustomerService>().InRequestScope();
            kernel.Bind<IDiscountService>().To<DiscountService>().InRequestScope();
        }

        public static bool IsInjectingToRepositoryDataSourceOfNamespace(
          this IRequest request, string entityNamespace)
        {
            if (request.ParentRequest.Service.GetGenericTypeDefinition() ==
                 typeof(DbContext))
            {
                return request.ParentRequest.Service.GetGenericArguments().First().Namespace
                     == entityNamespace;
            }

            return false;
        }
        
    }
}
