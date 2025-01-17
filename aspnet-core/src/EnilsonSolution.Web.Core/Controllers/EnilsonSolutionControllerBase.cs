using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EnilsonSolution.Controllers
{
    public abstract class EnilsonSolutionControllerBase: AbpController
    {
        protected EnilsonSolutionControllerBase()
        {
            LocalizationSourceName = EnilsonSolutionConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
