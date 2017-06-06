using System.Collections.Generic;

using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface IDealershipService
    {
        IEnumerable<Dealership> GetAllDealerships();

        void CreateNewDealership(string dealershipName, string addressText, string cityName, string countryName);
    }
}
