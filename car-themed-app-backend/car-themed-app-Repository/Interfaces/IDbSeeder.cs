using System.Threading.Tasks;

namespace car_themed_app_Repository.Interfaces
{
    public interface IDbSeeder
    {
        Task<int> SeedDatabase();
    }
}
