﻿using System.Data.Entity;

using MAutoSS.Data.Contracts;
using MAutoSS.DataModels;

namespace MAutoSS.Data
{
    public class MAutoSSDbContext : DbContext, IMAutoSSDbContext
    {
        public MAutoSSDbContext()
            : base("MAutoSS")

        {

        }

        public virtual IDbSet<Dealership> Dealerships { get; set; }

        public virtual IDbSet<Address> Addresses { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Employee> Employees { get; set; }

        public virtual IDbSet<Sale> Sales { get; set; }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<CarFeature> CarFeatures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dealership>()
                .HasOptional(d => d.Address)
                .WithRequired(a => a.Dealership);

            base.OnModelCreating(modelBuilder);
        }
    }
}