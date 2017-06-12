using MAutoSS.DataModels.Postgre.Models;
using System.Data.Entity;

namespace MAutoSS.Data.Postgre.Contracts
{
    public interface IMAutoSSDbContextPostgre
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Discount> Discounts { get; set; }
    }
}