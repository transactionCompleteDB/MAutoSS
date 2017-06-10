using System.Collections.Generic;

using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface IDealershipService
    {
        IEnumerable<Dealership> GetAllDealerships();

        IEnumerable<string> GetAllDealershipsNames();

        Dealership GetAllDealershipById(int id);

        Dealership GetDealershipByName(string name);

        void CreateNewDealership(string dealershipName, string addressText, string cityName, string countryName);

        void Export();
    }
}
