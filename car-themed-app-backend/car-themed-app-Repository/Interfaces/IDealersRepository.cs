using car_themed_app.Repository;
using car_themed_app_Repository.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace car_themed_app_Repository.Interfaces
{
    public interface IDealersRepository
    {
        Task<List<Dealer>> GetAllDealersAsync(PaginationFilter paginationFilter = null);

        Task<Dealer> GetDealerAsync(int dealerId);

        Task<Dealer> CreateDealerAsync(Dealer dealer);

        void DeleteDealer(int dealerId);

        void UpdateDealer(Dealer dealer);

        Task<bool> CheckIfDealerExists(int dealerId);
    }
}
