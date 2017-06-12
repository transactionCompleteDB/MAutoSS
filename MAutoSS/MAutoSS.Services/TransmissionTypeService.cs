using System.Collections.Generic;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class TransmissionTypeService : ITransmissionTypesService
    {
        private readonly IGenericRepository<TransimssionType> transmissionRepo;

        public TransmissionTypeService(
           IGenericRepository<TransimssionType> transmissionRepo)
        {
            Guard.WhenArgument(transmissionRepo, "transmissionRepo").IsNull().Throw();

            this.transmissionRepo = transmissionRepo;
        }

        public IEnumerable<TransimssionType> GetAllTransmissions()
        {
            return this.transmissionRepo.GetAll();
        }
    }
}
