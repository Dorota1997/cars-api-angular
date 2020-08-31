namespace car_themed_app_Repository.Models
{
    public class Dealer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public Dealer()
        {

        }

        public Dealer(string Name, string Address, string PostalCode, string Country) 
        {
            this.Name = Name;
            this.Address = Address;
            this.PostalCode = PostalCode;
            this.Country = Country;
        }
    }
}
