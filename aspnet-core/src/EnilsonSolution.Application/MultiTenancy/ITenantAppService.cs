using Abp.Application.Services;
using EnilsonSolution.MultiTenancy.Dto;

namespace EnilsonSolution.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

