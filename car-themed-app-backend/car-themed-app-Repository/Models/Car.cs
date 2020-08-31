namespace car_themed_app_Repository.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string YearOfProduction { get; set; }

        public string VIN { get; set; }

        public string LicensePlate { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }

        public Car()
        {

        }

        public Car(string Brand, string Model, string YearOfProduction, string VIN, string LicensePlate, int DriverId)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.YearOfProduction = YearOfProduction;
            this.VIN = VIN;
            this.LicensePlate = LicensePlate;
            this.DriverId = DriverId;
        }
    }
}
