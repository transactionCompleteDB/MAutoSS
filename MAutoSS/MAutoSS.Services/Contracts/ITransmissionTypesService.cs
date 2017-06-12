using System.Collections.Generic;

using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface ITransmissionTypesService
    {
        IEnumerable<TransimssionType> GetAllTransmissions();
    }
}
