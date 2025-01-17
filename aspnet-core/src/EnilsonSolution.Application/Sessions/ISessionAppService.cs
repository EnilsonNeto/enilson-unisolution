using System.Threading.Tasks;
using Abp.Application.Services;
using EnilsonSolution.Sessions.Dto;

namespace EnilsonSolution.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
