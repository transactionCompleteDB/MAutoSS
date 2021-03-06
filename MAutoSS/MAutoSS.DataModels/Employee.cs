﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class Employee
    {
        private ICollection<Sale> sales;

        public Employee()
        {
            this.sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [MinLength(1)]
        [MaxLength(40)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [MinLength(1)]
        [MaxLength(40)]
        public string LastName { get; set; }

        [Required]
        public int DealershipId { get; set; }

        public virtual Dealership Dealership { get; set; }

        public virtual ICollection<Sale> Sales
        {
            get { return this.sales; }
            set { this.sales = value; }
        }
    }
}
