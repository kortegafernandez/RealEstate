namespace RealEstate.Core.Entities
{
    public class Address: BaseEntity
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
    }
}
