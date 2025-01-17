using System.Threading.Tasks;
using Abp.Application.Services;
using EnilsonSolution.Authorization.Accounts.Dto;

namespace EnilsonSolution.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
