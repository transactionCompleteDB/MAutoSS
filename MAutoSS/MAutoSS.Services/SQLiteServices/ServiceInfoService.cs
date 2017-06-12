using Bytes2you.Validation;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels.SQLite.Models;
using MAutoSS.Services.Contracts.SQLiteContracts;

namespace MAutoSS.Services.SQLiteServices
{
    public class ServiceInfoService : IServiceInfoService
    {
        private IGenericRepository<ServiceInfo> serviceInfoRepo;

        public ServiceInfoService(
           IGenericRepository<ServiceInfo> serviceInfoRepo)
        {
            Guard.WhenArgument(serviceInfoRepo, "serviceInfoRepo").IsNull().Throw();

            this.serviceInfoRepo = serviceInfoRepo;
        }

        public void AddServiceInfo(string description)
        {
            var serviceInfo = new ServiceInfo
            {
                Description = description
            };

            this.serviceInfoRepo.Add(serviceInfo);
        }
    }
}
