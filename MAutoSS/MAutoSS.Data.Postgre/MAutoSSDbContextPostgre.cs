﻿using MAutoSS.DataModels.Postgre.Models;
using System.Data.Entity;

namespace MAutoSS.Data.Postgre
{
    public class MAutoSSDbContextPostgre : DbContext
    {
        public MAutoSSDbContextPostgre() : base("PostgreConnection")
        {

        }

        public virtual IDbSet<Customer> Customers { get; set; }

        public virtual IDbSet<Discount> Discounts { get; set; }
    }
}