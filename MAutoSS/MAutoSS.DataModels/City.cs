using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class City
    {
        private ICollection<Address> adresses;

        public City()
        {
            this.adresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses
        {
            get { return this.adresses; }
            set { this.adresses = value;}
        }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }


}
