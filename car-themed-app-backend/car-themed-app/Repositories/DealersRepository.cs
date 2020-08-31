using car_themed_app.Repository;
using car_themed_app_DataLayer;
using car_themed_app_Repository.Interfaces;
using car_themed_app_Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace car_themed_app.Repositories
{
    public class DealersRepository : IDealersRepository
    {
        private readonly AppDbContext _context;

        public DealersRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dealer> CreateDealerAsync(Dealer dealer)
        {
            await _context.AddAsync(dealer);
            await _context.SaveChangesAsync();
            _context.Entry(dealer).State = EntityState.Detached;
            return dealer;
        }

        public void DeleteDealer(int dealerId)
        {
            Dealer dealerToDelete = _context.Dealers.FirstOrDefault(o => o.Id == dealerId);
            _context.Remove(dealerToDelete);
            _context.SaveChanges();
        }

        public async Task<List<Dealer>> GetAllDealersAsync(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
            {
                return await _context.Dealers.ToListAsync();
            }

            int skipAmount = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;
            return await _context.Dealers
                .Skip(skipAmount)
                .Take(paginationFilter.PageSize)
                .ToListAsync();
        }

        public async Task<Dealer> GetDealerAsync(int dealerId)
        {
            Dealer dealer = await _context.Dealers.FirstOrDefaultAsync(o => o.Id == dealerId);
            return dealer;
        }

        public void UpdateDealer(Dealer dealer)
        {
            _context.Update(dealer);
            _context.SaveChanges();
        }

        public async Task<bool> CheckIfDealerExists(int dealerId)
        {
            return await _context.Dealers.AnyAsync(o => o.Id == dealerId);
        }
    }
}
