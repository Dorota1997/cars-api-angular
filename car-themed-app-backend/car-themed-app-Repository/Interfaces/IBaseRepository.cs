using car_themed_app_Repository.Dtos;
using System.Threading.Tasks;

namespace car_themed_app_Repository.Interfaces
{
    public interface IBaseRepository
    {
        Task<CountedElementsAndPagesDto> GetTotalElementsAndPagesNumber(int pageSize);
    }
}
