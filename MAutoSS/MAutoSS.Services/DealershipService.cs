using System.Collections.Generic;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class DealershipService : IDealershipService
    {
        private IGenericRepository<Dealership> dealershipRepo;
        private IDealershipService dealershipService;

        public DealershipService(IGenericRepository<Dealership> dealershipRepo, IDealershipService dealershipService)
        {
            this.dealershipRepo = dealershipRepo;
            this.dealershipService = dealershipService;
        }

        public IEnumerable<Dealership> GetAllDealerships()
        {
            return this.dealershipRepo.GetAll();
        }
    }
}
