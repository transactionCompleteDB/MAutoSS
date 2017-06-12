using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Customer
{
    public class CustomerModel
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string Discount { get; set; }
    }
}