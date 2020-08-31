using System;

namespace car_themed_app_Repository.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Components { get; set; }

        public DateTime OrderDate { get; set; }

        public int DealerId { get; set; }

        public virtual Dealer Dealer { get; set; }

        public Order()
        {

        }

        public Order(string Components, DateTime OrderDate, int DealerId)
        {
            this.Components = Components;
            this.OrderDate = OrderDate;
            this.DealerId = DealerId;
        }
    }
}
