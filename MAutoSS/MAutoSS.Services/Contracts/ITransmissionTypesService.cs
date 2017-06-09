using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ITransmissionTypesService
    {
        IEnumerable<TransimssionType> GetAllTransmissions();
    }
}
