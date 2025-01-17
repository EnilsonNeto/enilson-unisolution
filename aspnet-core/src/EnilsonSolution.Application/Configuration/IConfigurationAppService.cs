using System.Threading.Tasks;
using EnilsonSolution.Configuration.Dto;

namespace EnilsonSolution.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
