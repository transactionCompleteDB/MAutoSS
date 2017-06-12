[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MAutoSS.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MAutoSS.Web.App_Start.NinjectWebCommon), "Stop")]

namespace MAutoSS.Web.App_Start
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using MAutoSS.Data;
    using MAutoSS.Data.Repositories;
    using MAutoSS.Data.Repositories.Contracts;
    using MAutoSS.DataModels.Postgre.Models;
    using MAutoSS.Data.Postgre;
    using MAutoSS.DataModels;
    using MAutoSS.Data.Contracts;
    using MAutoSS.Data.Postgre.Contracts;
    using MAutoSS.Services;
    using MAutoSS.Services.Contracts;
    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            ////SQL Server dbcontext bindings
            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<Address>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<Car>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<CarBrand>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<CarFeature>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<CarModel>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<City>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<Country>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<Dealership>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
               .WhenInjectedInto<IGenericRepository<Employee>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
               .WhenInjectedInto<IGenericRepository<FuelType>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<Sale>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<TransimssionType>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContext>()
                .WhenInjectedInto<IGenericRepository<VehicleType>>().InRequestScope();

            ////PostgreSQL dbcontext bindings
            kernel.Bind<DbContext>().To<MAutoSSDbContextPostgre>()
                .WhenInjectedInto<IGenericRepository<Customer>>().InRequestScope();

            kernel.Bind<DbContext>().To<MAutoSSDbContextPostgre>()
                .WhenInjectedInto<IGenericRepository<Discount>>().InRequestScope();

            // OLD BINDINGS (WORKING SEPARATELY) SQL Server dbcontext bindings
            // kernel.Bind<DbContext>().To<MAutoSSDbContext>().InRequestScope();
            // kernel.Bind<IMAutoSSDbContext>().To<MAutoSSDbContext>().InRequestScope();

            // OLD BINDINGS (WORKING SEPARATELY) PostgreSQL dbcontext bindings
            // kernel.Bind<DbContext>().To<MAutoSSDbContextPostgre>().InRequestScope();
            // kernel.Bind<IMAutoSSDbContextPostgre>().To<MAutoSSDbContextPostgre>().InRequestScope();

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
    }
}
