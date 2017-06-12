using System.Data.Entity;
using MAutoSS.Data.Postgre.Contracts;
using MAutoSS.DataModels.Postgre.Models;

namespace MAutoSS.Data.Postgre
{
    public class MAutoSSDbContextPostgre : DbContext, IMAutoSSDbContextPostgre
    {
        public MAutoSSDbContextPostgre() 
            : base("PostgreConnection")
        {
        }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Discount> Discounts { get; set; }
    }
}