using RealEstate.Core.Entities;

namespace RealEstate.Core.DTOs
{
    public class PropertyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Area { get; set; }
        public int OwnerId { get; set; }
        public int AddressId { get; set; }
        public int CategoryId { get; set; }
    }
}
