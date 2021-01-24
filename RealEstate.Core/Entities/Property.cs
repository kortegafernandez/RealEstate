namespace RealEstate.Core.Entities
{
    public class Property: BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Area { get; set; }
        public int OwnerId { get; set; }        
        public int CategoryId { get; set; }
        public int CityId { get; set; }        
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }

        public Owner Owner { get; set; }        
        public PropertyCategory Category { get; set; }
        public City City { get; set; }
    }
}
