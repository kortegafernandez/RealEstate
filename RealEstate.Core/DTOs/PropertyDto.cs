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
        public int CategoryId { get; set; }
        public int CityId { get; set; }        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public OwnerDto Owner { get; set; }
        public CityDto City { get; set; }
        public PropertyCategoryDto Category { get; set; }
    }
}
