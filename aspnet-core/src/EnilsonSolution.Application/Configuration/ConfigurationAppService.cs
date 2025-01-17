using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EnilsonSolution.Configuration.Dto;

namespace EnilsonSolution.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EnilsonSolutionAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
