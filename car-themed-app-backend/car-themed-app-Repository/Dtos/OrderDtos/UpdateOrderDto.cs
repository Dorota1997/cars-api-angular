namespace car_themed_app_Repository.Dtos.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }

        public string Components { get; set; }

        public string OrderDate { get; set; }

        public int DealerId { get; set; }
    }
}
