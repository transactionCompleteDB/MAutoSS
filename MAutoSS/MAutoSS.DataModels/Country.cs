using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Country should be between 1 and 40 chars long")]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }

            set { this.cities = value; }
        }
    }
}
