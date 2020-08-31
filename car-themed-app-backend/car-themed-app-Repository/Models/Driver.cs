using System;

namespace car_themed_app_Repository.Models
{
    public class Driver
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DrivingLicenseFrom { get; set; }

        public Driver()
        {

        }

        public Driver(string FullName, DateTime DateOfBirth, DateTime DrivingLicenseFrom)
        {
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.DrivingLicenseFrom = DrivingLicenseFrom;
        }
    }
}
