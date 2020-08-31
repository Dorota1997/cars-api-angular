using car_themed_app.Repository;
using car_themed_app_Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace car_themed_app_Repository.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<Order>> GetAllOrdersAsync(PaginationFilter paginationFilter = null);

        Task<Order> GetOrderAsync(int orderId);

        Task<Order> CreateOrderAsync(Order order);

        void DeleteOrder(int orderId);

        void UpdateOrder(Order order);

        Task<bool> CheckIfOrderExists(int orderId);
    }
}
