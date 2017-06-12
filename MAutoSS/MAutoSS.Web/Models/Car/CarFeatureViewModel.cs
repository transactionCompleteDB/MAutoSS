using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Car
{
    public class CarFeatureViewModel
    {
        public int CarFeatureId { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Car feature should be between 2 and 40 chars long")]
        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}