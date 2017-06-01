namespace MAutoSS.DataModels
{
    public class Address
    {
        public int Id { get; set; }

        public string AddressText { get; set; }

        public int DealershipId { get; set; }

        public virtual Dealership Dealership { get; set; }
    }
}
