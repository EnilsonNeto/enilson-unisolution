using Abp.Application.Services;

namespace EnilsonSolution.Tanks
{

    using Dto;
    using System.Threading.Tasks;

    public interface ITankAppService : IAsyncCrudAppService<TankDto, string, PagedTankResultRequestDto, CreateTankDto, TankDto>
    {
        Task<TankDto> CreateTankAsync(CreateTankDto input);

        Task<TankDto> GetByIdAsync(string id);
    }
}
