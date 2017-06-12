using System.Data.Entity;
using MAutoSS.DataModels.Postgre.Models;

namespace MAutoSS.Data.Postgre.Contracts
{
    public interface IMAutoSSDbContextPostgre
    {
        IDbSet<Customer> Customers { get; set; }

        IDbSet<Discount> Discounts { get; set; }
    }
}