namespace MAutoSS.DataModels
{
    public class Dealership
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
