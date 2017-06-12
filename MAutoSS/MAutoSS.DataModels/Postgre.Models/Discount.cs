using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels.Postgre.Models
{
    public class Discount
    {
        private ICollection<Customer> customers;

        public Discount()
        {
            this.customers = new HashSet<Customer>();
        }

        public int Id { get; set; }

        [Range(0,100)]
        public decimal DiscountPercentage { get; set; }

        public virtual ICollection<Customer> Customers
        {
            get { return this.customers; }
            set { this.customers = value; }
        }       
    }
}
