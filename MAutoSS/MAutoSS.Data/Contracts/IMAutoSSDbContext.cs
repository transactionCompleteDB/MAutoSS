using System.Data.Entity;

using MAutoSS.DataModels;

namespace MAutoSS.Data.Contracts
{
    public interface IMAutoSSDbContext
    {
        IDbSet<Dealership> Dealerships { get; set; }

        IDbSet<Address> Addresses { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }

        IDbSet<Employee> Employees { get; set; }

        IDbSet<Sale> Sales { get; set; }

        IDbSet<Car> Cars { get; set; }

        IDbSet<CarFeature> CarFeatures { get; set; }
    }
}
