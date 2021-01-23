namespace RealEstate.Core.Entities
{
    public class Property: BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Area { get; set; }
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public Owner Owner { get; set; }
        public Address Address { get; set; }
    }
}
