using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class Cars_CarFeatures
    { 
        [Key, Column(Order = 0)]
        public int CarId { get; set; }
        [Key, Column(Order = 1)]
        public int CarFeatureId { get; set; }

        public virtual Car Car { get; set; }

        public virtual CarFeature CarFeature { get; set; }
    }
}
