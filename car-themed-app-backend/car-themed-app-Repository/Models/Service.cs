using System;

namespace car_themed_app_Repository.Models
{
    public class Service
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateOfService { get; set; }

        public int MechanicId { get; set; }

        public virtual Mechanic Mechanic { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public Service()
        {

        }

        public Service(string Description, DateTime DateOfService, int MechanicId, int CarId)
        {
            this.Description = Description;
            this.DateOfService = DateOfService;
            this.MechanicId = MechanicId;
            this.CarId = CarId;
        }
    }
}
