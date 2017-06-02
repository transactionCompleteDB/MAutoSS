using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class CarFeature
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Cars_CarFeatures> Cars_CarFeatures { get; set; }
    }
}
